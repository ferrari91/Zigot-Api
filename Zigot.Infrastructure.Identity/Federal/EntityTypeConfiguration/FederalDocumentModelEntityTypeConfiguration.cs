using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zigot.Core.Domain.Contract.Persons.DomainModel.ProcessModel.FederalModel;

namespace Zigot.Infrastructure.Identity.Federal.EntityTypeConfiguration
{
    public class FederalDocumentModelEntityTypeConfiguration : IEntityTypeConfiguration<FederalDocument>
    {
        public void Configure(EntityTypeBuilder<FederalDocument> builder)
        {
            builder.ToTable("reg_federal_documentos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DocumentDescription).HasColumnName("descricao_documento").HasMaxLength(255).IsRequired();
            builder.Property(e => e.BucketReferenceCode).HasColumnName("codigo_referencia_bucket").HasMaxLength(255).IsRequired();
        }
    }
}
