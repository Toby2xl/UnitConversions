using System;

namespace Units.Application.Features.Coonversion.Query.GetConversion
{
    public class ConversionResponse : BaseResponse<ConversionResult>
    {
        
    }

    public record ConversionResult(string DestinationUnit, decimal DestinationValue);
}
