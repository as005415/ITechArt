﻿namespace Storage.Models
{
    public class UsersRoles
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
        
        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}