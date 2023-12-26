using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class SliderCustomResponse : CustomResponse
    {
        public IEnumerable<SliderVM> Records { get; set; }
        public SliderVM Record { get; set; }
    }
}