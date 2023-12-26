using CodeCloude.Data.Entities;

namespace CodeCloude.Models
{
    public class StoresVM: Stores
    {
        public int? User_Faviourite_Id { get; set; }
        public IFormFile Photo { get; set; }
    }
}
