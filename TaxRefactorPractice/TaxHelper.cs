using System.Collections.Generic;

namespace TaxRefactorPractice
{
    public class TaxHelper
    {
        private class BoundaryRate
        {
            public short Level;
            public decimal Boundary;
            public decimal TaxRate;
        }

        private static readonly List<BoundaryRate> BoundaryRateTable = new List<BoundaryRate>
        {
            new BoundaryRate{ Level = 0, Boundary =          0 , TaxRate = 0.05m },
            new BoundaryRate{ Level = 1, Boundary =    540_000 , TaxRate = 0.12m },
            new BoundaryRate{ Level = 2, Boundary =  1_210_000 , TaxRate = 0.2m  },
            new BoundaryRate{ Level = 3, Boundary =  2_420_000 , TaxRate = 0.3m  },
            new BoundaryRate{ Level = 4, Boundary =  4_530_000 , TaxRate = 0.4m  },
            new BoundaryRate{ Level = 5, Boundary = 10_310_000 , TaxRate = 0.5m  },
            new BoundaryRate{ Level = 6, Boundary = long.MaxValue },
        };

        public static decimal GetTaxResult(decimal income)
        {
            decimal result = 0;
            if (income < BoundaryRateTable[1].Boundary)
            {
                result = income * BoundaryRateTable[0].TaxRate;
            }
            else if (income < BoundaryRateTable[2].Boundary)
            {
                result = BoundaryRateTable[1].Boundary * BoundaryRateTable[0].TaxRate + (income - BoundaryRateTable[1].Boundary) * BoundaryRateTable[1].TaxRate;
            }
            else if (income < BoundaryRateTable[3].Boundary)
            {
                result = BoundaryRateTable[1].Boundary * BoundaryRateTable[0].TaxRate + (BoundaryRateTable[2].Boundary - BoundaryRateTable[1].Boundary) * BoundaryRateTable[1].TaxRate + (income - BoundaryRateTable[2].Boundary) * BoundaryRateTable[2].TaxRate;
            }
            else if (income < BoundaryRateTable[4].Boundary)
            {
                result = BoundaryRateTable[1].Boundary * BoundaryRateTable[0].TaxRate + (BoundaryRateTable[2].Boundary - BoundaryRateTable[1].Boundary) * BoundaryRateTable[1].TaxRate + (BoundaryRateTable[3].Boundary - BoundaryRateTable[2].Boundary) * BoundaryRateTable[2].TaxRate + (income - BoundaryRateTable[3].Boundary) * BoundaryRateTable[3].TaxRate;
            }
            else if (income < BoundaryRateTable[5].Boundary)
            {
                result = BoundaryRateTable[1].Boundary * BoundaryRateTable[0].TaxRate + (BoundaryRateTable[2].Boundary - BoundaryRateTable[1].Boundary) * BoundaryRateTable[1].TaxRate + (BoundaryRateTable[3].Boundary - BoundaryRateTable[2].Boundary) * BoundaryRateTable[2].TaxRate + (BoundaryRateTable[4].Boundary - BoundaryRateTable[3].Boundary) * BoundaryRateTable[3].TaxRate + (income - BoundaryRateTable[4].Boundary) * BoundaryRateTable[4].TaxRate;
            }
            else
            {
                result = BoundaryRateTable[1].Boundary * BoundaryRateTable[0].TaxRate + (BoundaryRateTable[2].Boundary - BoundaryRateTable[1].Boundary) * BoundaryRateTable[1].TaxRate + (BoundaryRateTable[3].Boundary - BoundaryRateTable[2].Boundary) * BoundaryRateTable[2].TaxRate + (BoundaryRateTable[4].Boundary - BoundaryRateTable[3].Boundary) * BoundaryRateTable[3].TaxRate + (BoundaryRateTable[5].Boundary - BoundaryRateTable[4].Boundary) * BoundaryRateTable[4].TaxRate + (income - BoundaryRateTable[5].Boundary) * BoundaryRateTable[5].TaxRate;
            }
            return result;
        }
    }
}
