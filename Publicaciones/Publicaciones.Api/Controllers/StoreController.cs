using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Module_Store;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

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

        [HttpGet("GetStores")]
        public IActionResult GetStores() 
        { 
            var stores = this._storeRepository.GetEntities().Select(st => new StoreGetAllModel()
            {
                StoreID = st.StoreID,
                ChangeDate = st.CreationDate,
                ChangeUser = st.IDCreationUser,
                StoreName = st.StoreName,
                StoreAddress = st.StoreAddress,
                City = st.City,
                State = st.State,
                Zip = st.Zip
            }
            ).ToList();

            return Ok(stores);
        }

        [HttpGet("GetStore")]
        public IActionResult GetStore(int storeID)
        {
            var store = this._storeRepository.GetEntityByID(storeID);
            return Ok(store);
        }

        [HttpPost("SaveStore")]
        public IActionResult Post([FromBody] StoreAddModel storeAdd)
        {
            Store store = new Store()
            {
                CreationDate = storeAdd.ChangeDate,
                IDCreationUser = storeAdd.ChangeUser,
                StoreName = storeAdd.StoreName,
                StoreAddress = storeAdd.StoreAddress,
                City = storeAdd.City,
                State = storeAdd.State,
                Zip = storeAdd.Zip
            };

            this._storeRepository.Save(store);

            return Ok();
        }

        [HttpPut("UpdateStore")]
        public IActionResult Put([FromBody] StoreUpdateModel storeUpdate)
        {
            Store store = new Store()
            {
                StoreID = storeUpdate.StoreID,
                CreationDate = storeUpdate.ChangeDate,
                IDCreationUser = storeUpdate.ChangeUser,
                StoreName = storeUpdate.StoreName,
                StoreAddress = storeUpdate.StoreAddress,
                City = storeUpdate.City,
                State = storeUpdate.State,
                Zip = storeUpdate.Zip
            };

            this._storeRepository.Update(store);

            return Ok();
        }
    }
}
