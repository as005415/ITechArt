using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using WebApplication.Models.DTOModels;

namespace WebApplication.Repository
{
    public interface IRepository
    {
        Task<PersonNumberViewModel> GetPersonNumberByCredential(PersonNumberViewModel personCredential);
        Task<AddRequestViewModel> AddPersonRequestWithData(AddRequestViewModel viewModel);
        Task<Person> GetPersonByCredential(Person person);
        Task<Estate> GetEstateByCredential(Estate estate);
        Task<ICollection<PersonsRequestsViewModel>> GetAllPersonRequestInProgress();
        Task AddPerson(Person person);
        Task AddEstate(Estate estate);
        Task AddPersonRequest(PersonRequest personRequest);
        Task<PersonsRequestsViewModel> EditPersonRequestState(PersonsRequestsViewModel viewModel);


        IEnumerable<User> GetAllUsersOnlyWithRoles();
        IEnumerable<string> GetUserRolesByUsername(string username);
        IEnumerable<Person> GetAllPersons();
    }
}