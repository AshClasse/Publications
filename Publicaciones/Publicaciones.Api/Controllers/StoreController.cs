using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Store;

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        [HttpGet("GetStores")]
        public IActionResult GetStores() 
        {
            var result = this.storeService.GetAll();

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetStoreByID")]
        public IActionResult GetStoreByID(int storeID)
        {
            var result = this.storeService.GetByID(storeID);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveStore")]
        public IActionResult Post([FromBody] StoreDtoAdd storeAdd)
        {
            var result = this.storeService.Save(storeAdd);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateStore")]
        public IActionResult Put([FromBody] StoreDtoUpdate storeUpdate)
        {
            var result = this.storeService.Update(storeUpdate);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveStore")]
        public IActionResult Remove([FromBody] StoreDtoRemove storeRemove)
        {
            var result = this.storeService.Remove(storeRemove);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
