using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Storage;
using Storage.Models;

namespace WebApplication.Repository
{
    public class Repository : IRepository
    {
        private readonly StorageContext _context;

        public Repository(StorageContext context)
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetAllUsersOnlyWithRoles()
        {
            var users =
                _context.Users.Include(x => x.UsersRoles).ThenInclude(x => x.Role).ToList();
            
            return users;
        }

        public IEnumerable<string> GetUserRolesByUsername(string username)
        {
            var data = _context.Users.Include(x => x.UsersRoles).ThenInclude(x => x.Role).ToList();
            var user = data.FirstOrDefault(x => x.Login == username);
            
            if (user == null) return new List<string>();

            var roles = user.UsersRoles.ToList().Select(role => role.Role.RoleName).ToList();

            return roles;
        }
    }
}