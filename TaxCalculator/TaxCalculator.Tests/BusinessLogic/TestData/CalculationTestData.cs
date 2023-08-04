using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.DataTransferObjects;

namespace TaxCalculator.Tests.BusinessLogic.TestData
{
    internal class CalculationTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                1000,
                new CalculationResultDto 
                {
                    GrossAnnualSalary = 1000,
                    GrossMonthlySalary = (decimal) 83.33,
                    NetAnnualSalary = 1000,
                    NetMonthlySalary = (decimal) 83.33,
                    AnnualTaxPaid = 0,
                    MonthlyTaxPaid = 0
                }
            };

            yield return new object[]
            {
                10000,
                new CalculationResultDto
                {
                    GrossAnnualSalary = 10000,
                    GrossMonthlySalary = (decimal) 833.33,
                    NetAnnualSalary = 9000,
                    NetMonthlySalary = 750,
                    AnnualTaxPaid = 1000,
                    MonthlyTaxPaid = (decimal) 83.33
                }
            };

            yield return new object[]
            {
                50000,
                new CalculationResultDto
                {
                    GrossAnnualSalary = 50000,
                    GrossMonthlySalary = (decimal) 4166.67,
                    NetAnnualSalary = 35000,
                    NetMonthlySalary = (decimal) 2916.67,
                    AnnualTaxPaid = 15000,
                    MonthlyTaxPaid = 1250
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
