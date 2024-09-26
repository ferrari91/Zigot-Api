using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zigot.Core.Domain.Contract.Persons;

namespace Zigot.Infrastructure.Identity.Persons.EntityTypeConfiguration
{
    public class PersonModelEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pes_cliente");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FullName).HasColumnName("nome").HasMaxLength(200).IsRequired();
            builder.Property(e => e.Birthday).HasColumnName("data_nascimento").IsRequired();
            builder.Property(e => e.MotherFullName).HasColumnName("nome_mae").HasMaxLength(200);
            builder.Property(e => e.FatherFullName).HasColumnName("nome_pai").HasMaxLength(200);
            builder.Property(e => e.Profession).HasColumnName("profissao").HasMaxLength(100);
            builder.Property(e => e.HasChildren).HasColumnName("tem_filhos").IsRequired();
            builder.Property(e => e.RegisterDate).HasColumnName("data_cadastro").IsRequired();
            builder.Property(e => e.MaritalStatus).HasColumnName("estado_civil").HasMaxLength(30);

            builder.HasMany(e => e.Processes)
                .WithOne(p => p.Person)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(p => p.PersonId);
        }
    }
}
