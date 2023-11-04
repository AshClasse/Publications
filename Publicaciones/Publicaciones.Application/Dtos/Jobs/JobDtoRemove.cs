namespace Publicaciones.Application.DTO.Jobs
{
    public class JobDtoRemove : JobsDtoBase
    {
        public int JobID { get; set;}
        public bool Deleted { get; set;}
    }
}
