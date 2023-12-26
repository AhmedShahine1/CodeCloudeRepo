using CodeCloude.Data.Entities;
using System.Diagnostics.Metrics;

namespace CodeCloude.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string  Email { get; set; }
        public string  userNAme { get; set; }
        public string Phone { get; set; }
        public string? ImgUrl { get; set; }
        public bool? Gender { get; set; }
        public int? CountryId { get; set; }
    }
}
