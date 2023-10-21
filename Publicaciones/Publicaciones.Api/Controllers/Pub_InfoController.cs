using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Modules.Pub_InfoModels;
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
        public IEnumerable<Pub_Info> Get()
        {
            var pubInfos = this._pub_info_repository.GetEntities();
            return pubInfos;
        }


        [HttpGet("GetPub_InfoByID")]
        public IActionResult GetPub_InfoByID(string ID)
        {
            var pub_infos = this._pub_info_repository.GetEntityByID(ID);
            return Ok(pub_infos);
        }

        [HttpPost("SavePub_Info")]
        public IActionResult Post([FromBody] Pub_InfoAddModel pub_InfoAdd)
        {
            this._pub_info_repository.Save(new Pub_Info()
            {
                CreationDate = pub_InfoAdd.ChangeDate,
                IDCreationUser = pub_InfoAdd.ChangeUser,
                PubID = pub_InfoAdd.PubID,
                Pr_Info = pub_InfoAdd.Pr_Info,
                Logo = pub_InfoAdd.Logo,
            });
            return Ok();
        }

		[HttpPost("UpdatePub_Info")]
		public IActionResult Put([FromBody] Pub_InfoUpdateModel pub_InfoUpdate)
        {
			this._pub_info_repository.Update(new Pub_Info()
			{
				ModifiedDate = pub_InfoUpdate.ChangeDate,
				IDModifiedUser = pub_InfoUpdate.ChangeUser,
				PubID = pub_InfoUpdate.PubID,
				Pr_Info = pub_InfoUpdate.Pr_Info,
				Logo = pub_InfoUpdate.Logo,
			});
			return Ok();
		}

    }
}
