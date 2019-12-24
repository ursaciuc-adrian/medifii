using Medifii.PharmacyService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medifii.PharmacyService.Persistence.Mappers
{
    public class PharmacyMapping : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.HasKey(ph => ph.Id);
            builder.OwnsOne(ph => ph.Name, prop => prop.Property(x  => x.Value));
            builder.Ignore(ph => ph.Products);
        }
    }
}
