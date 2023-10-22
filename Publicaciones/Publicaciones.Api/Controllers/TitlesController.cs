using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
using Publicaciones.Api.Models.Modules.RoySched;
using Publicaciones.Api.Models.Modules.Titles;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitlesRepository _titlesRepository;
        public TitlesController(ITitlesRepository titlesRepository) 
        {
            this._titlesRepository = titlesRepository;
        }

		[HttpGet("GetTitles")]
		public IActionResult GetTitles()
		{
			var titles = this._titlesRepository.GetEntities().Select(tt => new TitlesGetModel()
			{
				Title_ID = tt.Title_ID,
				Title = tt.Title,
				PubID = tt.PubID,
				Royalty = tt.Royalty,
				Advance = tt.Advance,
				Price = tt.Price,
				Notes = tt.Notes,
				PubDate	= tt.PubDate,
				Ytd_Sales = tt.Ytd_Sales,
				Type = tt.Type,
				ChangeDate = tt.CreationDate,
				ChangeUser = tt.IDCreationUser
			}).ToList(); ;
			return Ok(titles);
		}

		[HttpGet("GetTitleByID")]
		public IActionResult GetTitleByID(int ID)
		{
			var titles = this._titlesRepository.GetEntityByID(ID);
			return Ok(titles);
		}

		[HttpGet("GetTitleByPublisher")]
		public IActionResult GetTitleByPublisher(int pubId)
		{
			var titles = this._titlesRepository.GetTitlesByPublisher(pubId);
			return Ok(titles);
		}

		[HttpGet("GetTitleByPrice")]
		public IActionResult GetTitleByPrice(decimal price)
		{
			var titles = this._titlesRepository.GetTitlesByPrice(price);
			return Ok(titles);
		}

		[HttpGet("GetTitleByType")]
		public IActionResult GetTitleByType(string type)
		{
			var titles = this._titlesRepository.GetTitlesByType(type);
			return Ok(titles);
		}

		[HttpPost("SaveTitle")]
		public IActionResult Post([FromBody] TitlesAddModel titlesAdd)
		{
			Titles titles = new Titles()
			{
				Title = titlesAdd.Title,
				Royalty = titlesAdd.Royalty,
				Type = titlesAdd.Type,
				Ytd_Sales = titlesAdd.Ytd_Sales,
				Price = titlesAdd.Price,
				Advance = titlesAdd.Advance,
				PubID = titlesAdd.PubID,
				Notes = titlesAdd.Notes,
				PubDate = titlesAdd.PubDate,
				CreationDate = titlesAdd.ChangeDate,
				IDCreationUser = titlesAdd.ChangeUser
		};
			this._titlesRepository.Save(titles);
			return Created("Object Created", titles);
		}

		[HttpPut("UpdateTitle")]
		public IActionResult Put([FromBody] TitlesUpdateModel titlesUpdate)
		{
			Titles titles = new Titles()
			{
				Title_ID = titlesUpdate.Title_ID,
				Title = titlesUpdate.Title,
				Royalty = titlesUpdate.Royalty,
				Type = titlesUpdate.Type,
				Ytd_Sales = titlesUpdate.Ytd_Sales,
				Price = titlesUpdate.Price,
				Advance = titlesUpdate.Advance,
				PubID = titlesUpdate.PubID,
				Notes = titlesUpdate.Notes,
				PubDate = titlesUpdate.PubDate,
				ModifiedDate = titlesUpdate.ChangeDate,
				IDModifiedUser = titlesUpdate.ChangeUser
			};

			this._titlesRepository.Update(titles);
			return Ok();
		}
	}
}
