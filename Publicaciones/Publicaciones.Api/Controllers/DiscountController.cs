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

        [HttpGet("GetDiscount")]
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
            this._discountRepository.Save(new Discount()
            {
                DiscountType = discountAdd.DiscountType,
                StoreID = discountAdd.StoreID,
                LowQty = discountAdd.LowQty,
                HighQty = discountAdd.HighQty,
                DiscountAmount = discountAdd.DiscountAmount,
                CreationDate = discountAdd.ChangeDate,
                IDCreationUser = discountAdd.ChangeUser
            }
                );

            return Ok();
        }

        [HttpPut("UpdateDiscount")]
        public IActionResult Put([FromBody] DiscountUpdateModel discountUpdate)
        {
            this._discountRepository.Update(new Discount()
            {
                DiscountID = discountUpdate.DiscountID,
                DiscountType = discountUpdate.DiscountType,
                StoreID = discountUpdate.StoreID,
                LowQty = discountUpdate.LowQty,
                HighQty = discountUpdate.HighQty,
                DiscountAmount = discountUpdate.DiscountAmount,
                ModifiedDate = discountUpdate.ChangeDate,
                IDModifiedUser = discountUpdate.ChangeUser
            }
                );

            return Ok();
        }
    }
}
