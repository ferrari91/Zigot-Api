using Zigot.Core.Domain.Contract.Persons;
using Zigot.Core.Domain.Contract.Persons.Repository;
using Zigot.Infrastructure.Identity._Shared;
using Zigot.Infrastructure.Identity.Context;

namespace Zigot.Infrastructure.Identity.Persons.Repository
{
    internal class PersonDocumentRepository : BaseRepository<Document>, IPersonDocumentRepository
    {
        public PersonDocumentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
