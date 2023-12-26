
using System.ComponentModel.DataAnnotations;

namespace CodeCloude.Models
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
