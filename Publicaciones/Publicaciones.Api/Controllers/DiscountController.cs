using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Discount;

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService discountService;
        public DiscountController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        [HttpGet("GetDiscounts")]
        public IActionResult GetDiscounts()
        {
            var result = this.discountService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetDiscountByID")]
        public IActionResult GetDiscountByID(int discountID)
        {
            var result = this.discountService.GetByID(discountID);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveDiscount")]
        public IActionResult Post([FromBody] DiscountDtoAdd discountAdd)
        {
            var result = this.discountService.Save(discountAdd);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateDiscount")]
        public IActionResult Put([FromBody] DiscountDtoUpdate discountUpdate)
        {
            var result = this.discountService.Update(discountUpdate);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveDiscount")]
        public IActionResult Remove([FromBody] DiscountDtoRemove discountRemove)
        {
            var result = this.discountService.Remove(discountRemove);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
