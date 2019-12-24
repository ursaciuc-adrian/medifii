using Medifii.ProductService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medifii.ProductService.Persistence.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.OwnsOne(product => product.Name, prop => prop.Property(x => x.Value));
            builder.OwnsOne(product => product.Description, prop => prop.Property(x => x.Value));
            builder.OwnsOne(product => product.Price, prop => prop.Property(x => x.Value));
        }
    }
}
