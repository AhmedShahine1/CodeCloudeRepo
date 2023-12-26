
using CodeCloude.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace CodeCloude.Extend
{
     public class ApplicationUser:IdentityUser
    {
        public string? FullName { get; set; }
        public string? ImgUrl { get; set; }

        public bool? Gender { get; set; }

        public int Count_Id { get; set; }
        public bool IsSubscribed { get; set; } = false;
        public String? SubscriptionName { get; set; }
    }
}
