using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal static class Sorting
    {



        public static void QuickSortRecursive<T>(
            T[] array,
            Func<T, T, int> comparator,
            long start,
            long end,
            bool ascending = true,
            Predicate<T>? predicate = null
        )
        {
            if (start > end)
            {
                throw new ArgumentException("Start position of the range was bigger than last position of the range");
            }

            if (start < 0 || end < 0)
            {
                throw new ArgumentException("One of range's limits was negative");
            }

            if (predicate != null)
            {
                var tempArr = array
                    .Where((i, ind) => predicate(i) && ind >= start && ind <= end)
                    .ToArray();

                if (tempArr.Length == 0) return;

                QuickSortRecursiveInternal(tempArr, 0, tempArr.Length - 1, comparator);

                if (!ascending) tempArr = tempArr.Reverse().ToArray();

                for (long i = start, j = 0; i <= end; i++)
                {
                    if (!predicate(array[i])) continue;

                    array[i] = tempArr[j++];
                }
            }
            else
            {
                QuickSortRecursiveInternal(array, start, end, comparator);
                if (ascending) return;

                for (long i = start, j = end; i != (i + j + 1) / 2; i++, j--)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }

        private static void QuickSortRecursiveInternal<T>(T[] array, long sInd, long eInd, Func<T, T, int> comparison)
        {
            if (sInd >= eInd) return;
            var pivInd = PartitionInternal(array, sInd, eInd, comparison);

            if (pivInd > 1)
            {
                QuickSortRecursiveInternal(array, sInd, pivInd - 1, comparison);
            }

            if (pivInd + 1 < eInd)
            {
                QuickSortRecursiveInternal(array, pivInd + 1, eInd, comparison);
            }
        }





        public static void QuickSortIterative<T>(T[] array,
            Func<T, T, int> comparator,
            long start,
            long end,
            bool ascending = true,
            Predicate<T>? predicate = null
        )
        {
            if (start > end)
            {
                throw new ArgumentException("Start position of the range was bigger than last position of the range");
            }

            if (start < 0 || end < 0)
            {
                throw new ArgumentException("One of range's limits was negative");
            }

            if (predicate != null)
            {
                var tempArr = array
                    .Where((i, ind) => predicate(i) && ind >= start && ind <= end)
                    .ToArray();

                QuickSortIterativeInternal(tempArr, 0, tempArr.Length - 1, comparator);

                if (!ascending) tempArr = tempArr.Reverse().ToArray();

                for (long i = start, j = 0; i <= end; i++)
                {
                    if (!predicate(array[i])) continue;

                    array[i] = tempArr[j++];
                }
            }
            else
            {
                QuickSortIterativeInternal(array, start, end, comparator);
                if (ascending) return;

                for (long i = start, j = end; i != (i + j + 1) / 2; i++, j--)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                }

            }

        }

        private static void QuickSortIterativeInternal<T>(T[] array, long sInd, long eInd, Func<T, T, int> comparator)
        {
            if (sInd >= eInd) return;

            long[] stack = new long[eInd - sInd + 1];
            long top = -1;
            stack[++top] = sInd;
            stack[++top] = eInd;

            while (top >= 0)
            {
                eInd = stack[top--];
                sInd = stack[top--];

                var pivInd = PartitionInternal(array, sInd, eInd, comparator);

                if (pivInd - 1 > sInd)
                {
                    stack[++top] = sInd;
                    stack[++top] = pivInd - 1;
                }

                if (pivInd + 1 >= eInd) continue;

                stack[++top] = pivInd + 1;
                stack[++top] = eInd;
            }
        }

        private static long PartitionInternal<T>(T[] array, long left, long right, Func<T, T, int> comparator)
        {
            var pivot = array[left];
            while (true)
            {
                while (comparator(array[left], pivot) < 0)
                {
                    left++;
                }

                while (comparator(array[right], pivot) > 0)
                {
                    right--;
                }

                if (left < right)
                {

                    (array[left], array[right]) = (array[right], array[left]);

                    if (comparator(array[left], array[right]) == 0)
                    {
                        left++;
                    }
                }
                else
                {
                    return right;
                }
            }
        }



        public static void HeapSort<T>(T[] array,
            Func<T, T, int> comparator,
            long start,
            long end,
            bool ascending = true,
            Predicate<T>? predicate = null
        )
        {
            if (start > end)
            {
                throw new ArgumentException("Start position of the range was bigger than last position of the range");
            }

            if (start < 0 || end < 0)
            {
                throw new ArgumentException("One of range's limits was negative");
            }

            var arrRange = array.Where((i, ind) => ind >= start && ind <= end).ToArray();

            if (predicate != null)
            {
                var tempArr = arrRange
                    .Where((i, ind) => predicate(i))
                    .ToArray();

                HeapSortInternal(tempArr, comparator);

                if (!ascending) tempArr = tempArr.Reverse().ToArray();

                for (long i = 0, j = 0; i <= end; i++)
                {
                    if (!predicate(arrRange[i])) continue;

                    arrRange[i] = tempArr[j++];
                }
            }
            else
            {
                HeapSortInternal(arrRange, comparator);
                if (!ascending)
                {
                    for (long i = start, j = end; i != (i + j + 1) / 2; i++, j--)
                    {
                        (arrRange[i], arrRange[j]) = (arrRange[j], arrRange[i]);
                    }
                }
            }

            for (long i = start, j = 0; i <= end; ++i)
            {
                array[i] = arrRange[j++];
            }

        }

        private static void HeapSortInternal<T>(T[] arr, Func<T, T, int> comparator)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyInternal(arr, n, i, comparator);

            for (int i = n - 1; i > 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);

                HeapifyInternal(arr, i, 0, comparator);
            }
        }

        private static void HeapifyInternal<T>(T[] arr, int n, int i, Func<T, T, int> comparator)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;


            if (l < n && comparator(arr[l], arr[largest]) == 1)
                largest = l;


            if (r < n && comparator(arr[r], arr[largest]) == 1)
                largest = r;


            if (largest == i) return;

            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            HeapifyInternal(arr, n, largest, comparator);
        }



    }
}
