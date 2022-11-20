using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.BAL;
using API.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobsController : ControllerBase
    {
        [HttpPost]
        public DTOJobResponse createjobs(DTOJobRequest request)
        {
            BALJobs bALJobs = new BALJobs();
            return bALJobs.createjobs(request);
        }

        [HttpPut]
        [Route("{jobId}")]
        public object updatejobs(int jobId, DTOJobRequest request)
        {
            BALJobs bALJobs = new BALJobs();
            bALJobs.updatejobs(jobId, request);

            return new object();
        }

        [HttpGet]
        [Route("{id}")]
        public DTOJobDetailsResponse getJobDetails(int id)
        {
            BALJobs bALJobs = new BALJobs();
            return bALJobs.getJobDetails(id);
        }

        [HttpPost]
        [Route("list")]
        public DTOJobListResponse getJobs(DTOJobListRequest request)
        {
            BALJobs bALJobs = new BALJobs();
            return bALJobs.getJobs(request);
        }
    }
}