using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
using Publicaciones.Api.Models.Modules.RoySched;
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

		[HttpPost("SaveRoySched")]
		public IActionResult Post([FromBody] RoySchedAddModel roySchedAdd)
		{
			if (!_roySchedRepository.ExistsInTitles(roySchedAdd.Title_ID))
			{
				return BadRequest("Título no existente.");
			}

			this._roySchedRepository.Save(new RoySched()
			{
				CreationDate = roySchedAdd.ChangeDate,
				IDCreationUser = roySchedAdd.ChangeUser,
				Title_ID = roySchedAdd.Title_ID,
				LoRange = roySchedAdd.LoRange,
				HiRange = roySchedAdd.HiRange,
				Royalty = roySchedAdd.Royalty
			});
			return Ok();
		}

		[HttpPost("UpdateRoySched")]
		public IActionResult Put([FromBody] RoySchedUpdateModel roySchedUpdate)
		{
			this._roySchedRepository.Update(new RoySched()
			{
				ModifiedDate = roySchedUpdate.ChangeDate,
				IDModifiedUser = roySchedUpdate.ChangeUser,
				Title_ID = roySchedUpdate.Title_ID,
				LoRange = roySchedUpdate.LoRange,
				HiRange = roySchedUpdate.HiRange,
				Royalty = roySchedUpdate.Royalty
			});
			return Ok();
		}
	}
}
