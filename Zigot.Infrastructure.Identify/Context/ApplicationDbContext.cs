using Microsoft.EntityFrameworkCore;
using Zigot.Core.Domain.Contract.Persons.DomainModel;
using Zigot.Core.Domain.Contract.Persons.DomainModel.AddressModel;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ContactModel;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel.FederalModel;

namespace Zigot.Infrastructure.Identity.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Core.Domain.Contract.Persons.DomainModel.Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PersonDocument> PersonDocuments { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<FederalRegistration> FederalRegistrations { get; set; }
        public DbSet<FederalDocument> FederalDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
