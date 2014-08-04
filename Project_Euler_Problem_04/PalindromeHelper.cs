namespace Project_Euler_Problem_04 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class PalindromeHelper {
        public static long Process() {
            IList<long> palindromes = null;
            IList<long> products = null;

            products = GetProducts();
            palindromes = GetPalindromes(products);

            return palindromes.Max();
        }

        private static IList<long> GetPalindromes(IList<long> products) {
            IList<long> palindromes = new List<long>();

            foreach(int product in products) {
                var forwardArray = Convert.ToString(product).ToArray();
                var reverseArray = forwardArray.Reverse();

                if (forwardArray.SequenceEqual(reverseArray)) {
                    palindromes.Add(product);
                }
            }

            return palindromes;
        }

        private static IList<long> GetProducts() {
            IList<long> products = new List<long>();

            for (int i = 100; i <= 999; ++i) {
                for (int j = 100; j <= 999; j++) {
                    products.Add(i*j);    
                }
            }

            return products;
        }
    }
}
