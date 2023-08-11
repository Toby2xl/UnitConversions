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
        decimal sourceFactor = await _conversionRepo.GetConversionFactor(dimension: dimension, unit: sourceUnit, cancellationToken);
        decimal destFactor = await _conversionRepo.GetConversionFactor(dimension, destinationUnit, cancellationToken);

        var units = UnitConvert.Define(sourceValue, sourceFactor, destFactor);
        decimal result = units.Convert();
        return result;
    }

}
