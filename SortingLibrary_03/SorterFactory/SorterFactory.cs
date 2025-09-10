namespace SortingLibrary_03
{
    public class SorterFactory
    {
        public static ISortable<T> CreateSorter<T>(T[] numbers) where T : IComparable<T>
        {
            if (numbers.Length <= 10)
            {
                return new InsertionSort<T>();
            }
            else
            {
                return new QuickSort<T>();
            }
        }
    }
}
