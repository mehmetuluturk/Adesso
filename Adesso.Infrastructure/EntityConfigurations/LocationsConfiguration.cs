namespace Adesso.Infrastructure.EntityConfigurations;

public class LocationsConfiguration : IEntityTypeConfiguration<Locations>
{
    public void Configure(EntityTypeBuilder<Locations> builder)
    {
        builder.ToTable(TableNames.Locations);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LocationName);
    }
}