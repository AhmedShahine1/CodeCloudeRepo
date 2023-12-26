using System.ComponentModel.DataAnnotations;

namespace CodeCloude.Models
{
   public class loginVM
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "You must Enter V alid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min length 3")]
        public string Password { get; set; }

        //public bool? RememberMe { get; set; }
    }
}
