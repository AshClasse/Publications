using Microsoft.AspNetCore.Mvc;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Domain.Entities;
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
        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            var publishers = _publisherRepository.GetEntities();
            return publishers;
        }

        // GET api/<PublisherController>/5
        [HttpGet("{ID}")]
        public Publisher Get(int ID)
        {
            var publisher = _publisherRepository.GetEntityByID(ID);
            return publisher;
        }

        // POST api/<PublisherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
