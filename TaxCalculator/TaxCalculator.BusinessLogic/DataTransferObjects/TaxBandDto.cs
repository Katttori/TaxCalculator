using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.BusinessLogic.DataTransferObjects
{
    public class TaxBandDto
    {
        public string Name { get; set; }

        public int LowerLimit { get; set; }

        public int? UpperLimit { get; set; }

        public int TaxRate { get; set; }
    }
}
