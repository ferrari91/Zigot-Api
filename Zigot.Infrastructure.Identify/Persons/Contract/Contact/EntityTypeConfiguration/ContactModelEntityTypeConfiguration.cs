using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zigot.Infrastructure.Identity.Persons.Contract.Contact.EntityTypeConfiguration
{
    internal class ContactModelEntityTypeConfiguration : IEntityTypeConfiguration<Core.Domain.Contract.Persons.DomainModel.ContactModel.Contact>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Contract.Persons.DomainModel.ContactModel.Contact> builder)
        {
            builder.ToTable("pes_contato");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PhoneNumber).HasColumnName("telefone").HasMaxLength(35);
            builder.Property(e => e.Email).HasColumnName("email").HasMaxLength(80);
            builder.Property(e => e.OriginCity).HasColumnName("cidade_origem").HasMaxLength(80);
            builder.Property(e => e.OriginState).HasColumnName("uf_origem").HasMaxLength(80);
        }
    }
}
