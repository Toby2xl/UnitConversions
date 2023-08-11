using System;

namespace Units.Application.Features;

public class BaseResponse<T>
{
    public BaseResponse()
    {
        Success = true;
    }
    public bool Success { get; set; }
    public T? Data {get; set;} = default!;
}
