using System.Collections.Generic;

namespace Domain.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string PermissionDescription { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }
    }
}