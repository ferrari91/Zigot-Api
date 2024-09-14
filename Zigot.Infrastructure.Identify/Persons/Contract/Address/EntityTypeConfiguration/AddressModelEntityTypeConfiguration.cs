using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zigot.Infrastructure.Identity.Persons.Contract.Address.EntityTypeConfiguration
{
    public class AddressModelEntityTypeConfiguration : IEntityTypeConfiguration<Core.Domain.Contract.Persons.DomainModel.AddressModel.Address>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Contract.Persons.DomainModel.AddressModel.Address> builder)
        {
            builder.ToTable("pes_endereco");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Street).HasColumnName("endereco").HasMaxLength(200).IsRequired();
            builder.Property(e => e.Number).HasColumnName("numero").HasMaxLength(30);
            builder.Property(e => e.District).HasColumnName("bairro").HasMaxLength(100);
            builder.Property(e => e.Complement).HasColumnName("complemento").HasMaxLength(100);
            builder.Property(e => e.City).HasColumnName("cidade").HasMaxLength(100).IsRequired();
            builder.Property(e => e.State).HasColumnName("uf").HasMaxLength(2).IsRequired();
            builder.Property(e => e.ZipCode).HasColumnName("cep").HasMaxLength(30).IsRequired();
        }
    }
}
