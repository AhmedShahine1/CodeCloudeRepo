using CodeCloude.Data.Entities;

namespace CodeCloude.Models
{
    public class CategoriesVM: Categories
    {
        public IFormFile Photo { get; set; }
    }
}
