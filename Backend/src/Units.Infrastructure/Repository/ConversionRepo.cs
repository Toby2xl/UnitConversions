using System;
using Units.Application.Repository;


namespace Units.Infrastructure.Repository
{
    public class ConversionRepo : IConversionRepo
    {
        public Task<decimal> GetConversionFactor(string dimension, string unit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
