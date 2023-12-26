using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class BankDetailsCustomResponse : CustomResponse
    {
        public IEnumerable<BankDetailsVM> Records { get; set; }
        public BankDetailsVM Record { get; set; }
    }
}