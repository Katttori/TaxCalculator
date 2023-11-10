using System;

namespace TaxCalculator.BusinessLogic.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Round(this decimal value) => Math.Round(value, 2);
    }
}
