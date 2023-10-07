using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pub_InfoController : ControllerBase
    {
        private readonly IPub_InfoRepository _pub_info_repository;

        public Pub_InfoController(IPub_InfoRepository pub_info_repository)
        {
            this._pub_info_repository = pub_info_repository;
        }

        // GET: api/<Pub_InfoController>
        [HttpGet]
        public IEnumerable<Pub_Info> Get()
        {
            var pub_infos = this._pub_info_repository.GetPub_Infos();
            return pub_infos;
        }

        // GET api/<Pub_InfoController>/5
        [HttpGet("{ID}")]
        public Pub_Info Get(string ID)
        {
            return this._pub_info_repository.GetPub_Info(ID);
        }

        // POST api/<Pub_InfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Pub_InfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Pub_InfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
