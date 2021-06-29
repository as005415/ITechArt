using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class RegisterModel
    {
        [Required] public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}