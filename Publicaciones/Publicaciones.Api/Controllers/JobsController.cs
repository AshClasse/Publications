using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.DTO.Jobs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;

        public JobsController(IJobsService _jobsService)
        {
            this._jobsService = _jobsService;
        }

        // GET_JOBSBYID ENDPOINT
        [HttpGet("GetJobsByID")]
        public IActionResult GetJobsByID(int ID)
        {
            var result = _jobsService.GetByID(ID);

            if (!result.Success)
                return BadRequest(result);
            
            return Ok(result);
        }

        //GETJOBS ENDPOINT
        [HttpGet("GetJobs")]
        public IActionResult GetJobs()
        {
            var result = _jobsService.GetAll();
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        //SAVE_JOBS ENDPOINT
        [HttpPost("SaveJobs")]
        public IActionResult SaveJobs([FromBody] JobsDtoAdd jobdtoadd)
        {
            var result = _jobsService.Save(jobdtoadd);

            if (!result.Success)
                return BadRequest(result);
  
            return Ok(result);
        }


        //UPDATE_ENDPOINT
        [HttpPost("UpdateJobs")]

        public IActionResult UpdateJobs([FromBody] JobsDtoUpdate jobdtoupdate)
        {
            var result = _jobsService.Update(jobdtoupdate);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


        //DELETE_ENDPOINT
        [HttpPost("DeleteJobs")]
        public IActionResult RemoveJobs([FromBody] JobDtoRemove jobDtoRemove)
        {
            var result = _jobsService.Remove(jobDtoRemove);
            
            if (!result.Success)
                return BadRequest(result);
 
            return Ok(result);
        }

    }
}
