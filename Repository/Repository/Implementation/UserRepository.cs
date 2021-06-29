using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}