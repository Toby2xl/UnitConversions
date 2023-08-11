using System;

namespace Units.Application.Service;

public interface IConversionService
{
    Task<decimal> GetConversion(string dimension, string sourceUnit, string destinationUnit, decimal sourceValue, CancellationToken cancellationToken);
}
