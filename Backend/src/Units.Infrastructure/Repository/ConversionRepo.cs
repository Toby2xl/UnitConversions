using System;
using Units.Application.Helper;
using Units.Application.Repository;


namespace Units.Infrastructure.Repository
{
    public class ConversionRepo : IConversionRepo
    {
        public ConversionRepo()
        {
            
        }
        public Task<ConversionDto> GetConversionFactor(string dimension, string unit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
