using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Api.Models.Publisher_Module;
using Publicaciones.Infrastructure.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository _publisherRepository)
        {
            this._publisherRepository = _publisherRepository;
        }

        // GET: api/<PublisherController>
        [HttpGet("GetPublishers")]
        public IActionResult GetPublisher()
        {
            var publishers = _publisherRepository.GetEntities().Select(PubsGet => new PublisherGetModel()
            {
                PubID = PubsGet.PubID,
                PubName = PubsGet.PubName,
                State = PubsGet.State,
                Country = PubsGet.Country,
                City = PubsGet.City,
                ChangeDate = PubsGet.CreationDate,
                ChangeUser = PubsGet.IDCreationUser

            }).ToList();
            return Ok(publishers);
        }

        // GET api/<PublisherController>/5
        [HttpGet("GetPublisherID")]
        public IActionResult GetPublisherByID(int ID)
        {
            var PubsGet = _publisherRepository.GetEntityByID(ID);

            PublisherGetModel PublisherGetM = new PublisherGetModel()
            {
                PubID = PubsGet.PubID,
                PubName = PubsGet.PubName,
                State = PubsGet.State,
                Country = PubsGet.Country,
                City = PubsGet.City,
                ChangeDate = PubsGet.CreationDate,
                ChangeUser = PubsGet.IDCreationUser
            };

            return Ok(PublisherGetM);
        }


        // POST api/<PublisherController>
        [HttpPost("SavePublisher")]
        public IActionResult Post([FromBody] PublisherAddModel PubAdd)
        {
            Publisher pub = new Publisher()
            {
                PubName = PubAdd.PubName,
                State = PubAdd.State,
                Country = PubAdd.Country,
                City = PubAdd.City,
                CreationDate = PubAdd.ChangeDate,
                IDCreationUser = PubAdd.ChangeUser

            };
            _publisherRepository.Save(pub);
            return Created("Object Created", pub);
        }

        // PUT api/<PublisherController>/5
        [HttpPut("UpdatePublisher")]
        public IActionResult Put([FromBody] PublisherUpdateModel EmpUpdate)
        {
            Publisher ExistPub = _publisherRepository.GetEntityByID(EmpUpdate.PubID);

            //Validacion de (Pub si existe)
            if (ExistPub == null)
            {
                return NotFound();
            }

            ExistPub.PubID = EmpUpdate.PubID;
            ExistPub.PubName = EmpUpdate.PubName;
            ExistPub.State = EmpUpdate.State;
            ExistPub.Country = EmpUpdate.Country;
            ExistPub.City = EmpUpdate.City;
            ExistPub.CreationDate = EmpUpdate.ChangeDate;
            ExistPub.IDCreationUser = EmpUpdate.ChangeUser;

            _publisherRepository.Update(ExistPub);

            return Ok();
        }
    }
}

