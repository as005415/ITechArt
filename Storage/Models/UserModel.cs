using System.Collections.Generic;

namespace Storage.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public ICollection<UsersPersonRequests> UsersPersonRequests { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}