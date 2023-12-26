using CodeCloude.Data.Entities;

namespace CodeCloude.Models
{
    public class CountriesVM: Countries
    {
        public IFormFile Photo { get; set; }
    }
}
