﻿namespace Storage
{
    public class UsersRoles
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public Users User { get; set; }
        
        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}