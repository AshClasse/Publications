namespace Publicaciones.Web.ViewModels.Models.JobViewModels
{
    public class JobDeleteViewModel
    {
        public int JobID { get; set; }
        public bool Deleted { get; set; }
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
