using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
using Publicaciones.Api.Models.Modules.RoySched;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

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
		public IActionResult GetRoyScheds()
		{
			var royScheds = this._roySchedRepository.GetEntities().Select(rs => new RoySchedGetModel()
			{
				RoySched_ID = rs.RoySched_ID,
				Title_ID = rs.Title_ID,
				HiRange = rs.HiRange,
				LoRange = rs.LoRange,
				ChangeDate = rs.CreationDate,
				ChangeUser = rs.IDCreationUser

			}).ToList();
			return Ok(royScheds);
		}

		[HttpGet("GetRoySchedByID")]
		public IActionResult GetRoySchedByID(int roySchedID)
		{
			var roySched = this._roySchedRepository.GetEntityByID(roySchedID);
			return Ok(roySched);
		}

		[HttpGet("GetRoySchedsByRoyalty")]
		public IActionResult GetRoySchedByRoyalty(int royalty)
		{
			var royScheds = this._roySchedRepository.GetRoySchedsByRoyalty(royalty);
			return Ok(royScheds);
		}

		[HttpGet("GetRoySchedsByTitle")]
		public IActionResult GetRoySchedByTitle(int titleId)
		{
			var royScheds = this._roySchedRepository.GetRoySchedsByTitle(titleId);
			return Ok(royScheds);
		}

		[HttpPost("SaveRoySched")]
		public IActionResult Post([FromBody] RoySchedAddModel roySchedAdd)
		{
			if (!_roySchedRepository.ExistsInTitles(roySchedAdd.Title_ID))
			{
				return BadRequest("Non-Existent Title.");
			}

			RoySched roySched = new RoySched()
			{
				Title_ID = roySchedAdd.Title_ID,
				LoRange = roySchedAdd.LoRange,
				HiRange = roySchedAdd.HiRange,
				Royalty = roySchedAdd.Royalty,				
				CreationDate = roySchedAdd.ChangeDate,
				IDCreationUser = roySchedAdd.ChangeUser
			};

			this._roySchedRepository.Save(roySched);
			return Created("Object Created", roySched);
		}

		[HttpPut("UpdateRoySched")]
		public IActionResult Put([FromBody] RoySchedUpdateModel roySchedUpdate)
		{
			RoySched roySched = new RoySched()
			{
				RoySched_ID = roySchedUpdate.RoySched_ID,
				Title_ID = roySchedUpdate.Title_ID,
				LoRange = roySchedUpdate.LoRange,
				HiRange = roySchedUpdate.HiRange,
				Royalty = roySchedUpdate.Royalty,
				ModifiedDate = roySchedUpdate.ChangeDate,
				IDModifiedUser = roySchedUpdate.ChangeUser
			};

			this._roySchedRepository.Update(roySched);
			return Ok();
		}
	}
}
