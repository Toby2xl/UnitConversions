using System;
using MediatR;
using Units.Application.Service;

namespace Units.Application.Features.Coonversion.Query.GetConversion;

public class GetConversionQueryHandler : IRequestHandler<GetConversionQuery, ConversionResponse>
{
    private readonly IConversionService _conv;
    public GetConversionQueryHandler(IConversionService conv)
    {
        _conv = conv;

    }
    public async Task<ConversionResponse> Handle(GetConversionQuery request, CancellationToken cancellationToken)
    {
        string dimension = request.Dimension;
        string sourceUnit = request.SourceUnit;
        string destUnit = request.DestinationUnit;
        decimal sourceVal = request.SourceValue;

        var response = new ConversionResponse();
        try
        {
            
            var result = await _conv.GetConversion(dimension, sourceUnit, destUnit, sourceVal, cancellationToken);
            var conversionResult = new ConversionResult(destUnit, result);
            response.Data = conversionResult;
        }
        catch (System.Exception)
        {
            response.Success = false;
            response.Data = null;
            throw;
        }
        return response;
    }

}
