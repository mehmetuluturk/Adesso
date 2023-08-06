namespace Adesso.Infrastructure.EntityConfigurations;

public class UsersConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.ToTable(TableNames.Users);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedOnUtc);
        builder.Property(x => x.UpdatedOnUtc);
    }
}