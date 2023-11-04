using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Dtos.Base
{
    public class Pub_InfoDtoBase : DtoBase
    {
        public byte[]? Logo { get; set; }
        public string? Pr_Info { get; set; }
    }
}
