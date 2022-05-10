﻿using System;

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
            HoareSort(items, 1, -1, items.Length);
        }
        static void HoareSort<T>(T[] items, int pivot, int left, int right) where T : IComparable<T>
        {

        }


        static void Main(string[] args)
        {
            int[] items = new int[] {7, 4, 3, 6, 2, 1, 5};

            LomutoSort(items);

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}