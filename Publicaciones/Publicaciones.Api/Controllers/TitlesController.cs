using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
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
		public IEnumerable<Titles> Get()
		{
			var titles = this._titlesRepository.GetEntities();
			return titles;
		}


		[HttpGet("GetTitleByID")]
		public IActionResult GetTitleByID(string ID)
		{
			var titles = this._titlesRepository.GetEntityByID(ID);
			return Ok(titles);
		}

		[HttpPost("SaveTitle")]
		public IActionResult Post([FromBody] TitlesAddModel titlesAdd)
		{
			this._titlesRepository.Save(new Titles()
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
		});
			return Ok();
		}

		[HttpPost("UpdateTitle")]
		public IActionResult Put([FromBody] TitlesUpdateModel titlesUpdate)
		{
			this._titlesRepository.Update(new Titles()
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
			});
			return Ok();
		}
	}
}
