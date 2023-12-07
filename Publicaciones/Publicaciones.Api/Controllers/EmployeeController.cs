using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.DTO.Employee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            this._employeeService = _employeeService;
        }

        // GETEMPBYID ENDPOINT
        [HttpGet("GetEmployeesByID")]
        public IActionResult GetEmployeesByID(int ID)
        {
            var result = _employeeService.GetByID(ID);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        //GETEMP ENDPOINT
        [HttpGet("GetEmployees")]

        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        //SAVE_EMP ENDPOINT
        [HttpPost("SaveEmployee")]

        public IActionResult SaveEmployees([FromBody] EmployeeDtoAdd empdtoadd)
        {
            var result = _employeeService.Save(empdtoadd);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        //UPDATE_ENDPOINT
        [HttpPost("UpdateEmployees")]

        public IActionResult UpdateEmployees([FromBody] EmployeeDtoUpdate empdtoupdate)
        {
            var result = _employeeService.Update(empdtoupdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        //DELETE_ENDPOINT
        [HttpPost("DeleteEmployees")]

        public IActionResult RemoveEmployees([FromBody] EmployeeDtoRemove empdtoremove)
        {
            var result = _employeeService.Remove(empdtoremove);

            if (!result.Success)
                return BadRequest();

            return Ok(result);
        }

    }
}