namespace Project_Euler_Problem_12 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    internal class ProblemHelper {
        internal static string Process() {
            return ProcessIntegers().ToString();
        }

        private static long ProcessIntegers() {
            int n = 1;
            int factors = 0;
            IList<long> primes = GetPrimes();
            long triangleNumber = 0;

            while (true) {
                triangleNumber = GetTriangleNumber(n);
                int numberOfDivisions = GetFactors(triangleNumber, primes);

                if (numberOfDivisions >= 500) {
                    break;
                }

                n++;
            }

            return triangleNumber;
        }

        private static long GetTriangleNumber(int n) {
            return ((n * (n + 1)) / 2);
        }

        /// <summary>
        /// Got some help here: http://www.mathblog.dk/triangle-number-with-more-than-500-divisors/
        /// 
        /// I worked through most of this algorithm on my own, but picked up some pointers from
        /// the blog post.  For example, got that you needed to test for whether the prime you 
        /// are testing as a factor (i.e., primes[i] > number), but his way catches things like
        /// 2 when you are factoring 3.  I'm sure there are other larger number where you have
        /// similar cases.
        /// 
        /// Additionally, didn't catch that if the remainder is 1 then you are done factoring.
        /// 
        /// Also, the number of factors * the exponent is great use of combinatorics to arrive at 
        /// number of divisors.
        /// </summary>
        /// <param name="triangleNumber"></param>
        /// <param name="primes"></param>
        /// <returns></returns>
        private static int GetFactors(long triangleNumber, IList<long> primes) {
            int length = primes.Count;
            long remainder = triangleNumber;
            int numberOfFactors = 1;

            for (int i = 0; i < length; i++) {
                //  If you are factoring 3:  2 * 2 = 4, so return 2 factors, 1 and 3
                if (primes[i] * primes[i] > triangleNumber) {
                    return numberOfFactors *= 2;
                }

                int exponent = 1;
                while ((remainder % primes[i]) == 0) {
                    exponent++;
                    remainder = remainder / primes[i];
                }

                numberOfFactors *= exponent;

                if (remainder == 1) {
                    return numberOfFactors;
                }
            }

            return numberOfFactors;
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
