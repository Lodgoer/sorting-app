namespace SortingLibrary_03
{
    public class SelectionSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] SortAscending(T[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j].CompareTo(numbers[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                T temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }
            return numbers;
        }

        public T[] SortDescending(T[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j].CompareTo(numbers[maxIndex]) > 0)
                    {
                        maxIndex = j;
                    }
                }
                T temp = numbers[maxIndex];
                numbers[maxIndex] = numbers[i];
                numbers[i] = temp;
            }
            return numbers;
        }
    }
}
