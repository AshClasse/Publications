using System;

namespace Publicaciones.Application.Dtos
{
    public abstract class DtoBase
    {
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
