using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
using Publicaciones.Api.Models.Modules.RoySched;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoySchedController : ControllerBase
{
        private readonly IRoySchedService _roySchedService;

        public RoySchedController(IRoySchedService roySchedService)
        {
            this._roySchedService = roySchedService;
        }

		[HttpGet("GetRoyScheds")]
		public IActionResult GetRoyScheds()
		{
			var result = this._roySchedService.GetAll();

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet("GetRoySchedByID")]
		public IActionResult GetRoySchedByID(int ID)
		{
			var result = this._roySchedService.GetByID(ID);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet("GetRoySchedsByRoyalty")]
		public IActionResult GetRoySchedByRoyalty(int royalty)
		{
			var result = this._roySchedService.GetRoySchedsByRoyalty(royalty);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet("GetRoySchedsByTitle")]
		public IActionResult GetRoySchedByTitle(int titleId)
		{
			var result = this._roySchedService.GetRoySchedsByTitle(titleId);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPost("SaveRoySched")]
		public IActionResult Post([FromBody] RoySchedDtoAdd roySchedDtoAdd)
		{
			var existsInTitlesResult = this._roySchedService.ExistsInTitles(roySchedDtoAdd.Title_ID);

			if (!existsInTitlesResult.Success)
			{
				return BadRequest(existsInTitlesResult.Message); 
			}

			var result = this._roySchedService.Save(roySchedDtoAdd);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPut("UpdateRoySched")]
		public IActionResult Put([FromBody] RoySchedDtoUpdate roySchedDtoUpdate)
		{
			var result = this._roySchedService.Update(roySchedDtoUpdate);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPut("RemoveRoySched")]
		public IActionResult Remove([FromBody] RoySchedDtoRemove roySchedDtoRemove)
		{
			var result = this._roySchedService.Remove(roySchedDtoRemove);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}
	}
}