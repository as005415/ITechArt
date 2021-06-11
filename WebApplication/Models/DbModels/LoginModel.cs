using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.DbModels
{
    public class LoginModel
    {
        [Required] public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}