namespace Project_Euler_Problem_03 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Primes;
    using System.IO;

    public class FactorizationHelper {
        public static long Process(long valueToCheck) {
            IList<long> primes = GetPrimes();
            IList<long> factors = new List<long>();
            long valueCopy = valueToCheck;

            for (int i = 0; i < primes.Count; ++i) {
                if (((valueCopy % primes[i]) == 0) && primes[i] < Math.Sqrt(valueToCheck)) {
                    factors.Add(primes[i]);
                    valueCopy = valueCopy / primes[i];
                }
            }
            primes.Sum();
            return factors.Max();
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
