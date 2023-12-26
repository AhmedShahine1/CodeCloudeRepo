using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class Addition_TermsCustomResponse : CustomResponse
    {
        public IEnumerable<Addition_TermsVM> Records { get; set; }
        public Addition_TermsVM Record { get; set; }
    }
}
