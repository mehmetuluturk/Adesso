namespace Adesso.API.Controllers;

public class BaseController : ControllerBase
{
    public IActionResult MapToResult<T>(Response<T> response)
    {
        return new ObjectResult(new ResponseDto<T>
        {
            Result = response.Result,
            ErrorCode = response.ErrorCode,
            Errors = response.Errors.ToList()
        });
    }
}