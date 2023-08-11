using System;
using Units.Application.Helper;
using Units.Core;


namespace Units.Application.Repository
{
    public interface IConversionRepo
    {
        Task<ConversionDto> GetConversionFactor(string dimension, string sourceUnit, string destUnit, CancellationToken cancellationToken);
    }
}
