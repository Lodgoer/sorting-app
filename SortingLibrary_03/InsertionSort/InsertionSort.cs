namespace SortingLibrary_03
{
    public class InsertionSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] SortAscending(T[] numbers)
        {
            int n = numbers.Length;
            for (int i = 1; i < n; i++)
            {
                T key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j].CompareTo(key) > 0)
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }
                numbers[j + 1] = key;
            }
            return numbers;
        }

        public T[] SortDescending(T[] numbers)
        {
            int n = numbers.Length;
            for (int i = 1; i < n; i++)
            {
                T key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j].CompareTo(key) < 0)
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }
                numbers[j + 1] = key;
            }
            return numbers;
        }
    }
}
