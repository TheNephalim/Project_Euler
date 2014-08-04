namespace Project_Euler_Problem_21 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    internal class ProblemHelper {
        /// <summary>
        /// <para>Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).</para>
        /// <para>If d(a) = b and d(b) = a, where a  b, then a and b are an amicable pair and each of a and b are called amicable numbers.</para>
        /// <para>For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.</para>
        /// <para>Evaluate the sum of all the amicable numbers under 10000.</para>
        /// </summary>
        internal static long Process() {
            return ProcessValues();
        }

        private static long ProcessValues() {
            IList<long> primes = GetPrimes();
            IList<long> amicablePairs = new List<long>();

            for (int i = 1; i < 10000; i++) {
                IList<long> divisors = GetProperDivisors(i, GetFactors(i, primes));
                long sum = divisors.Sum();

                IList<long> divisors2 = GetProperDivisors(sum, GetFactors(sum, primes));
                long sum2 = divisors2.Sum();

                if (i == sum2 && i != sum) {
                    amicablePairs.Add(i);
                }

                string myString = string.Empty;
            }

            return amicablePairs.Sum();
        }

        private static IList<long> GetFactors(long number, IList<long> primes) {
            int length = primes.Count;
            long remainder = number;

            IList<long> factors = new List<long>();
            factors.Add(1);

            for (int i = 0; i < length; i++) {
                if (primes[i] >= number) {
                    factors.Add(number);
                    return factors;
                }

                int exponent = 0;
                while ((remainder % primes[i]) == 0 && primes[i] != number) {
                    exponent++;
                    remainder = remainder / primes[i];
                }

                if (GetExponentValue(primes[i], exponent) != number) {
                    GetExponentialFactors(primes[i], exponent, factors);
                } else {
                    GetExponentialFactors(primes[i], exponent - 1, factors);
                }

                if (remainder == 1) {
                    factors.Add(number);
                    return factors;
                }
            }

            return factors;
        }

        private static IList<long> GetProperDivisors(long number, IList<long> factors) {
            IList<long> properDivisors = new List<long>();
            int maxMultiplier = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(number)));
                
            for (int i = 1; i <= maxMultiplier; i++) {
                for (int j = 0; j < factors.Count; j++) {
                    long product = i * factors[j];

                    if ((number % product) == 0 && product < number) {
                        if (!properDivisors.Contains(product)) {
                            properDivisors.Add(product);
                        }
                    }
                }
            }

            return properDivisors;
        }

        private static void GetExponentialFactors(long baseNumber, int exponent, IList<long> factors) {
            for (int i = 1; i <= exponent; i++) {
                factors.Add(GetExponentValue(baseNumber, i));
            }
        }

        private static long GetExponentValue(long baseNumber, long exponent) {
            return Convert.ToInt64(Math.Pow(Convert.ToDouble(baseNumber), Convert.ToDouble(exponent)));
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
