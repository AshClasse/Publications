using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Dtos.Base
{
    public class RoySchedDtoBase : DtoBase
    {
        public int Title_ID { get; set; }
        public int? LoRange { get; set; }
        public int? HiRange { get; set; }
        public int? Royalty { get; set; }
    }
}
