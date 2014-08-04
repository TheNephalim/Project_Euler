namespace Project_Euler_Problem_07 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class PrimesHelper {
        public static long Process(int index) {
            IList<long> primes = GetPrimes();
            long primeValue = 0;
            int primeIndex = index - 1;

            if (primes.Count() > primeIndex) {
                primeValue = primes[primeIndex];
            } else {
                Console.WriteLine("There are not enough primes to find this value.  Calculate more primes.");
            }

            return primeValue;
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
