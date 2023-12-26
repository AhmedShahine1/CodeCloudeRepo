using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace CodeCloude.Models
{
    public class EditeProfileModel
    {
        public string? Id { get; set; }

        public string? Email { get; set; }
        public string? username { get; set; }
        public IFormFile? Photo { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? NewPassword { get; set; }
        public string? OldPassword { get; set; }
        public string? Country { get; set; }
        public bool? Gender { get; set; }


        public int CountryId { get; set; }

    }
}
