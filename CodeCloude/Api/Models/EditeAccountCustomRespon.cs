using CodeCloude.API.Models;

namespace CodeCloude.Api.Models
{
    public class EditeAccountCustomRespon:CustomResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
