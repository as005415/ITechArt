using System.Collections.Generic;

namespace WebApplication.Models.DbModels
{
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UsersRoles> UsersRoles { get; set; }
        public ICollection<RolesPermissions> RolesPermissions { get; set; }
    }
}