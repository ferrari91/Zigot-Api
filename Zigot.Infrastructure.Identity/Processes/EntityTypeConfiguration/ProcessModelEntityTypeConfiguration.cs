using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zigot.Infrastructure.Identity.Processes.EntityTypeConfiguration
{
    public class ProcessModelEntityTypeConfiguration : IEntityTypeConfiguration<Core.Domain.Contract.Persons.DomainModel.ProcessModel.Process>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Contract.Persons.DomainModel.ProcessModel.Process> builder)
        {
            builder.ToTable("pes_processo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.WeaponType).HasColumnName("arma").HasMaxLength(30).IsRequired();
            builder.Property(e => e.WeaponRegistrationType).HasColumnName("tipo_registro").HasMaxLength(50).IsRequired();
            builder.Property(e => e.WeaponRegisterDate).HasColumnName("data_cadastro").IsRequired();
            builder.Property(e => e.Caliber).HasColumnName("calibre").HasMaxLength(10);
        }
    }
}
