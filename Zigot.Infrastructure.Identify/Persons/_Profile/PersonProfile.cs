using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand;
using Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery;
using Zigot.Core.Domain.Contract.Persons.DomainModel;

namespace Zigot.Infrastructure.Identity.Persons._Profile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreateRequest, Person>();
            CreateMap<Person, PersonCreateResponse>();

            CreateMap<PersonsConsultResponse, Person>()
                .ReverseMap();
        }
    }
}
