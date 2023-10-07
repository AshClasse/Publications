using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoySchedController : ControllerBase
{
        private readonly IRoySchedRepository _roySchedRepository;

        public RoySchedController(IRoySchedRepository roySchedRepository)
        {
            this._roySchedRepository = roySchedRepository;
        }

        // GET: api/<RoySchedController>
        [HttpGet]
        public IEnumerable<RoySched> Get()
        {
            var royscheds = this._roySchedRepository.GetRoyScheds();
            return royscheds;
        }

        // GET api/<RoySchedController>/5
        [HttpGet("{ID}")]
        public RoySched Get(string ID)
        {
            return this._roySchedRepository.GetRoySched(ID);
        }

        // POST api/<RoySchedController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoySchedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoySchedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
