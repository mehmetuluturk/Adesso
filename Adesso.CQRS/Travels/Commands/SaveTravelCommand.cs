namespace Adesso.CQRS.Travels.Commands;

public class SaveTravelCommand : IRequest<Response<SaveTravelResponse>>
{
    public Guid UserId { get; set; }
    public int FromLocationId { get; set; }
    public int WhereLocationId { get; set; }
    public int PassengerCount { get; set; }
    public string Description { get; set; }
    public DateTime TravelDate { get; set; }
}