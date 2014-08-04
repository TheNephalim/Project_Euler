namespace Project_Euler_Problem_10 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    internal class PrimesHelper {
        public static long Process() {
            IList<long> primes = GetPrimes();

            return primes.Sum();
        }

        private static IList<long> GetPrimes() {
            IList<long> primes = new List<long>();

            using (StreamReader reader = LoadPrimeFile()) {
                while (!reader.EndOfStream) {
                    primes.Add(Convert.ToInt64(reader.ReadLine()));
                }
            }

            return primes;
        }

        private static StreamReader LoadPrimeFile() {
            Stream stream = new FileStream("primes.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            return reader;
        }
    }
}
