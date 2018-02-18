using System;
using System.Collections.Generic;

namespace Inlupp1
{
    internal class Sorter
    {
        List<int> numbers = new List<int>() { 5, -3, 22, 9001, -33, -105, -88, 1004, 5832, -2602 };
        public Sorter()
        {
            Start();
        }

        private void Start()
        {
            PrintList("Unsorted", numbers);

            PrintList("BubbleSort", BubbleSort());

            PrintList("Unsorted", numbers);

            PrintList("MergeSort", MergeSort());



            //QuickSort();
        }

        private List<int> MergeSort()
        {
            List<int> list2A = numbers.GetRange(0, 2);
            List<int> list2B = numbers.GetRange(2, 2);
            List<int> list2C = numbers.GetRange(4, 2);
            List<int> list2D = numbers.GetRange(6, 2);
            List<int> list2E = numbers.GetRange(8, 2);

            PrintList("unsorted", list2A);
            list2A = SecondSort(list2A.GetRange(0,1), list2A.GetRange(1, 1));
            list2B = SecondSort(list2B.GetRange(0,1), list2B.GetRange(1, 1));
            list2C = SecondSort(list2C.GetRange(0,1), list2C.GetRange(1, 1));
            list2D = SecondSort(list2D.GetRange(0,1), list2D.GetRange(1, 1));
            list2E = SecondSort(list2E.GetRange(0,1), list2E.GetRange(1, 1));
            PrintList("sorted", list2A);

            List<int> list4A = SecondSort(list2A, list2B);
            List<int> list4B = SecondSort(list2C, list2D);

            List<int> List8 = SecondSort(list4A, list4B);

            List<int> listToSort = SecondSort(List8, list2E);

            return listToSort;
        }

        private List<int> SecondSort(List<int> list1, List<int> list2)
        {
            List<int> listCombined = new List<int>();

            int list1ToCompare = 0;
            int list2ToCompare = 0;
            bool continueLoop = true;
            while (continueLoop)
            {
                bool ListTwoFirst = CompareElements(list1[list1ToCompare], list2[list2ToCompare]);

                if (ListTwoFirst)
                {
                    listCombined.Add(list2[list2ToCompare]);
                    list2ToCompare++;
                }
                else
                {
                    listCombined.Add(list1[list1ToCompare]);
                    list1ToCompare++;
                }
                if (list2ToCompare == list2.Count)
                {
                    listCombined.AddRange(list1.GetRange(list1ToCompare, list1.Count-list1ToCompare));
                    continueLoop = false;
                }
                else if (list1ToCompare == list1.Count)
                {
                    listCombined.AddRange(list2.GetRange(list2ToCompare, list2.Count - list2ToCompare));
                    continueLoop = false;
                }
            }
            return listCombined;
        }

        private bool CompareElements(int element1, int element2)
        {

            if (element1 > element2) return true;
            else return false;

        }

        private List<int> BubbleSort()
        {
            List<int> listToSort = numbers.GetRange(0,numbers.Count);
            for (int i = listToSort.Count - 2; i >= 0; i--)
            {
                int current = i;
                int compare = current + 1;
                while (listToSort[current] > listToSort[compare])
                {
                    listToSort = SwitchElements(listToSort, current, compare);

                    if (current < listToSort.Count - 2)
                    {
                        current = compare;
                        compare++;
                    }
                }

            }
            return listToSort;
        }

        private List<int> SwitchElements(List<int> listToSort, int current, int compare)
        {
            int temp = listToSort[current];
            listToSort[current] = listToSort[compare];
            listToSort[compare] = temp;

            return listToSort;
        }

        private void PrintList(string nameOfArray, List<int> array)
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