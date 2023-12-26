using System.ComponentModel.DataAnnotations;

namespace CodeCloude.Api.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required, StringLength(128)]
        public string? Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public int CuntryId { get; set; }

        public bool? Gender { get; set; }




    }
}
