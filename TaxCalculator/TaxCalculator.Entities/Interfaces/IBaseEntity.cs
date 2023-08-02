using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Entities.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
