namespace Project_Euler_Problem_20 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;

    public static class ProblemHelper {

        public static BigInteger Process(BigInteger valueToCalculate) {
            return SumOfFactorial(Factorial(valueToCalculate));
        }

        private static BigInteger Factorial(BigInteger value) {
            BigInteger factorial = 1;
 
            for(BigInteger i = 1; i <= value; i++) {
                factorial *= i;
            }

            return factorial;
        }

        private static BigInteger SumOfFactorial(BigInteger factorial) {
            char[] factorialArray = factorial.ToString().ToCharArray();
            Int64 value = 0;

            value = factorialArray.Sum<char>(c => Int64.Parse(c.ToString()));

            return value;
        }
    }
}
