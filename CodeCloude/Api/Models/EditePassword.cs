using Microsoft.Build.Framework;

namespace CodeCloude.Models
{
    public class EditePassword
    {
        public string? Id { get; set; }
        [Required]
        public string OldPaassword { get; set; }
        [Required]

        public string NewPassword { get; set; }
        [Required]

        public string ConfirmNewPassword { get; set; }
    }
}
