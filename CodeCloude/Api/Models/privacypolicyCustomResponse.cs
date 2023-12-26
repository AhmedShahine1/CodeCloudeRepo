using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class privacypolicyCustomResponse : CustomResponse
    {
        public IEnumerable<privacypolicyVM> Records { get; set; }
        public privacypolicyVM Record { get; set; }
    }
}