using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? minit { get; set; }
        public int JobID { get; set; }
        public string? Joblvl { get; set; }
        public int PubID { get; set; }
        public DateTime HireDate { get; set; }

    }
}
