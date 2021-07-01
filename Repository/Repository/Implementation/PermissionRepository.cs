using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(Context context) : base(context)
        {
        }
    }
}