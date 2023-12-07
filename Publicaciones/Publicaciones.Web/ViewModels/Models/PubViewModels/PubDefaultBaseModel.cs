namespace Publicaciones.Web.ViewModels.Models.PubViewModels
{
    public class PubDefaultBaseModel
    {
        public int PubID { get; set; }
        public string PubName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
