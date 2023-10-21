using Microsoft.AspNetCore.Mvc;
using Publicaciones.Api.Models.Module_Sale;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            this._saleRepository = saleRepository;
        }

        [HttpGet("GetSales")]
        public IActionResult GetSales()
        {
            var sales = this._saleRepository.GetEntities().Select(s => new SaleGetModel()
            {
                StoreID = s.StoreID,
                ChangeDate = s.CreationDate,
                ChangeUser = s.IDCreationUser,
                OrdNum = s.OrdNum,
                OrdDate = s.OrdDate,
                Qty = s.Qty,
                Payterms = s.Payterms,
                TitleID = s.TitleID
            }
            ).ToList();

            return Ok(sales);
        }

        // GET api/<SaleController>/5
        [HttpGet("GetSale")]
        public IActionResult GetSaleByID(int storeID, string ordNum, int titleID)
        {
            var sale = this._saleRepository.GetSaleByID(storeID, ordNum, titleID);

            SaleGetModel saleModel = new SaleGetModel()
            {
                StoreID = sale.StoreID,
                ChangeDate = sale.CreationDate,
                ChangeUser = sale.IDCreationUser,
                OrdNum = sale.OrdNum,
                OrdDate = sale.OrdDate,
                Qty = sale.Qty,
                Payterms = sale.Payterms,
                TitleID = sale.TitleID
            };

            return Ok(sale);
        }

        [HttpGet("GetSaleByStoreID")]
        public IActionResult GetSaleByStoreID(int storeID)
        {
            var sales = this._saleRepository.GetSaleByStore(storeID);
            return Ok(sales);
        }

        [HttpGet("GetSaleByOrdNumID")]
        public IActionResult GetSaleByOrdNum(string ordNum)
        {
            var sales = this._saleRepository.GetSaleByOrdNum(ordNum);
            return Ok(sales);
        }

        [HttpGet("GetSaleByTitleID")]
        public IActionResult GetSaleByTitleID(int titleID)
        {
            var sales = this._saleRepository.GetSaleByTitle(titleID);
            return Ok(sales);
        }

        [HttpPost("SaveSale")]
        public IActionResult Post([FromBody] SaleAddModel saleAdd)
        {
            this._saleRepository.Save(new Sale()
            {
               StoreID = saleAdd.StoreID,
               OrdNum = saleAdd.OrdNum,
               TitleID = saleAdd.TitleID,
               OrdDate = saleAdd.OrdDate,
               Qty = saleAdd.Qty,
               Payterms = saleAdd.Payterms,
               CreationDate = saleAdd.ChangeDate,
               IDCreationUser = saleAdd.ChangeUser
            }
                );

            return Ok();
        }

        [HttpPut("UpdateSale")]
        public IActionResult Put([FromBody] SaleUpdateModel saleUpdate)
        {
            this._saleRepository.Update(new Sale()
            {
                StoreID = saleUpdate.StoreID,
                OrdNum = saleUpdate.OrdNum,
                TitleID = saleUpdate.TitleID,
                OrdDate = saleUpdate.OrdDate,
                Qty = saleUpdate.Qty,
                Payterms = saleUpdate.Payterms,
                ModifiedDate = saleUpdate.ChangeDate,
                IDModifiedUser = saleUpdate.ChangeUser
            }
                );

            return Ok();
        }
    }
}
