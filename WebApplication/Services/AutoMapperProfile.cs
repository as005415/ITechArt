using AutoMapper;
using Domain.Models;
using WebApplication.Models.DTOModels;

namespace WebApplication.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddRequestViewModel, Person>();
            CreateMap<AddRequestViewModel, Estate>();

            CreateMap<Person, PersonsRequestsViewModel>();
            CreateMap<PersonRequest, PersonsRequestsViewModel>();
            CreateMap<PersonsRequestsViewModel, Person>();
            CreateMap<PersonsRequestsViewModel, PersonRequest>();
        }
    }
}