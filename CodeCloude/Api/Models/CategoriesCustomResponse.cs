using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class CategoriesCustomResponse : CustomResponse
    {
        public IEnumerable<CategoriesVM> Records { get; set; }
        public CategoriesVM Record { get; set; }
    }
}
