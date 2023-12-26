using CodeCloude.API.Models;
using CodeCloude.Data.Entities;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class StoresCustomResponse : CustomResponse
    {
        public IEnumerable<StoresVM> Records { get; set; }
        public Stores Record { get; set; }
    }
}