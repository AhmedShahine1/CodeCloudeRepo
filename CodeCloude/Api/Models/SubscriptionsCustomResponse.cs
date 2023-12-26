using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class SubscriptionsCustomResponse : CustomResponse
    {
        public IEnumerable<SubscriptionsVM> Records { get; set; }
        public SubscriptionsVM Record { get; set; }
    }
}