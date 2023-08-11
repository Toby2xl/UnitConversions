using System;

namespace Units.Application.Helper;

public class UnitConvert
{
    public decimal SourceValue { get; init; }
    public decimal SourceFactor { get; init; }
    public decimal DestFactor { get; init; }

    public UnitConvert(decimal sourceValue, decimal sourceFactor, decimal destFactor)
    {
        SourceValue = sourceValue;
        SourceFactor = sourceFactor;
        DestFactor = destFactor;
    }

    public static UnitConvert Define(decimal sourceValue, decimal sourceFactor, decimal destFactor)
    {
        return new UnitConvert(sourceValue, sourceFactor, destFactor);
    }
    public decimal Convert()
    {
        decimal result = SourceValue * SourceFactor / DestFactor;
        return result;
    }
}
