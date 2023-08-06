namespace Adesso.Domain.Travels;

public class Travels : Entity<Guid>, IAggregateRoot
{
    public Travels(Guid userId,
        int fromLocationId,
        int whereLocationId,
        DateTime travelDateOnUtc,
        string description,
        int passengerCount)
    {
        if (passengerCount == 0)
        {
            throw new Exception("Enter valid passenger count.");
        }

        if (travelDateOnUtc < DateTime.UtcNow)
        {
            throw new Exception("Travel date must be greater than now.");
        }
        
        UserId = userId;
        FromLocationId = fromLocationId;
        WhereLocationId = whereLocationId;
        TravelDateOnUtc = travelDateOnUtc;
        Description = description;
        PassengerCount = passengerCount;
        IsPublished = false;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public Guid UserId { get; private set; }
    public int FromLocationId { get; private set; }
    public int WhereLocationId { get; private set; }
    public DateTime TravelDateOnUtc { get; private set; }
    public string Description { get; private set; }
    public int PassengerCount { get; private set; }
    public bool IsPublished { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? UpdatedOnUtc { get; private set; }

    public void ChangePublishStatus()
    {
        IsPublished = !IsPublished;
        UpdatedOnUtc = DateTime.UtcNow;
    }
}