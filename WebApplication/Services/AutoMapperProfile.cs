using AutoMapper;
using WebApplication.Models.DbModels;
using WebApplication.Models.DTOModels;

namespace WebApplication.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddRequestViewModel, Persons>();
            CreateMap<AddRequestViewModel, Estate>();

            CreateMap<Persons, PersonsRequestsViewModel>();
            CreateMap<PersonRequests, PersonsRequestsViewModel>();
            CreateMap<PersonsRequestsViewModel, Persons>();
            CreateMap<PersonsRequestsViewModel, PersonRequests>();
        }
    }
}