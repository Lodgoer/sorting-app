namespace SortingLibrary_03
{
    public class BubbleSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] SortAscending(T[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "The input array cannot be null.");
            }
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j].CompareTo(numbers[j + 1]) > 0)
                    {
                        T temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }

        public T[] SortDescending(T[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "The input array cannot be null.");
            }

            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j].CompareTo(numbers[j + 1]) < 0)
                    {
                        T temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }
    }
}

