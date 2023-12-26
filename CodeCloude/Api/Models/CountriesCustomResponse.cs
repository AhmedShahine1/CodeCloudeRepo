using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class CountriesCustomResponse : CustomResponse
    {
        public IEnumerable<CountriesVM> Records { get; set; }
        public CountriesVM Record { get; set; }
    }
}