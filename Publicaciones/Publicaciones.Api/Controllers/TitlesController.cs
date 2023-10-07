using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<TitlesController>
        [HttpGet]
        public IEnumerable<Titles> Get()
        {
            var titles = this._titlesRepository.GetTitles();
            return titles;
        }

        // GET api/<TitlesController>/5
        [HttpGet("{ID}")]
        public Titles Get(string ID)
        {
            return _titlesRepository.GetTitle(ID);
        }

        // POST api/<TitlesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TitlesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TitlesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
