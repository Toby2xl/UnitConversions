using System;
using MediatR;


namespace Units.Application.Features.Coonversion.Query.GetConversion;

public class GetConversionQueryHandler : IRequestHandler<GetConversionQuery, ConversionResult>
{
    public GetConversionQueryHandler()
    {
        
    }
    public Task<ConversionResult> Handle(GetConversionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}
