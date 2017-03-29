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
            int level = GetLevel(income);
            return CalcTax(income, level);
        }

        private static int GetLevel(decimal income)
        {
            foreach (var boundaryRate in BoundaryRateTable)
            {
                if (income <= boundaryRate.Boundary)
                    return boundaryRate.Level - 1;
            }
            return BoundaryRateTable.Count;
        }

        private static decimal CalcTax(decimal income, int level)
        {
            decimal tax = 0;
            for (int i = 1; i <= level; i++)
            {
                tax += (BoundaryRateTable[i].Boundary - BoundaryRateTable[i - 1].Boundary)
                       * BoundaryRateTable[i - 1].TaxRate;
            }
            tax += (income - BoundaryRateTable[level].Boundary)
                   * BoundaryRateTable[level].TaxRate;
            return tax;
        }
    }
}
