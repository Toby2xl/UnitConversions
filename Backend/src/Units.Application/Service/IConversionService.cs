using System;

namespace Units.Application.Service;

public interface IConversionService
{
    Task<decimal> GetConversion(string sourceUnit, string destinationUnit, decimal sourceValue, string dimension, CancellationToken cancellationToken);
}
