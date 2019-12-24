using Medifii.PharmacyService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medifii.PharmacyService.Persistence.Mappers
{
    public class PharmacyProductsMapping :IEntityTypeConfiguration<PharmacyProducts>
    {
        public void Configure(EntityTypeBuilder<PharmacyProducts> builder)
        {
            builder.HasKey(php => php.Id);
            builder.Property(php => php.PharmacyId);
            builder.Property(php => php.ProductId);
        }
    }
}
