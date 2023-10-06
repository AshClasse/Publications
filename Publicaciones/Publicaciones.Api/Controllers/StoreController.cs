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
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }

        // GET: api/<StoreController>
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            var stores = this._storeRepository.GetStores();
            return stores;
        }

        // GET api/<StoreController>/5
        [HttpGet("{ID}")]
        public Store Get(string ID)
        {
            return this._storeRepository.GetStoreByID(ID);
        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StoreController>/5
        [HttpPut("{ID}")]
        public void Put(int ID, [FromBody] string value)
        {
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
        }
    }
}
