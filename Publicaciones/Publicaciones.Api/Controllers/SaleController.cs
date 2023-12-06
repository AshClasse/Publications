using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Sale;

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet("GetSales")]
        public IActionResult GetSales()
        {
            var result = this.saleService.GetAll();

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<SaleController>/5
        [HttpGet("GetSaleByID")]
        public IActionResult GetSaleByID(int storeID, string ordNum, int titleID)
        {
            var result = this.saleService.GetSaleByID(storeID, ordNum, titleID);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveSale")]
        public IActionResult Post([FromBody] SaleDtoAdd saleAdd)
        {
            var result = this.saleService.Save(saleAdd);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateSale")]
        public IActionResult Put([FromBody] SaleDtoUpdate saleUpdate)
        {
            var result = this.saleService.Update(saleUpdate);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveSale")]
        public IActionResult Remove([FromBody] SaleDtoRemove saleRemove) 
        {
            var result = this.saleService.Remove(saleRemove);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
