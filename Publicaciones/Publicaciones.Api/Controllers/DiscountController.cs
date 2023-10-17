using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Module_Discount;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountController(IDiscountRepository discountRepository)
        {
            this._discountRepository = discountRepository;
        }

        [HttpGet("GetDiscounts")]
        public IActionResult GetDiscounts()
        {
            var discounts = this._discountRepository.GetEntities().Select(d => new DiscountGetAllModel()
            {
                DiscountID = d.DiscountID,
                ChangeDate = d.CreationDate,
                ChangeUser = d.IDCreationUser,
                DiscountAmount = d.DiscountAmount,
                DiscountType = d.DiscountType,
                HighQty = d.HighQty,
                LowQty = d.LowQty,
                StoreID = d.StoreID
            }).ToList();

            return Ok(discounts);
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int discountID)
        {
            var discounts = this._discountRepository.GetEntityByID(discountID);
            return Ok(discounts);
        }

        [HttpGet("GetDiscountByStoreID")]
        public IActionResult GetDiscountByStoreID(int storeID)
        {
            var discounts = this._discountRepository.GetDiscountsByStore(storeID);
            return Ok(discounts);
        }

        [HttpPost("SaveDiscount")]
        public IActionResult Post([FromBody] DiscountAddModel discountAdd)
        {
            Discount discount = new Discount()
            {
                CreationDate = discountAdd.ChangeDate,
                IDCreationUser = discountAdd.ChangeUser,
                DiscountAmount = discountAdd.DiscountAmount,
                DiscountType = discountAdd.DiscountType,
                HighQty = discountAdd.HighQty,
                LowQty = discountAdd.LowQty,
                StoreID = discountAdd.StoreID
            };

            this._discountRepository.Save(discount);

            return Ok(discount);
        }

        [HttpPut("UpdateDiscount")]
        public IActionResult Put([FromBody] DiscountUpdateModel discountUpdate)
        {
            Discount discount = new Discount()
            {
                DiscountID = discountUpdate.DiscountID,
                CreationDate = discountUpdate.ChangeDate,
                IDCreationUser = discountUpdate.ChangeUser,
                DiscountAmount = discountUpdate.DiscountAmount,
                DiscountType = discountUpdate.DiscountType,
                HighQty = discountUpdate.HighQty,
                LowQty = discountUpdate.LowQty,
                StoreID = discountUpdate.StoreID
            };

            this._discountRepository.Update(discount);

            return Ok();
        }
    }
}
