using System.Collections.Generic;

namespace Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
    }
}