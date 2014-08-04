using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Euler_25 {
    public class Program {
        public static void Main(string[] args) {
            int term = Fibonacci.Calculate();
            Console.WriteLine("Term is " + term.ToString());
        }
    }
}
