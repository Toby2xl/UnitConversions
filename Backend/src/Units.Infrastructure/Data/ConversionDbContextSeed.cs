using Microsoft.VisualBasic.CompilerServices;
using System;
using Units.Core;


namespace Units.Infrastructure.Data;

public static class ConversionDbContextSeed
{
    public static async Task SeedConversionDataAsync(ConversionDbContext context)
    {
        if(!context.Conversions.Any())
        {
            context.Conversions.AddRange(
                //Length
                new Conversion { Units = "foot", Dimension = "length", Factor = 1 },
                new Conversion { Units = "meter", Dimension = "length", Factor = 3.28084M },
                new Conversion { Units = "milimeter", Dimension = "length", Factor = 0.00328084M },
                new Conversion { Units = "kilometer", Dimension = "length", Factor = 3280.84M },
                new Conversion { Units = "centimeter", Dimension = "length", Factor = 0.0328084M },
                new Conversion { Units = "mile", Dimension = "length", Factor = 5280 },
                new Conversion { Units = "inch", Dimension = "length", Factor = 0.0833333M},
                new Conversion { Units = "yard", Dimension = "length", Factor = 3 },

                //Area
                new Conversion { Units = "squarefoot", Dimension = "area", Factor = 1},
                new Conversion { Units = "squaremeter", Dimension = "Area", Factor = 10.7639M },
                new Conversion { Units = "squarekilometer", Dimension = "Area", Factor = 1.076e+7M },
                new Conversion { Units = "hectare", Dimension = "area", Factor = 107639 },
                new Conversion { Units = "acres", Dimension = "area", Factor = 43560 },
                new Conversion { Units = "squareinch", Dimension = "area", Factor = 0.00694444M },
                new Conversion { Units = "squaremile", Dimension = "area", Factor = 2.788e+7M },
                new Conversion { Units = "squareyard", Dimension = "area", Factor = 2.788e+7M },

                //Volume
                new Conversion { Units = "cubicfoot", Dimension = "volume", Factor = 1 },
                new Conversion { Units = "cubicmeter", Dimension = "volume", Factor = 35.3147M },
                new Conversion { Units = "cubiccentimeter", Dimension = "volume", Factor = 3.53147e-5M },
                new Conversion {Units = "liter", Dimension = "volume", Factor = 0.0353147M },

                //Mass
                new Conversion { Units = "ounce", Dimension = "mass", Factor = 1 },
                new Conversion { Units = "kilogram", Dimension = "mass", Factor = 35.274M },
                new Conversion { Units = "gram", Dimension = "mass", Factor = 0.035274M },
                new Conversion { Units = "miligram", Dimension = "mass", Factor = 3.5274e-5M }

            );

            await context.SaveChangesAsync();
        }
    }
}
