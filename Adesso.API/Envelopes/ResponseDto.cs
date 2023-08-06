namespace Adesso.API.Envelopes;

public class ResponseDto<T>
{
    public string ErrorCode { get; set; }
    public List<string> Errors { get; set; }
    public T Result { get; set; }
}