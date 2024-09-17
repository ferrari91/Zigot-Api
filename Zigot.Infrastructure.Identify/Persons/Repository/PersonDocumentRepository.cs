using Zigot.Core.Domain.Contract.Persons.DomainModel;
using Zigot.Core.Domain.Contract.Persons.Repository;
using Zigot.Infrastructure.Identity._Shared;
using Zigot.Infrastructure.Identity.Context;

namespace Zigot.Infrastructure.Identity.Persons.Repository
{
    internal class PersonDocumentRepository : BaseRepository<PersonDocument>, IPersonDocumentRepository
    {
        public PersonDocumentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
