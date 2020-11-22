using Storage;

namespace WebApplication.Repository
{
    public class Repository : IRepository
    {
        private readonly StorageContext _context;

        public Repository(StorageContext context)
        {
            _context = context;
        }
    }
}