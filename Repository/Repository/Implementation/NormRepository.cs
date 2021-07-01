using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class NormRepository : GenericRepository<Norm>, INormRepository
    {
        public NormRepository(Context context) : base(context)
        {
        }
    }
}