using System;
using Publicaciones.Application.DTO.BasesDto;

namespace Publicaciones.Application.DTO.Employee
{
    public class EmployeeDtoBase : DtoBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? Minit { get; set; }
        public int? Joblvl { get; set; }
        public DateTime HireDate { get; set; }
        public int PubID { get; set; }
        public int JobID { get; set; }
    }
}

