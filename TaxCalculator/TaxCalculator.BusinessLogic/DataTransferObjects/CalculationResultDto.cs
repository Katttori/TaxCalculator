namespace TaxCalculator.BusinessLogic.DataTransferObjects
{
    public class CalculationResultDto
    {
        public int GrossAnnualSalary { get; set; }

        public float GrossMonthlySalary { get; set; }

        public float NetAnnualSalary { get; set; }

        public float NetMonthlySalary { get; set; }

        public float AnnualTaxPaid { get; set; }

        public float MonthlyTaxPaid { get; set; }
    }
}
