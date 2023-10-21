using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Repository;
using Publicaciones.Domain.Entities;
using System.Reflection.Metadata.Ecma335;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Api.Models.Employee_Module;
using System;

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
        [HttpGet("GetEmplopyeeByID")]
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
            return Ok(EmpGet);
        }

        // POST api/<EmployeeController>
        [HttpPost("EmployeeCreation")]
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
                CreationDate = EmpAdd.ChangeDate,
                IDCreationUser = EmpAdd.ChangeUser
            };
            return Created("Object Created",employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("UpdateEmployee")]
        public IActionResult Put(int ID, [FromBody] EmployeeUpdateModel EmpUpdate)
        {
            Employee ExistEmp = _employeeRepository.GetEntityByID(ID);

            if(ExistEmp == null)
            {
                return NotFound();
            }

            ExistEmp.FirstName = EmpUpdate.FirstName;
            ExistEmp.LastName = EmpUpdate.LastName;
            ExistEmp.PubID = EmpUpdate.PubID;
            ExistEmp.Minit = EmpUpdate.Minit;
            ExistEmp.HireDate = EmpUpdate.HireDate;
            ExistEmp.JobID = EmpUpdate.JobID;
            ExistEmp.CreationDate = EmpUpdate.ChangeDate;
            ExistEmp.IDCreationUser = EmpUpdate.ChangeUser;

            return NoContent();
        }
    }
}
