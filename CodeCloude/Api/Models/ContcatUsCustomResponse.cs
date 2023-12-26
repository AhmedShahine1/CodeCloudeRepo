using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class ContcatUsCustomResponse : CustomResponse
    {
        public IEnumerable<ContcatUsVM> Records { get; set; }
        public ContcatUsVM Record { get; set; }
    }
}
