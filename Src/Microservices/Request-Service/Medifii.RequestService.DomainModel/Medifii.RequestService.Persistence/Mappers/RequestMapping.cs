using Medifii.RequestService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medifii.RequestService.Persistence.Mappers
{
    public class RequestMapping : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.PharmacyId);
            builder.OwnsOne(r => r.ProductName, prop => prop.Property(x => x.Value));
            builder.Property(r => r.UserId);
            builder.Property(r => r.ResolvedStatus);
            builder.Property(r => r.Quantity);
        }
    }
}
