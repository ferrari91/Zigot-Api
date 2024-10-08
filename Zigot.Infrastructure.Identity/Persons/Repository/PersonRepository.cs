﻿using Zigot.Core.Domain.Contract.Persons;
using Zigot.Core.Domain.Contract.Persons.Repository;
using Zigot.Infrastructure.Identity._Shared;
using Zigot.Infrastructure.Identity.Context;

namespace Zigot.Infrastructure.Identity.Persons.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
