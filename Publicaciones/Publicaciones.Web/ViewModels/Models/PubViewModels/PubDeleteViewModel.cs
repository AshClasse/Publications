namespace Publicaciones.Web.ViewModels.Models.PubViewModels
{
    public class PubDeleteViewModel
    {
        public int PubID { get; set; }
        public bool Deleted { get; set; }
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
