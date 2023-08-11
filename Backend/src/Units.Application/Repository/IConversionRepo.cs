using System;
using Units.Core;


namespace Units.Application.Repository
{
    public interface IConversionRepo
    {
        Task<decimal> GetConversionFactor(string dimension, string unit, CancellationToken cancellationToken);
    }
}
