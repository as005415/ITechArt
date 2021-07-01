using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class QueueRepository : GenericRepository<Queue>, IQueueRepository
    {
        public QueueRepository(Context context) : base(context)
        {
        }
    }
}