namespace TaxRefactorPractice
{
    public class TaxHelper
    {
        public static decimal GetTaxResult(decimal income)
        {
            decimal result = 0;
            if (income < 540_000)
            {
                result = income * 0.05m;
            }
            else if (income < 1_210_000)
            {
                result = 540_000 * 0.05m + (income - 540_000) * 0.12m;
            }
            else if (income < 2_420_000)
            {
                result = 540_000 * 0.05m + (1_210_000 - 540_000) * 0.12m + (income - 1_210_000) * 0.2m;
            }
            else if (income < 4_530_000)
            {
                result = 540_000 * 0.05m + (1_210_000 - 540_000) * 0.12m + (2_420_000 - 1_210_000) * 0.2m + (income - 2_420_000) * 0.3m;
            }
            else if (income < 10_310_000)
            {
                result = 540_000 * 0.05m + (1_210_000 - 540_000) * 0.12m + (2_420_000 - 1_210_000) * 0.2m + (4_530_000 - 2_420_000) * 0.3m + (income - 4_530_000) * 0.4m;
            }
            else
            {
                result = 540_000 * 0.05m + (1_210_000 - 540_000) * 0.12m + (2_420_000 - 1_210_000) * 0.2m + (4_530_000 - 2_420_000) * 0.3m + (10_310_000 - 4_530_000) * 0.4m + (income - 10_310_000) * 0.5m;
            }
            return result;
        }
    }
}
