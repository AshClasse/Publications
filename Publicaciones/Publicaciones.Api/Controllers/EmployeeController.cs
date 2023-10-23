using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Api.Models.Employee_Module;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }

        [HttpGet("GetEmployeeByPubID")]
        public IActionResult GetEmployeeByPubID(int ID)
        {
            var employee = _employeeRepository.GetEmployeeByPubID(ID);
            return Ok(employee);
        }

        [HttpGet("GetEmployeesByJobID")]
        public IActionResult GetEmployeeByJobID (int ID)
        {
            var employee = _employeeRepository.GetEmployeeByJobID(ID);
            return Ok(employee);
        }

        // GET: api/<EmployeeController>
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetEntities().Select(EmpGet => new EmployeeGetModel() 
            {
                EmpID = EmpGet.EmpID,
                JobID = EmpGet.JobID,
                PubID = EmpGet.PubID,
                FirstName = EmpGet.FirstName,
                LastName = EmpGet.LastName,
                ChangeDate = EmpGet.CreationDate,
                ChangeUser = EmpGet.IDCreationUser,
                HireDate = EmpGet.HireDate,
                Joblvl = EmpGet.Joblvl,
                Minit = EmpGet.Minit
            }).ToList();

            return Ok(employees);
        }

        // GET api/<EmployeeControler>/5
        [HttpGet("GetEmployeeByID")]
        public IActionResult GetEmployeesByID (int ID)
        {
            var EmpGet = this._employeeRepository.GetEntityByID(ID);

            EmployeeGetModel employeeGetM = new EmployeeGetModel()
            {
                EmpID = EmpGet.EmpID,
                JobID = EmpGet.JobID,
                PubID = EmpGet.PubID,
                FirstName = EmpGet.FirstName,
                LastName = EmpGet.LastName,
                ChangeDate = EmpGet.CreationDate,
                ChangeUser = EmpGet.IDCreationUser,
                HireDate = EmpGet.HireDate,
                Joblvl = EmpGet.Joblvl,
                Minit = EmpGet.Minit
            };
            return Ok(employeeGetM);
        }

        // POST api/<EmployeeController>
        [HttpPost("SaveEmployee")]
        public IActionResult Post([FromBody] EmployeeAddModel EmpAdd)
        {
            Employee employee = new Employee()
            {
                FirstName = EmpAdd.FirstName,
                LastName = EmpAdd.LastName,
                PubID = EmpAdd.PubID,
                Minit = EmpAdd.Minit,
                HireDate = EmpAdd.HireDate,
                JobID = EmpAdd.JobID,
                Joblvl = EmpAdd.Joblvl,
                CreationDate = EmpAdd.ChangeDate,
                IDCreationUser = EmpAdd.ChangeUser
            };
            _employeeRepository.Save(employee);
            return Created("Object Created",employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("UpdateEmployee")]
        public IActionResult Put([FromBody] EmployeeUpdateModel EmpUpdate)
        {
            Employee ExistEmp = _employeeRepository.GetEntityByID(EmpUpdate.PubID);

            if(ExistEmp == null)
            {
                return NoContent();
            }

            ExistEmp.EmpID = EmpUpdate.EmpID;
            ExistEmp.FirstName = EmpUpdate.FirstName;
            ExistEmp.LastName = EmpUpdate.LastName;
            ExistEmp.PubID = EmpUpdate.PubID;
            ExistEmp.Minit = EmpUpdate.Minit;
            ExistEmp.HireDate = EmpUpdate.HireDate;
            ExistEmp.JobID = EmpUpdate.JobID;
            ExistEmp.CreationDate = EmpUpdate.ChangeDate;
            ExistEmp.Joblvl = EmpUpdate.Joblvl;
            ExistEmp.IDCreationUser = EmpUpdate.ChangeUser;

            this._employeeRepository.Update(ExistEmp);
            return Ok();
        }
    }
}
