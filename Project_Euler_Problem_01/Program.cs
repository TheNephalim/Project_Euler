using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Euler_Problem_01 {
    public class Program {
        static void Main(string[] args) {
            Console.WriteLine(string.Format("The answer is {0}", EulerProblemOne.SumOfMultiples()));
        }

    }

    public static class EulerProblemOne {
        public static int SumOfMultiples() {
            List<Int32> multiples = new List<Int32>();
            GetValuesUnder1000(multiples);

            int sum = 0;

            for (int i = 0; i < multiples.Count; i++) {
                sum += multiples[i];
            }

            return sum;
        }

        private static void GetValuesUnder1000(List<int> listOfMultiples) {
            for (int i = 0; i < 1000; i++) {
                if (TestMultipleFor(i)) {
                    listOfMultiples.Add(i);
                }
            }
        }

        private static bool TestMultipleFor(int valueToTest) {
            if (IsMultipleOfFive(valueToTest) || IsMultipleOfThree(valueToTest)) {
                return true;
            }

            return false;
        }

        private static bool IsMultipleOfThree(int valueToTest) {
            if ((valueToTest % 3) == 0) {
                return true;
            }

            return false;
        }

        private static bool IsMultipleOfFive(int valueToTest) {
            if ((valueToTest % 5) == 0) {
                return true;
            }

            return false;
        }
    }
}
