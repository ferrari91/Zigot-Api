using AutoMapper;
using Zigot.Core.Application.CommandStack.PersonCommand.CreateCommand;
using Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery;
using Zigot.Core.Domain.Contract.Addresses;
using Zigot.Core.Domain.Contract.Contacts;
using Zigot.Core.Domain.Contract.Persons;
using Zigot.Core.Domain.Contract.Persons.Records;

namespace Zigot.Infrastructure.Identity.Persons.Repository.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreateRequest, PersonRecord>()
              .ConstructUsing(src => new PersonRecord(
                  src.FullName,
                  src.Birthday,
                  src.MotherFullName,
                  src.FatherFullName,
                  0,
                  src.CPF,
                  src.RG,
                  src.IssuingBody,
                  src.DocumentState,
                  src.IssueDate,
                  src.ElectoralTitle,
                  new Address
                  {
                      Street = src.Street,
                      Number = src.Number,
                      District = src.District,
                      Complement = src.Complement,
                      City = src.City,
                      State = src.State,
                      ZipCode = src.ZipCode
                  },
                  new Contact
                  {
                      PhoneNumber = src.PhoneNumber,
                      Email = src.Email,
                      OriginCity = src.OriginCity,
                      OriginState = src.OriginState
                  },
                  src.Profession,
                  src.HasChildren,
                  src.MaritalStatus
              ));

            CreateMap<Person, PersonCreateResponse>();
            CreateMap<PersonsConsultResponse, Person>()
                .ReverseMap();
        }
    }
}
