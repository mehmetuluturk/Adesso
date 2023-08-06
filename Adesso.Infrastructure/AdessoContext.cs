public class AdessoContext : DbContext
{
    public AdessoContext(DbContextOptions<AdessoContext> options) : base(options)
    {
    }
    
    public DbSet<Users> Users { get; set; }
    public DbSet<Locations> Locations { get; set; }
    public DbSet<Travels> Travels { get; set; }
    public DbSet<Reservations> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        modelBuilder.ApplyConfiguration(new LocationsConfiguration());
        modelBuilder.ApplyConfiguration(new TravelsConfiguration());
    }
}