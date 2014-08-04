using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Euler_Problem_02 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(string.Format("The result is {0}.", Euler_Problem_02.GetEulerValue()));
        }
    }

    public static class Euler_Problem_02 {
        public static int GetEulerValue() {
            int limit = 4000000;
            List<int> evenTerms = new List<int>();

            GetFibonacciTerms(evenTerms, limit);
            int result = SumFibbonacciTerms(evenTerms);
            return result;
        }

        private static int SumFibbonacciTerms(List<int> terms) {
            int sum = 0;

            for(int i = 0; i < terms.Count; i++) {
                sum += terms[i];
            }

            return sum;
        }

        private static void GetFibonacciTerms(List<int> evenTerms, int limit) {
            int term1 = 0;
            int term2 = 1;
            int nextNumber;

            while (term2 < limit) {
                nextNumber = term1 + term2;
                term1 = term2;
                term2 = nextNumber;
                AddToTermList(nextNumber, evenTerms);
            }
        }

        private static void AddToTermList(int i, List<int> termList) {
            if (IsNumberEven(i)) {
                termList.Add(i);
            }
        }

        private static bool IsNumberEven(int i) {
            if ((i % 2) == 0) {
                return true;
            }

            return false;
        }

    }
}
