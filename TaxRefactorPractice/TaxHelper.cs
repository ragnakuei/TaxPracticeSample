namespace TaxRefactorPractice
{
    public class TaxHelper
    {
        private const int _boundary1 = 540_000;
        private const int _boundary2 = 1_210_000;
        private const int _boundary3 = 2_420_000;
        private const int _boundary4 = 4_530_000;
        private const int _boundary5 = 10_310_000;
        private const decimal _rate0 = 0.05m;
        private const decimal _rate1 = 0.12m;
        private const decimal _rate2 = 0.2m;
        private const decimal _rate3 = 0.3m;
        private const decimal _rate4 = 0.4m;
        private const decimal _rate6 = 0.5m;

        public static decimal GetTaxResult(decimal income)
        {
            decimal result = 0;
            if (income < _boundary1)
            {
                result = income * _rate0;
            }
            else if (income < _boundary2)
            {
                result = _boundary1 * _rate0 + (income - _boundary1) * _rate1;
            }
            else if (income < _boundary3)
            {
                result = _boundary1 * _rate0 + (_boundary2 - _boundary1) * _rate1 + (income - _boundary2) * _rate2;
            }
            else if (income < _boundary4)
            {
                result = _boundary1 * _rate0 + (_boundary2 - _boundary1) * _rate1 + (_boundary3 - _boundary2) * _rate2 + (income - _boundary3) * _rate3;
            }
            else if (income < _boundary5)
            {
                result = _boundary1 * _rate0 + (_boundary2 - _boundary1) * _rate1 + (_boundary3 - _boundary2) * _rate2 + (_boundary4 - _boundary3) * _rate3 + (income - _boundary4) * _rate4;
            }
            else
            {
                result = _boundary1 * _rate0 + (_boundary2 - _boundary1) * _rate1 + (_boundary3 - _boundary2) * _rate2 + (_boundary4 - _boundary3) * _rate3 + (_boundary5 - _boundary4) * _rate4 + (income - _boundary5) * _rate6;
            }
            return result;
        }
    }
}
