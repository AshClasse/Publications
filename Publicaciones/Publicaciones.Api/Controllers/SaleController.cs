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

        [HttpGet("GetSaleByStoreID")]
        public IActionResult GetSaleByStoreID(string storeID)
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
        public IActionResult GetSaleByTitleID(string titleID)
        {
            var sales = this._saleRepository.GetSaleByTitle(titleID);
            return Ok(sales);
        }

        [HttpGet("GetSales")]
        public IActionResult GetSales()
        {
            var sales = this._saleRepository.GetEntities().Select(s => new SaleGetAllModel()
            {
                ChangeDate = s.CreationDate,
                ChangeUser = s.IDCreationUser,
                OrdNum = s.OrdNum,
                OrdDate = s.OrdDate,
                Payterms = s.Payterms,
                Qty = s.Qty,
                StoreID = s.StoreID,
                TitleID = s.TitleID
            }
            ).ToList();

            return Ok(sales);
        }

        // GET api/<SaleController>/5
        [HttpGet("GetSale")]
        public IActionResult GetSale(string storeID, string ordNum, string titleID)
        {
            var sale = this._saleRepository.GetSaleByID(storeID, ordNum, titleID);
            return Ok(sale);
        }

        [HttpPost("SaveSale")]
        public IActionResult Post([FromBody] SaleAddModel saleAdd)
        {
            Sale sale = new Sale()
            {
                CreationDate = saleAdd.ChangeDate,
                IDCreationUser = saleAdd.ChangeUser,
                OrdNum = saleAdd.OrdNum,
                OrdDate = saleAdd.OrdDate,
                Payterms = saleAdd.Payterms,
                Qty = saleAdd.Qty,
                StoreID = saleAdd.StoreID,
                TitleID = saleAdd.TitleID
            };

            this._saleRepository.Save(sale);

            return Ok(sale);
        }

        [HttpPut("UpdateSale")]
        public IActionResult Put([FromBody] SaleUpdateModel saleUpdate)
        {
            Sale sale = new Sale()
            {
                StoreID = saleUpdate.StoreID,
                OrdNum = saleUpdate.OrdNum,
                TitleID = saleUpdate.TitleID,
                CreationDate = saleUpdate.ChangeDate,
                IDCreationUser = saleUpdate.ChangeUser,
                OrdDate = saleUpdate.ChangeDate,
                Payterms = saleUpdate.Payterms,
                Qty = saleUpdate.Qty
            };

            this._saleRepository.Save(sale);

            return Ok(sale);
        }
    }
}
