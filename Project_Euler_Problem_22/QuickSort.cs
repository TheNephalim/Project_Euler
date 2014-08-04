namespace Project_Euler_22 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    public static class QuickSort {
        public static void Sort(string[] listToSort) {
            RecursiveQuickSort(listToSort, 0, listToSort.Length - 1);
        }

        private static void RecursiveQuickSort(string[] listToSort, int start, int end) {
            if (start < end) {
                string pivot = listToSort[start];
                int position = PartitionNamesSequence(listToSort, start, end);
                RecursiveQuickSort(listToSort, start, position - 1);
                RecursiveQuickSort(listToSort, position + 1, end);
            }
        }

        private static int PartitionNamesSequence(string[] listToPartition, int start, int end) {
            string pivot = listToPartition[start];

            int left = start + 1;
            int right = end;

            while (left <= right) {
                left = FindFirstKeyPositionLargerThanPivot(listToPartition, pivot, left, right);
                right = FindLastPositionLessThanPivot(listToPartition, pivot, left, right);

                SwapLeft(listToPartition, ref left, ref right);
            }

            SwapRight(listToPartition, start, right);

            return right;
        }

        private static void SwapRight(string[] listToPartition, int start, int right) {
            SwapElements(listToPartition, start, right);
        }

        private static void SwapLeft(string[] listToPartition, ref int left, ref int right) {
            if (left < right) {
                SwapElements(listToPartition, left, right);
                ++left;
                --right;
            }
        }

        private static int FindLastPositionLessThanPivot(string[] listToPartition, string pivot, int left, int right) {
            while ((left <= right) && listToPartition[right].ToUpper().CompareTo(pivot) > 0) {
                --right;
            }

            return right;
        }

        private static int FindFirstKeyPositionLargerThanPivot(string[] listToPartition, string pivot, int left, int right) {
            while ((left <= right) && listToPartition[left].ToUpper().CompareTo(pivot) <= 0) {
                ++left;
            }

            return left;
        }

        private static void SwapElements(string[] listToPartition, int left, int right) {
            string tmp = listToPartition[left];
            listToPartition[left] = listToPartition[right];
            listToPartition[right] = tmp;
        }
    }
}
