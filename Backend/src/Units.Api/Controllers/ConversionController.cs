using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Units.Application.Features.Conversion.Query.GetConversion;

namespace Units.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConversionController : ControllerBase
{
    private readonly ISender _mediator;
    public ConversionController(ISender mediator)
    {
        _mediator = mediator;
    }

    public IResult Get()
    {
        return Results.Ok("Unit Conversion API");
    }

    [HttpGet("{dimension}/{sourceUnit}/{destUnit}", Name = "GetConversion")]
    public async Task<IResult> Convert([FromRoute] string dimension, [FromRoute]string sourceUnit, [FromRoute]string destUnit, [FromQuery] decimal sourceValue)
    {
        var conversionQuery = new GetConversionQuery
        {
            Dimension = dimension,
            SourceUnit = sourceUnit,
            DestinationUnit = destUnit,
            SourceValue = sourceValue
        };

        var response = await _mediator.Send(conversionQuery);
        if(!response.Success)
        {
            return Results.NotFound(response);
        }
        return Results.Ok(response);
    }
}
