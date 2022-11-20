using API.DAL;
using API.DTOs;
using API.Models;

namespace API.BAL;
public class BALJobs
{
    public DTOJobResponse createjobs(DTOJobRequest request)
    {
        DALJobs dALJobs = new DALJobs();

        MDJobs job = new MDJobs
        {
            Title = request.Title,
            JobCode = "",
            Description = request.Description,
            LocationId = request.LocationId,
            DepartmentId = request.DepartmentId,
            ClosingDate = request.ClosingDate,
            PostedDate = DateTime.Now
        };

        return dALJobs.createjobs(job);
    }

    public DTOJobResponse updatejobs(int jobId, DTOJobRequest request)
    {
        DALJobs dALJobs = new DALJobs();

        MDJobs job = new MDJobs
        {
            Title = request.Title,
            Description = request.Description,
            LocationId = request.LocationId,
            DepartmentId = request.DepartmentId,
            ClosingDate = request.ClosingDate
        };

        return dALJobs.updatejobs(jobId, job);
    }

    public DTOJobDetailsResponse getJobDetails(int id)
    {
        DALJobs dALJobs = new DALJobs();
        return dALJobs.getJobDetails(id);
    }

    public DTOJobListResponse getJobs(DTOJobListRequest request)
    {
        DALJobs dALJobs = new DALJobs();
        return dALJobs.getJobs(request);
    }
}