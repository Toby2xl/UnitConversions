using System;
using Units.Application.Helper;
using Units.Application.Repository;



namespace Units.Application.Service;

public class ConversionService : IConversionService
{
    private readonly IConversionRepo _conversionRepo;
    public ConversionService(IConversionRepo conversionRepo)
    {
        _conversionRepo = conversionRepo;

    }
    
    public async Task<decimal> GetConversion(string dimension, string sourceUnit, string destinationUnit, decimal sourceValue, CancellationToken cancellationToken)
    {
        decimal sourceFactor;
        decimal destFactor;
        var value = await _conversionRepo.GetConversionFactor(dimension, sourceUnit, destinationUnit, cancellationToken);
        if(value is null)
        {
           sourceFactor = 0.0M;
           destFactor = 0.0M;        }
        else
        {
            sourceFactor = value.SourceFactor;
            destFactor = value.DestFactor;
        }
        
        var units = UnitConvert.Define(sourceValue, sourceFactor, destFactor);
        decimal result = units.Convert();
        return result;
    }

}
