namespace Adesso.Infrastructure.EntityConfigurations;

public class TravelsConfiguration : IEntityTypeConfiguration<Travels>
{
    public void Configure(EntityTypeBuilder<Travels> builder)
    {
        builder.ToTable(TableNames.Travels);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId);
        builder.Property(x => x.FromLocationId);
        builder.Property(x => x.WhereLocationId);
        builder.Property(x => x.TravelDateOnUtc);
        builder.Property(x => x.Description);
        builder.Property(x => x.PassengerCount);
        builder.Property(x => x.IsPublished);
        builder.Property(x => x.CreatedOnUtc);
        builder.Property(x => x.UpdatedOnUtc);
    }
}