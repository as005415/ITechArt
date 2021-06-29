﻿using System.Collections.Generic;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}