using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class FaviouritesCustomResponse : CustomResponse
    {
        public IEnumerable<User_FaviouritesVM> Records { get; set; }
        public IEnumerable<StoresVM> newRecords { get; set; }
        public User_FaviouritesVM Record { get; set; }
    }
}
