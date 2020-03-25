using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuickSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the program!");
            List<int> randomList = new List<int>(1000000000);
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                randomList.Add(random.Next());
            }

            bubleSort(randomList.ToArray());
            quickSort(randomList.ToArray());
            Console.WriteLine("End of the program!");
            Console.ReadKey();
        }

        static void bubleSort(int[] array)
        {
            Console.WriteLine("Start of buble sort");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool is_sorted = false;
            int temp;
            for (int i = 0; i < array.Length; i++)
            {

                is_sorted = true;

                for (int j = 1; j < (array.Length - i); j++)
                {

                    if (array[j - 1] > array[j])
                    {
                        temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        is_sorted = false;
                    }

                }

                // is sorted? then break it, avoid useless loop.
                if (is_sorted) break;

            }
            stopwatch.Stop();
            Console.WriteLine("Buble sort executing time: {0} ticks", stopwatch.ElapsedTicks);
        }

        static void quickSort(int[] array)
        {
            Console.WriteLine("Start of quick sort");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            quickSort(array, 0, array.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick sort executing time: {0} ticks", stopwatch.ElapsedTicks);
        }

        static void quickSort(int[] arr, int begin, int end)
        {
            if (begin < end)
            {
                int partitionIndex = partition(arr, begin, end);

                quickSort(arr, begin, partitionIndex - 1);
                quickSort(arr, partitionIndex + 1, end);
            }
        }

        static int partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
