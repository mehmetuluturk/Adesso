namespace Adesso.Common.Envelopes;

public sealed class Response<T>
{
    private readonly List<string> _errors = new List<string>();
    public bool HasErrors => _errors.Any();
    public IReadOnlyList<string> Errors => _errors.AsReadOnly();
    public string ErrorCode { get; protected set; }
    public T Result { get; protected set; }

    protected Response()
    {
    }

    protected Response(T result)
    {
        Result = result;
    }
    
    public void AddError(string error)
    {
        if (!string.IsNullOrEmpty(error))
        {
            _errors.Add(error);
        }
    }
    
    public static Response<T> Fail(string error)
    {
        var response = new Response<T>();
        response.AddError(error);

        return response;
    }
    
    public static Response<T> Success(T result)
    {
        return new Response<T>(result);
    }
}