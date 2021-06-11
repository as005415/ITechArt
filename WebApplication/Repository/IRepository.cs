using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models.DbModels;
using WebApplication.Models.DTOModels;

namespace WebApplication.Repository
{
    public interface IRepository
    {
        Task<PersonNumberViewModel> GetPersonNumberByCredential(PersonNumberViewModel personCredential);
        Task<AddRequestViewModel> AddPersonRequestWithData(AddRequestViewModel viewModel);
        Task<Persons> GetPersonByCredential(Persons person);
        Task<Estate> GetEstateByCredential(Estate estate);
        Task<ICollection<PersonsRequestsViewModel>> GetAllPersonRequestInProgress();
        Task AddPerson(Persons person);
        Task AddEstate(Estate estate);
        Task AddPersonRequest(PersonRequests personRequest);
        Task<PersonsRequestsViewModel> EditPersonRequestState(PersonsRequestsViewModel viewModel);


        IEnumerable<User> GetAllUsersOnlyWithRoles();
        IEnumerable<string> GetUserRolesByUsername(string username);
        IEnumerable<Persons> GetAllPersons();
    }
}