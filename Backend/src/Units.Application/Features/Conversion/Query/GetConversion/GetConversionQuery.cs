using System;
using MediatR;



namespace Units.Application.Features.Conversion.Query.GetConversion;

public class GetConversionQuery : IRequest<ConversionResponse>
{
    public string Dimension { get; set; } = string.Empty;
    public string SourceUnit { get; set; } = string.Empty;
    public string DestinationUnit { get; set; } = string.Empty;
    public decimal SourceValue { get; set; }
}

