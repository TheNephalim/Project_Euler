namespace Project_Euler_Problem_13 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;
    using System.IO;

    internal static class ProgramHelper {
        internal static BigInteger Process() {
            return SumOfIntegers();
        }

        public static BigInteger SumOfIntegers() {
            IList<BigInteger> integers = GetIntegers();
            BigInteger sum = 0;

            for (int i = 0; i < integers.Count; i++) {
                sum += integers[i];
            }

            return sum;
        }

        public static IList<BigInteger> GetIntegers() {
            IList<BigInteger> integers = new List<BigInteger>();

            using (Stream stream = new FileStream("TextFile1.txt", FileMode.Open, FileAccess.Read)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    while (!reader.EndOfStream) {
                        integers.Add(BigInteger.Parse(reader.ReadLine()));
                    }
                }
            }

            return integers;
        }
    }
}
