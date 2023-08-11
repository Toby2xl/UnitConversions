using System;
using Microsoft.EntityFrameworkCore;
using Units.Application.Helper;
using Units.Application.Repository;
using Units.Infrastructure.Data;

namespace Units.Infrastructure.Repository
{
    public class ConversionRepo : IConversionRepo
    {
        private readonly ConversionDbContext _context;
        public ConversionRepo(ConversionDbContext context)
        {
            _context = context;

        }
        public async Task<ConversionDto> GetConversionFactor(string dimension, string sourceUnit, string destUnit, CancellationToken cancellationToken)
        {
            var query = 
                        from sourceVal in _context.Conversions
                        where sourceVal.Dimension == dimension && sourceVal.Units == sourceUnit
                        
                        from destVal in _context.Conversions
                        where destVal.Dimension == dimension && destVal.Units == destUnit
                        select new ConversionDto
                        {
                            SourceFactor = sourceVal.Factor,
                            DestFactor = destVal.Factor
                        };
            
            var result = await query.FirstOrDefaultAsync(cancellationToken);
            if(result is null)
            {
                return default!;
            }
            return result;

        }

    }
}
