using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class Terms_ConditionsCustomResponse : CustomResponse
    {
        public IEnumerable<Terms_ConditionsVM> Records { get; set; }
        public Terms_ConditionsVM Record { get; set; }
    }
}