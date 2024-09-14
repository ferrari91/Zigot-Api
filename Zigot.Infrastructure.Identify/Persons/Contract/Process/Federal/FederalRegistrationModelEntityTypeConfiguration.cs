using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel.FederalModel;

namespace Zigot.Infrastructure.Identity.Persons.Contract.Process.Federal
{
    public class FederalRegistrationModelEntityTypeConfiguration : IEntityTypeConfiguration<FederalRegistration>
    {
        public void Configure(EntityTypeBuilder<FederalRegistration> builder)
        {
            builder.ToTable("reg_federal");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.RegisterDate).HasColumnName("data_cadastro").IsRequired();
            builder.Property(e => e.IsFinalized).HasColumnName("finalizado").IsRequired();
        }
    }
}
