using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Project_Euler_Problem_16 {
    public class Program {
        public static void Main(string[] args) {
            int result = ExponentProcessor.Process(2, 1000);
            Console.WriteLine(result);
        }
    }
}
