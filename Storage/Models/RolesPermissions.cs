namespace Storage.Models
{
    public class RolesPermissions
    {
        public int Id { get; set; }
        
        public int RoleId { get; set; }
        public Roles Role { get; set; }
        
        public int PermissionId { get; set; }
        public Permissions Permission { get; set; }
    }
}