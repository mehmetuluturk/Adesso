namespace Adesso.API.Models;

public class TravelRequest
{
    public int FromLocationId { get; set; }
    public int WhereLocationId { get; set; }
    public int PassengerCount { get; set; }
    public string Description { get; set; }
    public DateTime TravelDate { get; set; }
}