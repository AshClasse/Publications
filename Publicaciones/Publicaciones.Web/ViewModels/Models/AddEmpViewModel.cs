namespace Publicaciones.Web.ViewModels.Models
{
    public class AddEmpViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Joblvl { get; set; }
        public DateTime HireDate { get; set; }
        public int PubID { get; set; }
        public int JobID { get; set; }
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
