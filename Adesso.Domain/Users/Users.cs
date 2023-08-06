namespace Adesso.Domain.Users;

public class Users : Entity<Guid>
{
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? UpdatedOnUtc { get; private set; }
}