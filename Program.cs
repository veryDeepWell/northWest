using System;

namespace northWest
{
    class northWest
    {
        static void Main(string[] args)
        {
            int[] supply = new int[] { 50, 40, 20 };
            int[] demand = new int[] { 30, 25, 30, 25 };
            int[,] cost = new int[,]
            {
                {3, 2, 4, 6},
                {2, 3, 1, 2},
                {3, 2, 7, 4}
            };

            int[,] plan = northWestmethod(supply, demand);
            int price = calculatePrice(cost, plan);

            for (int i = 0; i < supply.Length; i++)
            {
                for (int j = 0; j < demand.Length; j++)
                {
                    Console.Write("Coordinates:" + (i + 1) + ", " + (j + 1) + "; Value:" + plan[i, j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(String.Format("Total Price: {0}", price));
        }

        static int[,] northWestmethod(int[] _supply, int[] _demand)
        {
            int[] supply = _supply;
            int[] demand = _demand;

            int i = 0;
            int j = 0;
            int total = 0;

            int[,] result = new int[(supply.Length), (demand.Length)];

            while (total < supply.Length + supply.Length)
            {
                int s = supply[i];
                int d = demand[j];
                int v = 0;

                if (s < d)
                {
                    v = s;
                }
                else
                {
                    v = d;
                }

                supply[i] -= v;
                demand[j] -= v;

                //Append result in result[]
                result[i, j] = v;

                //Check destination
                if (supply[i] == 0 & i < supply.Length)
                {
                    i++;
                    total++;
                }
                else if (demand[j] == 0 & j < demand.Length)
                {
                    j++;
                    total++;
                }
            }

            return result;
        }

        static int calculatePrice(int[,] costTable, int[,] supplyTable)
        {
            int result = 0;

            for (int i = 0; i < supplyTable.GetLength(0); i++)
            {
                for (int j = 0; j < supplyTable.GetLength(1); j++)
                {
                    result += costTable[i, j] * supplyTable[i, j];
                }
            }

            return result;
        }
    }
}
