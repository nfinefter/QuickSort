using System;
using System.Linq;

namespace QuickSort
{


    class Program
    { 
        static void LomutoSort<T>(T[] items) where T : IComparable<T>
        {
            LomutoSort(items, 0, items.Length - 1);
        }

        static void LomutoSort<T>(T[] items, int left, int right) where T : IComparable<T>
        {
            if (left >= right) return;

            int wall = LomutoPartition(items, left, right);
            LomutoSort(items, left, wall - 1);
            LomutoSort(items, wall + 1, right);
        }

        static int LomutoPartition<T>(T[] items, int left, int right) where T : IComparable<T>
        {
            int wall = left - 1;
            int pivot = right;

            for (int i = left; i < right; i++)
            {
                if (items[i].CompareTo(items[pivot]) <= 0)
                {
                    wall++;
                    Swap(ref items[i], ref items[wall]);
                }
            }

            wall++;
            Swap(ref items[wall], ref items[pivot]);

            return wall;
        }

        static void Swap<T>(ref T a, ref T b) where T : IComparable<T>
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void HoareSort<T>(T[] items) where T : IComparable<T>
        {
            HoareSort(items, 0, items.Length - 1);
        }

        static void HoareSort<T>(T[] items, int left, int right) where T : IComparable<T>
        {
            if (left == right) return;

            HoarePartition(items, left, right);

            HoareSort(items, 0, left);
            HoareSort(items, left + 1, right);
            //fix these, needs more work.
        }

        static int HoarePartition<T>(T[] items, int left, int right) where T : IComparable<T>
        {
            int pivot = left;

            while (true)
            {
                do
                {
                    left++;
                } while (items[left].CompareTo(items[pivot]) < 0);

                do
                {
                    right--;
                } while (items[right].CompareTo(items[pivot]) > 0);

                if (left <= right)
                {
                    break;
                }

                Swap(ref items[left], ref items[right]);
            }

            return left;
        }



        static void Main(string[] args)
        {
            //int[] items = new int[] {7, 4, 3, 6, 2, 1, 5};
            Random random = new Random();
            int[] items = Enumerable.Repeat(0, 20).Select(n => random.Next(1, 1000)).ToArray();

            int[] original = items.ToArray();

            //LomutoSort(items);
            HoareSort(items);

            bool isSorted = items.SequenceEqual(original.OrderBy(n => n));

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
