using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        // GET: api/<StoreController>
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            var stores = this.storeRepository.GetStores();
            return stores;
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public Store Get(string id)
        {
            return this.storeRepository.GetStoreByID(id);
        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
