using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

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

        [HttpGet("GetPub_Infos")]
        public IEnumerable<Pub_Info> Get()
        {
            var pubInfos = this._pub_info_repository.GetEntities();
            return pubInfos;
        }


        [HttpGet("GetPub_InfoByID")]
        public IActionResult GetPub_InfoByID(string ID)
        {
            var pub_infos = this._pub_info_repository.GetEntityByID(ID);
            return Ok(pub_infos);
        }


        // POST api/<Pub_InfoController>
        [HttpPost]
        //public IActionResult Post([FromBody] Pub_Info pub_Info)
        //{     
        //}

        // PUT api/<Pub_InfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE NO VA
    }
}
