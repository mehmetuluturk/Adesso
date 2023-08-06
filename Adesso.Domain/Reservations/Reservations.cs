namespace Adesso.Domain.Reservations;

public class Reservations : Entity<Guid>, IAggregateRoot
{
    public Reservations(Guid userId, Guid travelId, int passengerNumber)
    {
        UserId = userId;
        TravelId = travelId;
        PassengerNumber = passengerNumber;
        IsApproved = false;
    }

    public Guid UserId { get; private set; }
    public Guid TravelId { get; private set; }
    public int PassengerNumber { get; private set; }
    public bool IsApproved { get; private set; }
}