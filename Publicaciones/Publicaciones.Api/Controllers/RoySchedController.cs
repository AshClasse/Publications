using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

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

		[HttpGet("GetRoyScheds")]
		public IEnumerable<RoySched> Get()
		{
			var royScheds = this._roySchedRepository.GetEntities();
			return royScheds;
		}

		[HttpGet("GetRoySchedByTitle")]
		public IActionResult GetRoySchedByTitle(string titleId)
		{
			var royScheds = this._roySchedRepository.GetRoySchedsByTitle(titleId);
			return Ok(royScheds);
		}

		// POST api/<RoySchedController>
		[HttpPost]
        public IActionResult Post([FromBody] RoySched roySched)
        {	
			if (!_roySchedRepository.ExistsInTitles(roySched.Title_ID))
			{
				return BadRequest("Título no existente.");
			}

			_roySchedRepository.Save(roySched);
			return Ok("Registro creado exitosamente");
		}

        // PUT api/<RoySchedController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
        }

        // DELETE api/<RoySchedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
