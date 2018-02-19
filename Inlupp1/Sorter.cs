using System;
using System.Collections.Generic;

namespace Inlupp1
{
    internal class Sorter
    {
        List<int> numbers = new List<int> { 5, -3, 22, 9001, -105, -33, -88, 1004, 5832, -2602 };

        public Sorter()
        {
            //Start();
            Loopthrough(10);
        }

        private void Loopthrough(int timesToLoop)
        {
            var list = new List<int>();
            for (int i = 0; i < timesToLoop; i++)
            {
                RandomNumbers(10);
                Console.WriteLine($"current loop: {i+1}");

                Console.WriteLine($"Unsorted: {IsSorted(numbers)}");

                list = BubbleSort();
                Console.WriteLine($"BubbleSort: {IsSorted(list)}");
                if (!IsSorted(list)) break;

                list = MergeSort();
                Console.WriteLine($"MergeSort: {IsSorted(list)}");
                if (!IsSorted(list)) break;

                list = QuickSort();
                Console.WriteLine($"QuickSort: {IsSorted(list)}");
                if (!IsSorted(list)) break;

                Console.WriteLine();

            }
        }

        private void Start()
        {
            //RandomNumbers(10);
            var list = new List<int>();

            PrintList("Unsorted", numbers);
            Console.WriteLine($"Is sorted: {IsSorted(numbers)}");

            Console.WriteLine();

            list = BubbleSort();
            PrintList("BubbleSort", list);
            Console.WriteLine($"Is sorted: {IsSorted(list)}");

            Console.WriteLine();

            list = MergeSort();
            PrintList("MergeSort", list);
            Console.WriteLine($"Is sorted: {IsSorted(list)}");

            Console.WriteLine();

            list = MergeSort2();
            PrintList("MergeSort2", list);
            Console.WriteLine($"Is sorted: {IsSorted(list)}");

            Console.WriteLine();

            list = QuickSort();
            PrintList("QuickSort", list);
            Console.WriteLine($"Is sorted: {IsSorted(list)}");
        }

        #region Bubble
        private List<int> BubbleSort()
        {
            List<int> listToSort = numbers.GetRange(0, numbers.Count);
            for (int i = listToSort.Count - 2; i >= 0; i--)
            {
                int current = i;
                int compare = current + 1;
                while (CompareElements(listToSort[current], listToSort[compare]))
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
        #endregion

        #region MergeSort
        private List<int> MergeSort()
        {

            //PrintList("unsorted", list2A);
            List<int> list2A = SecondSort(numbers.GetRange(0, 1), numbers.GetRange(1, 1));
            List<int> list2B = SecondSort(numbers.GetRange(2, 1), numbers.GetRange(3, 1));
            List<int> list2C = SecondSort(numbers.GetRange(4, 1), numbers.GetRange(5, 1));
            List<int> list2D = SecondSort(numbers.GetRange(6, 1), numbers.GetRange(7, 1));
            List<int> list2E = SecondSort(numbers.GetRange(8, 1), numbers.GetRange(9, 1));
            //PrintList("sorted", list2A);

            List<int> list4A = SecondSort(list2A, list2B);
            List<int> list4B = SecondSort(list2C, list2D);

            List<int> List8 = SecondSort(list4A, list4B);

            List<int> listToSort = SecondSort(List8, list2E);

            return listToSort;
        }

        private List<int> MergeSort2()
        {
            return SecondSort(
                SecondSort(
                    SecondSort(
                        SecondSort(numbers.GetRange(0, 1), numbers.GetRange(1, 1)),
                        SecondSort(numbers.GetRange(2, 1), numbers.GetRange(3, 1))
                    ),
                    SecondSort(
                        SecondSort(numbers.GetRange(4, 1), numbers.GetRange(5, 1)),
                        SecondSort(numbers.GetRange(6, 1), numbers.GetRange(7, 1))
                    )
                ),
                SecondSort(numbers.GetRange(8, 1), numbers.GetRange(9, 1)));
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
                    listCombined.AddRange(list1.GetRange(list1ToCompare, list1.Count - list1ToCompare));
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
        #endregion

        #region QuickSort
        private List<int> QuickSort()
        {
            List<int> listToSort = numbers.GetRange(0, numbers.Count);

            if (listToSort.Count < 2) return listToSort;

            listToSort = RecursiveSortMethod(listToSort);

            return listToSort;
        }

        private List<int> RecursiveSortMethod(List<int> listToSort)
        {
            int pivot = listToSort.Count - 1;
            for (int i = 0; i < pivot; i++)
            {
                bool biggerThanPivot = CompareElements(listToSort[i], listToSort[pivot]);
                if (biggerThanPivot)
                {
                    listToSort.Add(listToSort[i]);
                    listToSort.RemoveAt(i);
                    pivot--;
                    i--;
                }
            }
            if (!IsSorted(listToSort))
            {
                if (!IsSorted(listToSort.GetRange(0, pivot)))
                {
                    var partialList = RecursiveSortMethod(listToSort.GetRange(0, pivot));
                    listToSort.RemoveRange(0, pivot);
                    listToSort.InsertRange(0, partialList);
                }
                if (!IsSorted(listToSort.GetRange(pivot + 1, listToSort.Count - pivot - 1)))
                {
                    var partialList = RecursiveSortMethod(listToSort.GetRange(pivot + 1, listToSort.Count - pivot - 1));
                    listToSort.RemoveRange(pivot + 1, listToSort.Count - pivot - 1);
                    listToSort.InsertRange(pivot + 1, partialList);
                }
            }
            return listToSort;
        }
        #endregion

        #region Util

        private void RandomNumbers(int listLength)
        {
            Random rng = new Random();
            numbers.Clear();
            for (int i = 0; i < listLength; i++)
            {
                numbers.Add(rng.Next(-10000, 10000));
            }
        }

        private bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1]) return false;
            }
            return true;
        }
        private List<int> SwitchElements(List<int> listToSort, int current, int compare)
        {
            int temp = listToSort[current];
            listToSort[current] = listToSort[compare];
            listToSort[compare] = temp;

            return listToSort;
        }

        private bool CompareElements(int element1, int element2)
        {
            if (element1 > element2) return true;
            else return false;
        }

        private void PrintList(string nameOfList, List<int> List)
        {
            Console.WriteLine($"{nameOfList}:");
            foreach (var number in List)
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}