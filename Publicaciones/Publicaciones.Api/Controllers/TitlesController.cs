using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
using Publicaciones.Api.Models.Modules.RoySched;
using Publicaciones.Api.Models.Modules.Titles;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

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
			var result = this._titlesService.GetByID(ID);

			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		//[HttpGet("GetTitleByPublisher")]
		//public IActionResult GetTitleByPublisher(int pubId)
		//{
		//	var titles = this._titlesRepository.GetTitlesByPublisher(pubId);
		//	return Ok(titles);
		//}

		//[HttpGet("GetTitleByPrice")]
		//public IActionResult GetTitleByPrice(decimal price)
		//{
		//	var titles = this._titlesRepository.GetTitlesByPrice(price);
		//	return Ok(titles);
		//}

		//[HttpGet("GetTitleByType")]
		//public IActionResult GetTitleByType(string type)
		//{
		//	var titles = this._titlesRepository.GetTitlesByType(type);
		//	return Ok(titles);
		//}

		[HttpPost("SaveTitle")]
		public IActionResult Post([FromBody] TitlesDtoAdd titlesDtoAdd)
		{
			var result = this._titlesService.Save(titlesDtoAdd);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPut("UpdateTitle")]
		public IActionResult Put([FromBody] TitlesDtoUpdate titlesDtoUpdate)
		{
			var result = this._titlesService.Update(titlesDtoUpdate);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPut("RemoveTitle")]
		public IActionResult Remove([FromBody] TitlesDtoRemove titlesDtoRemove)
		{
			var result = this._titlesService.Remove(titlesDtoRemove);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}
	}
}
