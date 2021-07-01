﻿using Domain.Models;
using Repository.GenericRepository;

namespace Repository.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
    }
}