using System;
using TaxCalculator.Entities.Interfaces;

namespace TaxCalculator.Entities.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
