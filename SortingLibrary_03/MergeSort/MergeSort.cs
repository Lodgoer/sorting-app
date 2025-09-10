namespace SortingLibrary_03
{
    public class MergeSort<T> : ISortable<T> where T : IComparable<T>
    {
        public T[] SortAscending(T[] numbers)
        {
            return MergeSortRecursive(numbers, true);
        }

        public T[] SortDescending(T[] numbers)
        {
            return MergeSortRecursive(numbers, false);
        }

        private T[] MergeSortRecursive(T[] numbers, bool ascending)
        {
            if (numbers.Length <= 1)
                return numbers;

            int middle = numbers.Length / 2;
            T[] left = numbers.Take(middle).ToArray();
            T[] right = numbers.Skip(middle).ToArray();

            left = MergeSortRecursive(left, ascending);
            right = MergeSortRecursive(right, ascending);

            return Merge(left, right, ascending);
        }

        private T[] Merge(T[] left, T[] right, bool ascending)
        {
            List<T> result = new List<T>();
            int i = 0, j = 0;

            while (i < left.Length && j < right.Length)
            {
                if ((ascending && left[i].CompareTo(right[j]) <= 0) || (!ascending && left[i].CompareTo(right[j]) >= 0))
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Length) result.Add(left[i++]);
            while (j < right.Length) result.Add(right[j++]);

            return result.ToArray();
        }
    }
}
