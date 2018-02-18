using System;

namespace Inlupp1
{
    internal class Sorter
    {
        int[] numbers = { 5, -3, 22, 9001, -33, -105, -88, 1004, 5832, -2602 };
        public Sorter()
        {
            Start();
        }

        private void Start()
        {
            PrintArray("Unsorted", numbers);

            PrintArray("BubbleSort", BubbleSort());

            //MergeSort

            //QuickSort();
        }

        private int[] BubbleSort()
        {
            int[] ListToSort = numbers;
            for (int i = ListToSort.Length - 2; i >= 0; i--)
            {
                int current = i;
                int compare = current + 1;
                while (ListToSort[current] > ListToSort[compare])
                {
                    int temp = ListToSort[current];
                    ListToSort[current] = ListToSort[compare];
                    ListToSort[compare] = temp;
                    if (current < ListToSort.Length - 2)
                    {
                        current = compare;
                        compare++;
                    }
                }

            }
            return ListToSort;
        }

        private void PrintArray(string nameOfArray, int[] array)
        {
            Console.WriteLine($"{nameOfArray}:");
            foreach (var number in array)
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine();
        }
    }
}