using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;
public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.HasData(
            new Destination
            {
                Id = 1,
                Name = "Bin 1",
                DestinationType = Enums.DestinationType.Bin
            },
            new Destination
            {
                Id = 2,
                Name = "YM73 VSC",
                DestinationType = Enums.DestinationType.Truck
            });
    }
}
