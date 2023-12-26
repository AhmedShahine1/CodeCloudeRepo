using System;
using System.ComponentModel.DataAnnotations;

namespace CodeCloude.Models
{
    public class registerationVM
    {
        //[Required(ErrorMessage = "Name Is Required")]
        //public string? Name { get; set; }
        //public string? phoneNumber { get; set; }
      
        //[Required]
        //public DateTime? birthDate { get; set; }
        //[Required]

        //public bool? gender { get; set; }


        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="You must Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="Min length 3")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min length 3")]
        [Compare("Password")]
        [Display(Name = "confirm Password")]
        public string confirmPassword { get; set; }
        public int CountryId { get; set; }
    }
}
