namespace Publicaciones.Web.ViewModels.Models.JobViewModels
{
    public class JobDefaultViewModel
    {
        public int JobID { get; set; }
        public string JobDescription { get; set; }
        public byte Minlvl { get; set; }
        public byte Maxlvl { get; set; }
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
