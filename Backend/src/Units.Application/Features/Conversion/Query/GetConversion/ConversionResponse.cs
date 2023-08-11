using System;

namespace Units.Application.Features.Conversion.Query.GetConversion
{
    public class ConversionResponse : BaseResponse<ConversionResult>
    {
        
    }

    public record ConversionResult(string DestinationUnit, decimal DestinationValue);
}
