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
        private readonly ISaleRepository saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }
        // GET: api/<SaleController>
        [HttpGet]
        public IEnumerable<Sale> Get()
        {
            var sales = this.saleRepository.GetSales();
            return sales;
        }

        // GET api/<SaleController>/5
        [HttpGet("{storId}/{ordNum}/{titleId}")]
        public Sale Get(string storId, string ordNum, string titleId)
        {
            return this.saleRepository.GetSaleByID(storId, ordNum, titleId);
        }

        // POST api/<SaleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
