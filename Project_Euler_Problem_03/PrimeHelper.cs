using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Euler_Problem_03 {
    public static class PrimeHelper {
        public static int Process(int factor) {
            int limit = (int)Math.Floor(Math.Sqrt(factor));

            int blah = ApproximateNthPrime(factor);
            return 0;
        }

        private static int ApproximateNthPrime(int limit) {
            double n = (double)limit;
            double candidate;

            if (limit >= 7022) {
                candidate = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            } else if (limit >= 6) {
                candidate = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            } else if (limit > 0) {
                candidate = new int[] { 2, 3, 5, 7, 11 }[limit - 1];
            } else {
                candidate = 0;
            }

            return (int)candidate;
        }

        private static bool isPrime(int number) {
            if (number.Equals(1)) {
                return false;
            }

            if (number.Equals(2)) {
                return false;
            }

            for (int i = 2; i < number; ++i) {
                if ((number % i).Equals(0)) {
                    return false;
                }
            }

            return true;
        }
    }
}
