using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Entities.Entities
{
    public class TaxBand : BaseEntity
    {
        public string Name { get; set; }

        public int LowerLimit { get; set; }

        public int? UpperLimit { get; set; }

        public int TaxRate { get; set; }
    }
}
