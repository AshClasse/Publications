using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? Minit { get; set; }
        public short JobID { get; set; }
        public byte? Joblvl { get; set; }
        public char PubID { get; set; }
        public DateTime HireDate { get; set; }

    }
}
