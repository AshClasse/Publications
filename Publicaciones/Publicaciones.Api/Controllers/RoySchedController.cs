using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.RoySched;

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
			var existsResult = this._roySchedService.Exists(ID);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var result = this._roySchedService.GetByID(ID);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet("GetRoySchedByTitleID")]
		public IActionResult GetRoySchedByTitleID(int titleId)
		{
			var existsInTitlesResult = this._roySchedService.ExistsInTitles(titleId);

			if (!existsInTitlesResult.Success)
			{
				return BadRequest(existsInTitlesResult.Message);
			}

			var result = this._roySchedService.GetRoySchedsByTitleID(titleId);

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

		[HttpPost("UpdateRoySched")]
		public IActionResult Post([FromBody] RoySchedDtoUpdate roySchedDtoUpdate)
		{
			var existsResult = this._roySchedService.Exists(roySchedDtoUpdate.RoySched_ID);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var existsInTitlesResult = this._roySchedService.ExistsInTitles(roySchedDtoUpdate.Title_ID);

			if (!existsInTitlesResult.Success)
			{
				return BadRequest(existsInTitlesResult.Message);
			}

			var result = this._roySchedService.Update(roySchedDtoUpdate);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPost("RemoveRoySched")]
		public IActionResult Remove([FromBody] RoySchedDtoRemove roySchedDtoRemove)
		{
			var existsResult = this._roySchedService.Exists(roySchedDtoRemove.Id);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var result = this._roySchedService.Remove(roySchedDtoRemove);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}
	}
}