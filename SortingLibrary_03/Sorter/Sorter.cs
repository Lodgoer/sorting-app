namespace SortingLibrary_03
{
    public class Sorter<T>
    {
        private readonly ISortable<T> _sortStrategy;

        public Sorter(ISortable<T> sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public T[] SortAscending(T[] numbers)
        {
            return _sortStrategy.SortAscending(numbers);
        }

        public T[] SortDescending(T[] numbers)
        {
            return _sortStrategy.SortDescending(numbers);
        }
    }
}