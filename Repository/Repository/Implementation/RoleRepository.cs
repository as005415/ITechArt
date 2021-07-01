using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(Context context) : base(context)
        {
        }
    }
}