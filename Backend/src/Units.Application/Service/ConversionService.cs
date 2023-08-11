using System;
using Units.Application.Repository;


namespace Units.Application.Service;

public class ConversionService : IConversionService
{
    private readonly IConversionRepo _conversionRepo;
    public ConversionService(IConversionRepo conversionRepo)
    {
        _conversionRepo = conversionRepo;

    }
    
    public async Task<decimal> GetConversion(string sourceUnit, string destinationUnit, decimal sourceValue, string dimension, CancellationToken cancellationToken)
    {
        decimal sourceFactor = await _conversionRepo.GetConversionFactor(dimension: dimension, unit: sourceUnit, cancellationToken);
        decimal destFactor = await _conversionRepo.GetConversionFactor(dimension, destinationUnit, cancellationToken);

        return decimal.Zero;
    }

}
