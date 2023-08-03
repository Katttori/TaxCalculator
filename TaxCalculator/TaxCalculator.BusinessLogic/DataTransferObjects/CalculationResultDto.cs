namespace TaxCalculator.BusinessLogic.DataTransferObjects
{
    public class CalculationResultDto
    {
        public int GrossAnnualSalary { get; set; }

        public double GrossMonthlySalary { get; set; }

        public double NetAnnualSalary { get; set; }

        public double NetMonthlySalary { get; set; }

        public double AnnualTaxPaid { get; set; }

        public double MonthlyTaxPaid { get; set; }
    }
}
