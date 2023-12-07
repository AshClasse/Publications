namespace Publicaciones.Web.ViewModels.Models.EmpViewModels
{
    public class EmpDeleteViewModel
    {
        public int EmpID { get; set; }
        public bool Deleted { get; set; }
        public int ChangeUser { get; set; } = 1;
        public DateTime ChangeDate { get; set; } = DateTime.Now;
    }
}
