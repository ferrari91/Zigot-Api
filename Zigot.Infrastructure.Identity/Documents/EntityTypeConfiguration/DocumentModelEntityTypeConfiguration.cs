using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zigot.Core.Domain.Contract.Persons;

namespace Zigot.Infrastructure.Identity.Documents.EntityTypeConfiguration
{
    public class DocumentModelEntityTypeConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("pes_documento");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CPF).HasColumnName("cpf").HasMaxLength(30).IsRequired();
            builder.Property(e => e.RG).HasColumnName("rg").HasMaxLength(30);
            builder.Property(e => e.IssuingBody).HasColumnName("orgao").HasMaxLength(10);
            builder.Property(e => e.State).HasColumnName("euf").HasMaxLength(2);
            builder.Property(e => e.IssueDate).HasColumnName("data_emissao");
            builder.Property(e => e.ElectoralTitle).HasColumnName("titulo_eleitoral").HasMaxLength(35);
        }
    }
}
