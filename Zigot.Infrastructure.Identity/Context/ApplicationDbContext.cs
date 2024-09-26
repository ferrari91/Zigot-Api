using Microsoft.EntityFrameworkCore;
using Zigot.Core.Domain.Contract.Addresses;
using Zigot.Core.Domain.Contract.Contacts;
using Zigot.Core.Domain.Contract.Persons;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel.FederalModel;

namespace Zigot.Infrastructure.Identity.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Document> PersonDocuments { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<FederalRegistration> FederalRegistrations { get; set; }
        public DbSet<FederalDocument> FederalDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
