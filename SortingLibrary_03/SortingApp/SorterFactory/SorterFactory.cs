namespace SortingLibrary_03
{
    public class SorterFactory
    {
        public static ISortable<T> GetSortingAlgorithm<T>(string name) where T : IComparable<T>
        {
            return name switch
            {
                "bubble" => new BubbleSort<T>(),
                "select" => new SelectionSort<T>(),
                "insertion" => new InsertionSort<T>(),
                "quick" => new QuickSort<T>(),
                "merge" => new MergeSort<T>(),
                "radix" => new RadixSort<T>(),
                _ => new BubbleSort<T>(),
            };
        }
    }
}
