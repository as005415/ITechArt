using System.Threading.Tasks;
using Repository.Repository;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEstateRepository EstateRepository { get; }
        INormRepository NormRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IPersonRepository PersonRepository { get; }
        IPersonRequestRepository PersonRequestRepository { get; }
        IQueueRepository QueueRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}