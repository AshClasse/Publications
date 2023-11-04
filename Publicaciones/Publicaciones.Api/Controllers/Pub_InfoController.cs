using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_Info;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
using Publicaciones.Api.Models.Modules.RoySched;
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
        public IActionResult GetPub_Infos()
        {
            var pubInfos = this._pub_info_repository.GetEntities().Select(pi => new Pub_InfoGetModel()
			{
				PubID = pi.PubID,
				Logo = pi.Logo,
				Pr_Info = pi.Pr_Info,
				ChangeDate = pi.CreationDate,
				ChangeUser = pi.IDCreationUser

			}).ToList(); 
            return Ok(pubInfos);
        }

        [HttpGet("GetPub_InfoByID")]
        public IActionResult GetPub_InfoByID(int ID)
        {
            var pub_infos = this._pub_info_repository.GetEntityByID(ID);
            return Ok(pub_infos);
        }

        [HttpPost("SavePub_Info")]
        public IActionResult Post([FromBody] Pub_InfoAddModel pub_InfoAdd)
        {
            Pub_Info pub_Info = new Pub_Info() 
            {
                CreationDate = pub_InfoAdd.ChangeDate,
                IDCreationUser = pub_InfoAdd.ChangeUser,
                Pr_Info = pub_InfoAdd.Pr_Info,
                Logo = pub_InfoAdd.Logo,
            };

            this._pub_info_repository.Save(pub_Info);
            return Created("Object Created", pub_Info);
        }

		[HttpPut("UpdatePub_Info")]
		public IActionResult Put([FromBody] Pub_InfoUpdateModel pub_InfoUpdate)
        {
			Pub_Info pubInfo = new Pub_Info()
			{
				PubID = pub_InfoUpdate.PubID,
				Pr_Info = pub_InfoUpdate.Pr_Info,
				Logo = pub_InfoUpdate.Logo,				
                ModifiedDate = pub_InfoUpdate.ChangeDate,
				IDModifiedUser = pub_InfoUpdate.ChangeUser
			};
            this._pub_info_repository.Update(pubInfo);
			return Ok();
		}

    }
}
