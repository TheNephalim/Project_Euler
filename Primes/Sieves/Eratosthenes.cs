namespace Primes.Sieves {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class Eratosthenes {
        public Eratosthenes() {
        }

        public IList<long> GeneratePrimes(long limit)  {
            IList<long> primes = new List<long>();

            primes.Add(2);

            for (long i = 3; i <= limit; i += 2) {
                if (IsPrime(primes, i)) {
                    primes.Add(i);
                }
            }

            return primes;
        }

        public void SaveToFile(string filePath, long limit) {
            using (Stream stream = new FileStream(filePath, FileMode.OpenOrCreate)) {
                using (StreamWriter writer = new StreamWriter(stream)) {
                    IList<long> primes = GeneratePrimes(limit);
                    foreach (long prime in primes) {
                        writer.WriteLine(prime);
                    }
                }
            }
        }

        private bool IsPrime(IList<long> primes, long valueToCheck) {
            bool isPrime = true;
            double limit = Math.Sqrt(valueToCheck);

            Parallel.ForEach<long>(primes, (prime, loopstate) => {
                if (((valueToCheck % prime) == 0) && (prime <= limit)) {
                    isPrime = false;
                    loopstate.Stop();
                }
            });

            return isPrime;
        }
    }
}
