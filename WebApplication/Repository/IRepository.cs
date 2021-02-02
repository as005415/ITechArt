using System.Collections.Generic;
using Storage.Models;

namespace WebApplication.Repository
{
    public interface IRepository
    {
        IEnumerable<Users> GetAllUsersOnlyWithRoles();
        IEnumerable<string> GetUserRolesByUsername(string username);
    }
}