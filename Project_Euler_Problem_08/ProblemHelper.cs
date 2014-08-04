namespace Project_Euler_Problem_08 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Numerics;

    internal class ProblemHelper {
        public static BigInteger Process() {
            IList<string> multiples = GetMultiples();
            IList<int> products = GetProducts(multiples);
            int value = products.Max();

            return value;
        }

        private static IList<int> GetProducts(IList<string> multiples) {
            IList<int> products = new List<int>();

            for (int i = 0; i < multiples.Count(); ++i) {
                int value = 1;

                for (int j = 0; j < multiples[i].Length; ++j) {
                    value *= Convert.ToInt32((multiples[i][j]).ToString());
                }

                products.Add(value);
            }

            return products;
        }

        private static IList<string> GetMultiples() {
            IList<string> multiples = new List<string>();

            string number = GetNumberFromFile();
            number = number.Replace(System.Environment.NewLine, string.Empty);

            for (int i = 0; i <= number.Length - 5; ++i) {
                multiples.Add(number.Substring(i, 5));
            }

            return multiples;

        }

        private static string GetNumberFromFile() {
            string number = string.Empty;
            using (Stream stream = new FileStream("Thousand.txt", FileMode.Open)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    number = reader.ReadToEnd();
                }
            }

            return number;
        }

    }

}
