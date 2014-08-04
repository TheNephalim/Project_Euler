namespace Project_Euler_25 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;

    public class Fibonacci {
        public static int Calculate() {
            int term = 0;
            BigInteger limit = BigInteger.Pow(10, 999);
            term = GetFibonacciTerm(10, 999);
            //while (true) {
            //    //double value = GetFibonacciTerm(term);

            //    if ((BigInteger)value > limit) {
            //        break;
            //    }

            //    term++;
            //}

            return term;
        }

        //public static double GetFibonacciTerm(int term) {
        //    double psi = 1 - GetPhi();
        //    double fibValue = (double)((BigInteger.Pow((BigInteger)GetPhi(), term) - BigInteger.Pow((BigInteger)psi, term)) / Math.Sqrt(5));
            
        //    return fibValue;
        //}

        public static int GetFibonacciTerm(int limitBase, int limitPower) {
            int termValue = (int)Math.Round((((Math.Log10(10) * 999) + (Math.Log10(5) / 2)) / Math.Log10(GetPhi())));
            return termValue;
        }

        public static double GetPhi() {
            return ((1 + Math.Sqrt(5)) / 2);
        }
    }
}
