using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class LogInCustomResponse 
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Token { get; set; }
    }
}