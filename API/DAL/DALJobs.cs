using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.Data.SqlClient;

namespace API.DAL;
public class DALJobs
{
    public DTOJobResponse createjobs(MDJobs request)
    {
        using DataContext context = new DataContext();

        context.Jobs.Add(request);

        context.SaveChanges();

        if (request.Id > 0)
        {
            request.JobCode = @"Job-" + request.Id;
        }

        context.SaveChanges();

        return new DTOJobResponse { JobId = request.Id };
    }

    public DTOJobResponse updatejobs(int jobId, MDJobs request)
    {
        using DataContext context = new DataContext();

        MDJobs? job = context.Jobs.Where(job => job.Id == jobId).FirstOrDefault();

        if (job != null)
        {
            job.Title = request.Title;
            job.Description = request.Description;
            job.LocationId = request.LocationId;
            job.DepartmentId = request.DepartmentId;
            job.ClosingDate = request.ClosingDate;

            context.SaveChanges();

            return new DTOJobResponse { JobId = job.Id };
        }
        return new DTOJobResponse { JobId = 0 };
    }

    public DTOJobDetailsResponse getJobDetails(int id)
    {
        using DataContext context = new DataContext();

        DTOJobDetailsResponse? result = (from job in context.Jobs
                                         join department in context.Department
                                             on job.DepartmentId equals department.Id
                                         join location in context.Location
                                             on job.LocationId equals location.Id
                                         where job.Id == id
                                         select new DTOJobDetailsResponse
                                         {
                                             Id = job.Id,
                                             Code = job.JobCode,
                                             Title = job.Title,
                                             Description = job.Description,
                                             Location = new Location
                                             {
                                                 Id = location.Id,
                                                 Title = location.Title,
                                                 City = location.City,
                                                 State = location.State,
                                                 Country = location.Country,
                                                 Zip = location.Zip
                                             },
                                             Department = new Department
                                             {
                                                 Id = department.Id,
                                                 Title = department.Title
                                             },
                                             PostedDate = job.PostedDate,
                                             ClosingDate = job.ClosingDate
                                         }).FirstOrDefault();

        return result;
    }

    public DTOJobListResponse getJobs(DTOJobListRequest request)
    {
        using DataContext context = new DataContext();
        DTOJobListResponse response = new DTOJobListResponse();


        var allJobs = (from job in context.Jobs
                            join location in context.Location on job.LocationId equals location.Id
                            join department in context.Department on job.DepartmentId equals department.Id
                        select new
                        {
                            Id = job.Id,
                            Code = job.JobCode,
                            Title = job.Title,
                            LocationId = job.LocationId,
                            LocationName = location.Title,
                            DepartmentId = job.DepartmentId,
                            DepartmentName = department.Title,
                            PostedDate = job.PostedDate,
                            ClosingDate = job.ClosingDate
                        }).ToList().Skip(request.PageSize * (request.PageNo - 1)).Take(request.PageSize).ToList();

        // Filter by title
        if(!string.IsNullOrEmpty(request.Q))
        {
            allJobs = allJobs.Where(job => job.Title.Contains(request.Q)).ToList();
        }

        // Filter by location
        if(request.LocationId > 0)
        {
            allJobs = allJobs.Where(job => job.LocationId == request.LocationId).ToList();
        }

        // Filter by department
        if(request.DepartmentId > 0)
        {
            allJobs = allJobs.Where(job => job.DepartmentId == request.DepartmentId).ToList();
        }

        response.Total = allJobs.Count;
        response.Data = (from job in allJobs
                            select new DTOJobListJob
                            {
                                Id = job.Id,
                                Code = job.Code,
                                Title = job.Title,
                                Location = job.LocationName,
                                Department = job.DepartmentName,
                                PostedDate = job.PostedDate,
                                ClosingDate = job.ClosingDate
                            }).ToList<DTOJobListJob>();

        return response;
    }
}