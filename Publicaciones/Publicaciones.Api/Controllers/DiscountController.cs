using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Module_Discount;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

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
            var discounts = this._discountRepository.GetEntities().Select(d => new DiscountGetModel()
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

        [HttpGet("GetDiscountByID")]
        public IActionResult GetDiscountByID(int discountID)
        {
            var discount = this._discountRepository.GetEntityByID(discountID);
            
            DiscountGetModel discountModel = new DiscountGetModel() 
            {
                DiscountID = discount.DiscountID,
                DiscountType = discount.DiscountType,
                ChangeDate = discount.CreationDate,
                ChangeUser = discount.IDCreationUser,
                StoreID = discount.StoreID,
                LowQty = discount.HighQty,
                HighQty = discount.LowQty,
                DiscountAmount = discount.DiscountAmount
            };

            return Ok(discount);
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
                DiscountType = discountAdd.DiscountType,
                StoreID = discountAdd.StoreID,
                LowQty = discountAdd.LowQty,
                HighQty = discountAdd.HighQty,
                DiscountAmount = discountAdd.DiscountAmount,
                CreationDate = discountAdd.ChangeDate,
                IDCreationUser = discountAdd.ChangeUser
            };
            this._discountRepository.Save(discount);
            return Created("Object Created", discount);
        }

        [HttpPut("UpdateDiscount")]
        public IActionResult Put([FromBody] DiscountUpdateModel discountUpdate)
        {
            Discount discount = new Discount()
            {
                DiscountID = discountUpdate.DiscountID,
                DiscountType = discountUpdate.DiscountType,
                StoreID = discountUpdate.StoreID,
                LowQty = discountUpdate.LowQty,
                HighQty = discountUpdate.HighQty,
                DiscountAmount = discountUpdate.DiscountAmount,
                ModifiedDate = discountUpdate.ChangeDate,
                IDModifiedUser = discountUpdate.ChangeUser
            };
            this._discountRepository.Update(discount);
            return Ok();
        }
    }
}
