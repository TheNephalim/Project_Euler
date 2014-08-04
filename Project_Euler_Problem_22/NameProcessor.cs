namespace Project_Euler_22 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class NameProcessor {
        public static int Process(string path) {
            string[] names = FileHelper.GetNames(path);
            QuickSort.Sort(names);

            return ProcessNames(names);
        }

        public static int ProcessNames(string[] names) {
            int value = 0;

            for (int i = 0; i < names.Length; i++) {
                int orderValue = i + 1;
                value = value + (orderValue * StringHelper.GetNameValue(names[i]));
            }

            return value;
        }
    }
}
