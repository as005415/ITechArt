using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class PersonRequestRepository : GenericRepository<PersonRequest>, IPersonRequestRepository
    {
        public PersonRequestRepository(Context context) : base(context)
        {
        }
    }
}