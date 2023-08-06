using Adesso.Domain.Reservations;
using Adesso.Domain.Travels;

namespace Adesso.API.Controllers;

[Route("api/v1/travel")]
[ApiController]
public class TravelController : BaseController
{
    private readonly IMediator _mediator;
    private readonly AdessoContext _context;

    public TravelController(IMediator mediator, AdessoContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpPost("save")]
    public async Task<IActionResult> Save([FromBody] TravelRequest model)
    {
        var userId = new Guid("45773bfd-e1d1-4739-8b08-bb94f7a394cb"); // It should come from auth token
        var saveTravelResponse = await _mediator.Send(new SaveTravelCommand()
        {
            UserId = userId,
            FromLocationId = model.FromLocationId,
            WhereLocationId = model.WhereLocationId,
            Description = model.Description,
            PassengerCount = model.PassengerCount,
            TravelDate = model.TravelDate
        });

        return MapToResult(saveTravelResponse);
    }

    // I don't have enough time to implement with CQRS anymore. That is why I implemented this way.
    [HttpPost("{id}/update-publish")]
    public async Task<IActionResult> UpdatePublish(Guid id)
    {
        var travel = await _context.Travels.FindAsync(id);
        if (travel != null)
        {
            travel.ChangePublishStatus();
            await _context.SaveChangesAsync();
            return MapToResult(Response<bool>.Success(travel.IsPublished));
        }

        return MapToResult(Response<bool>.Fail("Incorrect Travel"));
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] int from, [FromQuery] int where)
    {
        var travels =
            _context.Travels.Where(t =>
                t.IsPublished && t.FromLocationId == from && t.WhereLocationId == where &&
                t.TravelDateOnUtc > DateTime.UtcNow);

        return MapToResult(Response<List<Travels>>.Success(travels.ToList()));
    }

    [HttpPost("{id}/reservation-request")]
    public async Task<IActionResult> ReservationRequest(Guid id, [FromBody] int passengerCount)
    {
        var userId = new Guid("2b3bc3f4-40dd-4057-9831-076a90b0e7fe"); // It should come with authentication token.
        
        var travel = await _context.Travels.FindAsync(id);
        if (travel != null && travel.IsPublished)
        {
            var totalPassenger = _context.Reservations.Where(r => r.TravelId == id && r.IsApproved)
                .Sum(r => r.PassengerNumber);
            if (totalPassenger + passengerCount > travel.PassengerCount)
            {
                return MapToResult(Response<bool>.Fail("No enough passenger number"));        
            }

            await _context.Reservations.AddAsync(new Reservations(userId, id, passengerCount));
            await _context.SaveChangesAsync();
            return MapToResult(Response<bool>.Success(true));
        }

        return MapToResult(Response<bool>.Fail("Error"));
    }
}