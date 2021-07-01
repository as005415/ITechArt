using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class EstateRepository : GenericRepository<Estate>, IEstateRepository
    {
        public EstateRepository(Context context) : base(context)
        {
        }
    }
}