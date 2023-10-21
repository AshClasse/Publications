using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? Minit { get; set; }
        public int JobID { get; set; }
        public int? Joblvl { get; set; }
        public int PubID { get; set; }
        public DateTime HireDate { get; set; }

    }
}
