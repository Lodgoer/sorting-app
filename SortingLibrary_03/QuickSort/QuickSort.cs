namespace SortingLibrary_03
{
    public class QuickSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] SortAscending(T[] numbers)
        {
            QuickSortRecursive(numbers, 0, numbers.Length - 1);
            return numbers;
        }

        public T[] SortDescending(T[] numbers)
        {
            QuickSortRecursive(numbers, 0, numbers.Length - 1);
            Array.Reverse(numbers);
            return numbers;
        }

        private void QuickSortRecursive(T[] numbers, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(numbers, low, high);
                QuickSortRecursive(numbers, low, pivotIndex - 1);
                QuickSortRecursive(numbers, pivotIndex + 1, high);
            }
        }

        private int Partition(T[] numbers, int low, int high)
        {
            T pivot = numbers[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (numbers[j].CompareTo(pivot) < 0)
                {
                    i++;
                    T temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
            T swapTemp = numbers[i + 1];
            numbers[i + 1] = numbers[high];
            numbers[high] = swapTemp;
            return i + 1;
        }
    }
}
