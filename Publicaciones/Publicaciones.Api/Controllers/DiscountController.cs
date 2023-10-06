using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;

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
        // GET: api/<DiscountController>
        [HttpGet]
        public IEnumerable<Discount> Get()
        {
            return this._discountRepository.GetDiscounts();
        }

        // GET api/<DiscountController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<DiscountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DiscountController>/5
        [HttpPut("{ID}")]
        public void Put(int ID, [FromBody] string value)
        {
        }

        // DELETE api/<DiscountController>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
        }
    }
}
