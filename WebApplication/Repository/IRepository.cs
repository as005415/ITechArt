using System.Collections.Generic;
using Storage.Models;

namespace WebApplication.Repository
{
    public interface IRepository
    {
        IEnumerable<UserModel> GetAllUsersOnlyWithRoles();
        IEnumerable<string> GetUserRolesByUsername(string username);
    }
}