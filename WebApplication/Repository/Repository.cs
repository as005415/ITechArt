using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models.DTOModels;

namespace WebApplication.Repository
{
    public class Repository : IRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public Repository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonNumberViewModel> GetPersonNumberByCredential(PersonNumberViewModel personCredential)
        {
            var person = await GetPersonByCredential(_mapper.Map<Person>(personCredential));

            var personRequest = await _context.PersonRequests.FirstOrDefaultAsync(x =>
                x.Person == person && x.StateOfRequest == StateOfRequest.Approved);

            if (personRequest == null) return null;

            var queue = await _context.Queues.FirstOrDefaultAsync(x => x.PersonRequestsId == personRequest.Id);
            
            if (queue == null) return personCredential;
            
            personCredential.Number = queue.Number;
            personCredential.StateOfRequest = personRequest.StateOfRequest.ToString();

            return personCredential;
        }

        public async Task<AddRequestViewModel> AddPersonRequestWithData(AddRequestViewModel viewModel)
        {
            var estate = await GetEstateByCredential(_mapper.Map<Estate>(viewModel));
            var person = await GetPersonByCredential(_mapper.Map<Person>(viewModel));

            if (estate == null)
            {
                estate = _mapper.Map<Estate>(viewModel);
                await AddEstate(estate);
                estate = await GetEstateByCredential(estate);
            }

            if (person == null)
            {
                person = _mapper.Map<Person>(viewModel);
                person.Estate = estate;
                await AddPerson(person);
                person = await GetPersonByCredential(person);
            }

            var personRequest = await _context.PersonRequests.FirstOrDefaultAsync(x =>
                x.Person == person &&
                (x.StateOfRequest == StateOfRequest.Approved ||
                 x.StateOfRequest == StateOfRequest.Approved));

            if (personRequest == null)
            {
                personRequest = new PersonRequest
                {
                    DateTimeOfRequest = DateTime.Today,
                    StateOfRequest = StateOfRequest.InProgress,
                    Person = person
                };
                await AddPersonRequest(personRequest);
            }

            return viewModel;
        }

        public async Task<Person> GetPersonByCredential(Person person)
        {
            return await _context.Persons.FirstOrDefaultAsync(x =>
                x.PassportId == person.PassportId &&
                x.FirstName == person.FirstName &&
                x.LastName == person.LastName &&
                x.MiddleName == person.MiddleName
            );
        }

        public async Task<Estate> GetEstateByCredential(Estate estate)
        {
            return await _context.Estates.FirstOrDefaultAsync(x =>
                x.Address == estate.Address &&
                x.CommonArea == estate.CommonArea &&
                x.TypeOfProperty == estate.TypeOfProperty
            );
        }

        public async Task<ICollection<PersonsRequestsViewModel>> GetAllPersonRequestInProgress()
        {
            var personRequests = await _context.PersonRequests.Where(x=>
                x.StateOfRequest==StateOfRequest.InProgress).ToListAsync();

            await _context.Persons.ToListAsync();

            var viewModel = new List<PersonsRequestsViewModel>();

            foreach (var request in personRequests)
            {
                viewModel.Add(_mapper.Map<PersonsRequestsViewModel>(request.Person));
                viewModel[^1].StateOfRequest = request.StateOfRequest;
                viewModel[^1].DateTimeOfRequest = request.DateTimeOfRequest;
            }

            return viewModel;
        }

        public async Task AddPerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task AddEstate(Estate estate)
        {
            await _context.Estates.AddAsync(estate);
            await _context.SaveChangesAsync();
        }

        public async Task AddPersonRequest(PersonRequest personRequest)
        {
            await _context.PersonRequests.AddAsync(personRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonsRequestsViewModel> EditPersonRequestState(PersonsRequestsViewModel viewModel)
        {
            var person = await GetPersonByCredential(_mapper.Map<Person>(viewModel));
            var personRequest = await _context.PersonRequests.FirstOrDefaultAsync(x =>
                x.Person == person);

            if (personRequest == null) return null;

            switch (personRequest.StateOfRequest)
            {
                case StateOfRequest.InProgress when (viewModel.StateOfRequest == StateOfRequest.Approved ||
                                                     viewModel.StateOfRequest == StateOfRequest.Denied):
                case StateOfRequest.Approved when viewModel.StateOfRequest == StateOfRequest.Finished:
                    personRequest.StateOfRequest = viewModel.StateOfRequest;
                    break;
                case StateOfRequest.Denied:
                    break;
                case StateOfRequest.Finished:
                    break;
                default:
                    return null;
            }

            _context.PersonRequests.Update(personRequest);
            await _context.SaveChangesAsync();
            return viewModel;
        }

        public IEnumerable<User> GetAllUsersOnlyWithRoles()
        {
            var users =
                _context.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).ToList();

            return users;
        }

        public IEnumerable<string> GetUserRolesByUsername(string username)
        {
            var data = _context.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).ToList();
            var user = data.FirstOrDefault(x => x.Login == username);

            if (user == null) return new List<string>();

            var roles = user.UserRole.ToList().Select(role => role.Role.RoleName).ToList();

            return roles;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            var users = _context.Persons.ToList();
            return users;
        }
    }
}