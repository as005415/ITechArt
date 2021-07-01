using System.Threading.Tasks;
using Domain;
using Repository.Repository;

namespace Repository.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(
            IRoleRepository roleRepository,
            IUserRepository userRepository,
            IQueueRepository queueRepository,
            IPersonRequestRepository personRequestRepository,
            IPersonRepository personRepository,
            IPermissionRepository permissionRepository,
            INormRepository normRepository,
            IEstateRepository estateRepository,
            Context context)
        {
            RoleRepository = roleRepository;
            UserRepository = userRepository;
            QueueRepository = queueRepository;
            PersonRequestRepository = personRequestRepository;
            PersonRepository = personRepository;
            PermissionRepository = permissionRepository;
            NormRepository = normRepository;
            EstateRepository = estateRepository;
            _context = context;
        }

        public IEstateRepository EstateRepository { get; }
        public INormRepository NormRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IPersonRequestRepository PersonRequestRepository { get; }
        public IQueueRepository QueueRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}