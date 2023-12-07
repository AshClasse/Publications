using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Titles;
using System;

namespace Publicaciones.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TitlesController : ControllerBase
	{
		private readonly ITitlesService _titlesService;
		public TitlesController(ITitlesService titlesService)
		{
			this._titlesService = titlesService;
		}

		[HttpGet("GetTitles")]
		public IActionResult GetTitles()
		{
			var result = this._titlesService.GetAll();

			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("GetTitleByID")]
		public IActionResult GetTitleByID(int ID)
		{
			var existsResult = this._titlesService.Exists(ID);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var result = this._titlesService.GetByID(ID);

			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}


		[HttpGet("GetTitleByPrice")]
		public IActionResult GetTitleByPrice(decimal price)
		{
			var result = this._titlesService.GetTitlesByPrice(price);

			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("GetTitleByPublisherID")]
		public IActionResult GetTitleByPublisherID(int pubId)
		{
			var existsInPubsResult = this._titlesService.ExistsInPublishers(pubId);

			if (!existsInPubsResult.Success)
			{
				return BadRequest(existsInPubsResult.Message);
			}

			var result = this._titlesService.GetTitlesByPublisherID(pubId);

			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("GetTitleByType")]
		public IActionResult GetTitleByType(string type)
		{
			var result = this._titlesService.GetTitlesByType(type);

			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpPost("SaveTitle")]
		public IActionResult Post([FromBody] TitlesDtoAdd titlesDtoAdd)
		{
			var existsInPubsResult = this._titlesService.ExistsInPublishers(titlesDtoAdd.PubID);

			if (!existsInPubsResult.Success)
			{
				return BadRequest(existsInPubsResult.Message);
			}

			var result = this._titlesService.Save(titlesDtoAdd);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPost("UpdateTitle")]
		public IActionResult Post([FromBody] TitlesDtoUpdate titlesDtoUpdate)
		{
			var existsResult = this._titlesService.Exists(titlesDtoUpdate.Title_ID);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var existsInPubsResult = this._titlesService.ExistsInPublishers(titlesDtoUpdate.PubID);

			if (!existsInPubsResult.Success)
			{
				return BadRequest(existsInPubsResult.Message);
			}

			var result = this._titlesService.Update(titlesDtoUpdate);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPost("RemoveTitle")]
		public IActionResult Remove([FromBody] TitlesDtoRemove titlesDtoRemove)
		{
			var existsResult = this._titlesService.Exists(titlesDtoRemove.Id);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var result = this._titlesService.Remove(titlesDtoRemove);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}
	}
}
