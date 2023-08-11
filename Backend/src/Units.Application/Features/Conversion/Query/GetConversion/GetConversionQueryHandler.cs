using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Units.Application.Service;

namespace Units.Application.Features.Conversion.Query.GetConversion;

public class GetConversionQueryHandler : IRequestHandler<GetConversionQuery, ConversionResponse>
{
    private readonly IConversionService _conv;
    private readonly ILogger<GetConversionQueryHandler> _logger;
    public GetConversionQueryHandler(IConversionService conv, ILogger<GetConversionQueryHandler> logger)
    {
        _conv = conv;
        _logger = logger;
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
            _logger.LogInformation("The result for the conversion is {resultValue}", result);
        }
        catch (System.Exception ex)
        {
            response.Success = false;
            response.Data = null;
            _logger.LogError("An error occured while getting the Conversion for {destUnit} with value: {value}; Message => {message}", destUnit, sourceVal, ex.Message);
        }
        return response;
    }

}
