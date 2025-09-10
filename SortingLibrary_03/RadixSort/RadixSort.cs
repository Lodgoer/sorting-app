using System;
using System.Linq;

namespace SortingLibrary_03
{
    public class RadixSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] SortAscending(T[] numbers)
        {
            return RadixSortRecursive(numbers, true);
        }

        public T[] SortDescending(T[] numbers)
        {
            return RadixSortRecursive(numbers, false);
        }

        private T[] RadixSortRecursive(T[] numbers, bool ascending)
        {
            // Convert the generic array to int[] for sorting
            int[] intNumbers = numbers.Select(num => Convert.ToInt32(num)).ToArray();

            int max = intNumbers.Max();
            int digitPlace = 1;

            // Perform counting sort for each digit
            while (max / digitPlace > 0)
            {
                intNumbers = CountingSort(intNumbers, digitPlace, ascending);
                digitPlace *= 10;
            }

            // Convert back to generic T[] before returning
            return intNumbers.Select(num => (T)Convert.ChangeType(num, typeof(T))).ToArray();
        }

        private int[] CountingSort(int[] numbers, int digitPlace, bool ascending)
        {
            int[] sortedArray = new int[numbers.Length];
            int[] count = new int[10];

            // Counting occurrences of digits
            foreach (var num in numbers)
            {
                int digit = (num / digitPlace) % 10;
                count[digit]++;
            }

            // Calculate cumulative count (for stable sorting)
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            // Sort the numbers based on the current digit
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int digit = (numbers[i] / digitPlace) % 10;
                int index = count[digit] - 1;
                sortedArray[index] = numbers[i];
                count[digit]--;
            }

            // If descending, reverse the array
            if (!ascending)
            {
                Array.Reverse(sortedArray);
            }

            return sortedArray;
        }
    }
}
