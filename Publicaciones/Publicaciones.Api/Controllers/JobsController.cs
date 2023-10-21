using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Jobs_Module;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository _jobsRepository)
        {
            this._jobsRepository = _jobsRepository;
        }

        // GET: api/<JobsController>
        [HttpGet("GetJobs")]
        public IActionResult GetEmployees()
        {
            var jobs = _jobsRepository.GetEntities().Select(JobbGet => new Jobs()
            {
                JobID = JobbGet.JobID,
                JobDescription = JobbGet.JobDescription,
                Minlvl = JobbGet.Minlvl,
                Maxlvl = JobbGet.Maxlvl,
                ModifiedDate = JobbGet.CreationDate,
                IDModifiedUser = JobbGet.IDModifiedUser
            }).ToList();

            return Ok(jobs);
        }

        // GET api/<JobsController>/5
        [HttpGet("GetJobsByID")]
        public IActionResult GetJobsByID(int ID)
        {
            var JobbGet = _jobsRepository.GetEntityByID(ID);

            JobGetModel jobgetm = new JobGetModel()
            {
                JobID = JobbGet.JobID,
                JobDescription = JobbGet.JobDescription,
                Minlvl = JobbGet.Minlvl,
                Maxlvl = JobbGet.Maxlvl,
                ChangeDate = JobbGet.CreationDate,
                ChangeUser = JobbGet.IDCreationUser,
            };

            return Ok(jobgetm);
        }

        // POST api/<JobsController>
        [HttpPost("JobCreation")]
        public IActionResult Post([FromBody] JobAddModel JobADD)
        {
            Jobs jobs = new Jobs()
            {
                JobDescription = JobADD.JobDescription,
                Minlvl = JobADD.Minlvl,
                Maxlvl = JobADD.Maxlvl,
                CreationDate = JobADD.ChangeDate,
                IDModifiedUser = JobADD.ChangeUser
            };

            this._jobsRepository.Save(jobs);
            return Created("Object Created", jobs);
        }

        // PUT api/<JobsController>/5
        [HttpPut("UpdateJobs")]
        public IActionResult Put([FromBody] JobUpdateModel JobsU)
        {
            Jobs JobExist = _jobsRepository.GetEntityByID(JobsU.JobID);

            if (JobExist == null)
            {
                NoContent();
            }

            JobExist.JobDescription = JobsU.JobDescription;
            JobExist.Minlvl = JobsU.Minlvl;
            JobExist.Maxlvl = JobsU.Maxlvl;
            JobExist.CreationDate = JobsU.ChangeDate;
            JobExist.IDModifiedUser = JobsU.ChangeUser;

            this._jobsRepository.Update(JobExist);
            return NoContent();

        }
    }
}
