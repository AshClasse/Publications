using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public List<Jobs> Get()
        {
            var jobs = _jobsRepository.GetEntities();
            return jobs;
        }

        // GET api/<JobsController>/5
        [HttpGet("{ID}")]
        public Jobs Get(short ID)
        {
            var jobs = _jobsRepository.GetEntityByID(ID);
            return jobs;
        }

        // POST api/<JobsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
