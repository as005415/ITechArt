using System.Collections.Generic;

namespace WebApplication.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}