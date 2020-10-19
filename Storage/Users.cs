using System.Collections.Generic;

namespace Storage
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public ICollection<UsersPersonRequests> UsersPersonRequests { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}