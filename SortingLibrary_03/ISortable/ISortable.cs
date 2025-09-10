namespace SortingLibrary_03
{
    public interface ISortable<T>
    {
        T[] SortAscending(T[] numbers);
        T[] SortDescending(T[] numbers);
    }
}
