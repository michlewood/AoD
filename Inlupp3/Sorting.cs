using System;
using System.Collections.Generic;

namespace Inlupp3
{
    internal class Sorting
    {
        internal void Start()
        {
            Loopthrough();
        }
        List<int> numbers = new List<int>();
        long[] bubbleSpeed = new long[3];
        long[] QuickSpeed = new long[3];
        int timesToLoop = 3;

        private void Loopthrough()
        {
            bool isSorted = false;

            var list = new List<int>();
            int listLength = 10000;
            for (int i = 0; i < timesToLoop; i++)
            {
                RandomNumbers(listLength);
                Console.WriteLine($"listLength: {listLength}");
                listLength += listLength;

                var watch = System.Diagnostics.Stopwatch.StartNew();
                watch.Stop();

                Console.WriteLine($"Is sorted from start: {IsSorted(numbers)}");

                Console.WriteLine("Bubble sort: ");
                watch = System.Diagnostics.Stopwatch.StartNew();
                list = BubbleSort();
                watch.Stop();
                isSorted = IsSorted(list);
                Console.WriteLine($"Is sorted: {isSorted}");
                Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                bubbleSpeed[i] = watch.ElapsedMilliseconds;

                if (!isSorted) break;

                Console.WriteLine($"Is sorted from start: {IsSorted(numbers)}");

                Console.WriteLine("Quick sort: ");
                watch = System.Diagnostics.Stopwatch.StartNew();
                list = QuickSort();
                watch.Stop();
                isSorted = IsSorted(list);
                Console.WriteLine($"Is sorted: {isSorted}");
                Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                QuickSpeed[i] = watch.ElapsedMilliseconds;

                if (!isSorted) break;

                Console.WriteLine();

            }

            Console.WriteLine(

            $"\nBubble sort:\n" +
            $"Bubble sort 10000 elements: {bubbleSpeed[0]}\n" +
            $"Bubble sort 20000 elements: {bubbleSpeed[1]}\n" +
            $"Bubble sort 40000 elements: {bubbleSpeed[2]}\n" +
            $"\nQuick sort:\n" +
            $"Quick sort 10000 elements: {QuickSpeed[0]}\n" +
            $"Quick sort 20000 elements: {QuickSpeed[1]}\n" +
            $"Quick sort 40000 elements: {QuickSpeed[2]}\n"

            );

            Console.ReadLine();
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
                    SwitchElements(listToSort, current, compare);

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

        #region QuickSort
        private List<int> QuickSort()
        {
            List<int> listToSort = numbers.GetRange(0, numbers.Count);

            if (listToSort.Count < 2) return listToSort;

            SortAroundPivot(listToSort, 0, listToSort.Count / 2, listToSort.Count - 1);

            return listToSort;
        }

        private void SortAroundPivot(List<int> listToSort, int start, int pivot, int end)
        {
            if (start >= end) return;
            int wall = start;
            SwitchElements(listToSort, pivot, end);

            for (int i = wall; i <= end; i++)
            {
                if (!CompareElements(listToSort[i], listToSort[end]))
                {
                    SwitchElements(listToSort, i, wall);
                    wall++;
                }
            }

            SortAroundPivot(listToSort, start, (start + wall - 2) / 2, wall - 2);
            SortAroundPivot(listToSort, wall, (wall + end) / 2, end);

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

        private void SwitchElements(List<int> listToSort, int current, int compare)
        {
            int temp = listToSort[current];
            listToSort[current] = listToSort[compare];
            listToSort[compare] = temp;
        }

        private bool CompareElements(int element1, int element2)
        {
            if (element1 > element2) return true;
            else return false;
        }

        private string PrintList(string nameOfList, List<int> List)
        {
            string outputString = $"{nameOfList}:\n";
            foreach (var number in List)
            {
                outputString += $"{number}, ";
            }
            outputString = outputString.Remove(outputString.Length - 2);
            outputString += "\n";
            Console.Write(outputString);
            return outputString;
        }
        #endregion
    }
}