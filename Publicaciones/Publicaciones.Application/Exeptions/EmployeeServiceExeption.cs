using System;

namespace Publicaciones.Application.Exeptions
{
    public class EmployeeServiceExeption : Exception
    {
        public EmployeeServiceExeption( string message) : base(message) {}
    }
}
