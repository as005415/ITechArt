using Domain;
using Domain.Models;
using Repository.GenericRepository.Implementation;

namespace Repository.Repository.Implementation
{
    public class PersonRepository : GenericRepository<Person>,IPersonRepository
    {
        public PersonRepository(Context context) : base(context)
        {
        }
    }
}