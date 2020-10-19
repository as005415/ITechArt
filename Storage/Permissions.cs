using System.Collections.Generic;

namespace Storage
{
    public class Permissions
    {
        public int Id { get; set; }
        public string PermissionDescription { get; set; }
        
        public ICollection<RolesPermissions> RolesPermissions { get; set; }
    }
}