namespace Adesso.CQRS.Travels.Commands;

public class SaveTravelHandler : IRequestHandler<SaveTravelCommand, Response<SaveTravelResponse>>
{
    private readonly ITravelRepository _travelRepository;

    public SaveTravelHandler(ITravelRepository travelRepository)
    {
        _travelRepository = travelRepository;
    }

    public async Task<Response<SaveTravelResponse>> Handle(SaveTravelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _travelRepository.AddAsync(new Domain.Travels.Travels(request.UserId, request.FromLocationId,
                request.WhereLocationId, request.TravelDate, request.Description, request.PassengerCount));

            return Response<SaveTravelResponse>.Success(new SaveTravelResponse());
        }
        catch (Exception e)
        {
            return Response<SaveTravelResponse>.Fail(e.Message);
        }
    }
}