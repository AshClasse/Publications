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
            var stores = this._storeRepository.GetEntities().Select(st => new StoreGetModel()
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
        public IActionResult GetStoreByID(int storeID)
        {
            var store = this._storeRepository.GetEntityByID(storeID);

            StoreGetModel storeModel = new StoreGetModel()
            {
                StoreID = store.StoreID,
                ChangeDate = store.CreationDate,
                ChangeUser = store.IDCreationUser,
                StoreName = store.StoreName,
                StoreAddress = store.StoreAddress,
                City = store.City,
                State = store.State,
                Zip = store.Zip
            };

            return Ok(store);
        }

        [HttpPost("SaveStore")]
        public IActionResult Post([FromBody] StoreAddModel storeAdd)
        {
            this._storeRepository.Save(new Store()
            {
                StoreName = storeAdd.StoreName,
                StoreAddress = storeAdd.StoreAddress,
                City = storeAdd.City,
                State = storeAdd.State,
                Zip = storeAdd.Zip,
                CreationDate = storeAdd.ChangeDate,
                IDCreationUser = storeAdd.ChangeUser
            }
                );

            return Ok();
        }

        [HttpPut("UpdateStore")]
        public IActionResult Put([FromBody] StoreUpdateModel storeUpdate)
        {
            this._storeRepository.Update(new Store()
            {
                StoreID = storeUpdate.StoreID,
                StoreName = storeUpdate.StoreName,
                StoreAddress = storeUpdate.StoreAddress,
                City = storeUpdate.City,
                State = storeUpdate.State,
                Zip = storeUpdate.Zip,
                CreationDate = storeUpdate.ChangeDate,
                IDCreationUser = storeUpdate.ChangeUser
            }
            );

            return Ok();
        }
    }
}
