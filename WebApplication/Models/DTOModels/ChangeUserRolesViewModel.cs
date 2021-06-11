using System.Collections.Generic;

namespace WebApplication.Models.DTOModels
{
    public class ChangeUserRolesViewModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}