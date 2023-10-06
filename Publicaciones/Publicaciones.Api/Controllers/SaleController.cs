using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;

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
        // GET: api/<SaleController>
        [HttpGet]
        public IEnumerable<Sale> Get()
        {
            var sales = this._saleRepository.GetSales();
            return sales;
        }

        // GET api/<SaleController>/5
        [HttpGet("{storeID}/{ordNum}/{titleID}")]
        public Sale Get(string storeID, string ordNum, string titleID)
        {
            return this._saleRepository.GetSaleByID(storeID, ordNum, titleID);
        }

        // POST api/<SaleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SaleController>/5
        [HttpPut("{ID}")]
        public void Put(int ID, [FromBody] string value)
        {
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
        }
    }
}
