namespace Project_Euler_Problem_06 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ProblemHelper {
        public static long Process() {
            return GetDifferenceOfSquares();
        }

        public static long GetDifferenceOfSquares() {
            long sumOfSquares = GetSumOfSquares();
            long squareOfNaturals = GetSquareOfNaturalSum();

            long difference = squareOfNaturals - sumOfSquares;
            return difference;
        }

        public static long GetSumOfSquares() {
            long squareSum = 0;

            Parallel.For(1, 101, (i, loopstate) => {
                squareSum += Convert.ToInt64(Math.Pow(i, 2));
            });

            return squareSum;
        }

        public static long GetSquareOfNaturalSum() {
            long naturalSum = GetSumOfNaturalNumbers(0, 100);
            long naturalSquare = (long)Math.Pow((double)naturalSum, 2);
            return naturalSquare;
        }

        public static long GetSumOfNaturalNumbers(int start, int end) {
            int naturalSum = 0;

            Parallel.For(start, (end+1), (i, loopstate) => {
                naturalSum += i;
            });

            return naturalSum;
        }
    }
}
