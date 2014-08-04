namespace Project_Euler_22 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StringHelper {
        private static IList<char> alphabet = new List<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' });

        public static int GetNameValue(string name) {
            char[] nameArray = name.ToUpper().ToCharArray();
            int value = 0;

            for (int i = 0; i < nameArray.Length; i++) {
                value = value + (alphabet.ToList<char>().IndexOf(nameArray[i]) + 1);
            }

            return value;
        }
    }
}
