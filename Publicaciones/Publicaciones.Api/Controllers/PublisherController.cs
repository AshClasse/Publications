using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.DTO.Publishers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService _publisherService)
        {
            this._publisherService = _publisherService;
        }


        // GET: api/<PublisherController>
        [HttpGet("GetPublishers")]
        public IActionResult GetPublisher()
        {
            var result = _publisherService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<PublisherController>/5
        [HttpGet("GetPublisherID")]
        public IActionResult GetPublisherByID(int ID)
        {
            var result = _publisherService.GetByID(ID);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<PublisherController>
        [HttpPost("SavePublisher")]
        public IActionResult Post([FromBody] PublisherDtoAdd pubdtoadd)
        {
            var result = _publisherService.Save(pubdtoadd);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //UPDATE_ENDPOINT
        [HttpPost("UpdatePublisher")]
        public IActionResult Put(PublisherDtoUpdate pubdtoupdate)
        {
            var result = _publisherService.Update(pubdtoupdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //DELETE_ENDPOINT
        [HttpPost("DeletePublisher")]
        public IActionResult RemoveJobs([FromBody] PublisherDtoRemove PubDtoRemove)
        {
            var result = _publisherService.Remove(PubDtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

