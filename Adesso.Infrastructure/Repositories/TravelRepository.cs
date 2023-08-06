namespace Adesso.Infrastructure.Repositories;

public class TravelRepository : ITravelRepository
{
    private readonly AdessoContext _context;

    public TravelRepository(AdessoContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Travels entity)
    {
        await _context.Travels.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}