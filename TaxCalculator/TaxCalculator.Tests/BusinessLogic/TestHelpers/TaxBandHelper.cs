using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.DataTransferObjects;

namespace TaxCalculator.Tests.BusinessLogic.TestHelpers
{
    internal static class TaxBandHelper
    {
        public static IEnumerable<TaxBandDto> GetTaxBands()
        {
            return new List<TaxBandDto>
            {
                new TaxBandDto
                {
                    Name = "Tax band A",
                    LowerLimit = 0,
                    UpperLimit = 5000,
                    TaxRate = 0
                },
                new TaxBandDto
                {
                    Name = "Tax band B",
                    LowerLimit = 5000,
                    UpperLimit = 20000,
                    TaxRate = 20
                },
                new TaxBandDto
                {
                    Name = "Tax band C",
                    LowerLimit = 20000,
                    UpperLimit = null,
                    TaxRate = 40
                }
            };
        }
    }
}
