using System;

namespace Units.Application.Helper
{
    public static class Temperature
    {
        
        const decimal tempConstK = 273.15M;
        public static decimal GetTemperature(string sourceUnit, string destUnit, decimal sourceValue)
        {
            if(sourceUnit == destUnit)
            {
                return sourceValue;
            }
            return sourceUnit switch
            {
                "kelvin" when destUnit == "celsius" => sourceValue - tempConstK,
                "celsius" when destUnit == "kelvin" => sourceValue + tempConstK,
                "kelvin" when destUnit == "fahrenheit" => (sourceValue - tempConstK) * 1.8M + 32,
                "fahrenheit" when destUnit == "kelvin" => (sourceValue - 32) * 5 / 9 + tempConstK,
                "celsius" when destUnit == "fahrenheit" => sourceValue * 9 / 5 + 32,
                "fahrenheit" when destUnit == "celsius" => (sourceValue - 32) * 5 / 9,
                _ => 0.0M
            };
        }
    }


}
