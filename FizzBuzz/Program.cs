using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz {
    public class Program {
        public static void Main(string[] args) {
            for(int i = 1; i <= 100; i++) {
                if (IsMultipleOfThreeAndFive(i)) {
                    Console.WriteLine("FizzBuzz");
                } else if (IsMultipleOfThree(i)) {
                    Console.WriteLine("Fizz");
                } else if (IsMultipleOfFive(i)) {
                    Console.WriteLine("Buzz");
                } else {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsMultipleOfThreeAndFive(int i) {
            return (((i % 3) == 0) && ((i % 5) == 0));
        }

        private static bool IsMultipleOfThree(int i) {
            return ((i % 3) == 0);
        }

        private static bool IsMultipleOfFive(int i) {
            return ((i % 5) == 0);
        }
    }
}
