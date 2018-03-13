using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Inlupp2
{
    internal class Sorter
    {
        List<int> numbers = new List<int> { 5, -3, 22, 9001, -105, -33, -88, 1004, 5832, -2602 };
        List<char> chars = new List<char> { 'g', 'a', 'b', 'l', 'q', 't', 'w', 'c', 'u', 'n' };

        public Sorter()
        {
            Start();
        }

        private void Start()
        {
            ReadFromFiles();
            //RandomNumbers(100);

            var output = new List<string>();

            var bubbleIntList = new List<int>();
            var bubbleCharList = new List<char>();
            var mergeIntList = new List<int>();
            var mergeCharList = new List<char>();
            var quickIntList = new List<int>();
            var quickCharList = new List<char>();

            //Unsorted
            output.AddRange(PrintList("Unsorted - int", numbers));
            output.Add($"Is sorted: {SortingMethodsClass<int>.IsSorted(numbers)}");

            output.AddRange(PrintList("unsorted - char", chars));
            output.Add($"Is sorted: {SortingMethodsClass<char>.IsSorted(chars)}");

            //BubbleSort
            bubbleIntList = SortingMethodsClass<int>.BubbleSort(numbers);
            output.AddRange(PrintList("BubbleSort - int", bubbleIntList));
            output.Add($"Is sorted: {SortingMethodsClass<int>.IsSorted(bubbleIntList)}");

            bubbleCharList = SortingMethodsClass<char>.BubbleSort(chars);
            output.AddRange(PrintList("BubbleSort - char", bubbleCharList));
            output.Add($"Is sorted: {SortingMethodsClass<char>.IsSorted(bubbleCharList)}");

            //MergeSort
            mergeIntList = SortingMethodsClass<int>.MergeSort(numbers);
            output.AddRange(PrintList("MergeSort - int", mergeIntList));
            output.Add($"Is sorted: {SortingMethodsClass<int>.IsSorted(mergeIntList)}");

            mergeCharList = SortingMethodsClass<char>.MergeSort(chars);
            output.AddRange(PrintList("MergeSort - char", mergeCharList));
            output.Add($"Is sorted: {SortingMethodsClass<char>.IsSorted(mergeCharList)}");

            //QuickSort
            quickIntList = SortingMethodsClass<int>.QuickSort(numbers);
            output.AddRange(PrintList("QuickSort - int", quickIntList));
            output.Add($"Is sorted: {SortingMethodsClass<int>.IsSorted(quickIntList)}");

            quickCharList = SortingMethodsClass<char>.QuickSort(chars);
            output.AddRange(PrintList("QuickSort - char", quickCharList));
            output.Add($"Is sorted: {SortingMethodsClass<char>.IsSorted(quickCharList)}");

            PrintOutput(output);

            WriteToFile(output.ToArray());
        }
        
        #region Util
        private void WriteToFile(string[] output)
        {
            System.IO.File.WriteAllLines($"{Environment.CurrentDirectory}/numbersOutput.txt", output);
        }

        private void ReadFromFiles()
        {
            var file = System.IO.File.ReadAllLines($"{Environment.CurrentDirectory}/numbersInput.txt");
            List<int> numbers = new List<int>();
            foreach (var item in file)
            {
                if (!int.TryParse(item, out int number))
                    throw new NotFiniteNumberException("Line from file was not a number");
                else
                    numbers.Add(number);

            }

            this.numbers = numbers;

            file = System.IO.File.ReadAllLines($"{Environment.CurrentDirectory}/lettersInput.txt");
            List<char> letters = new List<char>();
            foreach (var item in file)
            {
                if (item.Length > 1)
                    throw new NotFiniteNumberException("Line is to long");
                else
                    letters.Add(item[0]);

            }

            chars = letters;
        }

        private void RandomNumbers(int listLength)
        {
            Random rng = new Random();
            numbers.Clear();
            for (int i = 0; i < listLength; i++)
            {
                numbers.Add(rng.Next(-10000, 10000));
            }
        }

        private void PrintOutput(List<string> output)
        {
            for (int i = 0; i < output.Count; i += 8)
            {
                Console.WriteLine(output[i]);
                Console.WriteLine(output[i+1]);
                Console.WriteLine(output[i+2]);
                Console.WriteLine(output[i+3]);
                Console.WriteLine(output[i+4]);
                Console.WriteLine(output[i+5]);
                output.Insert(i+6, "----------------------------------------");
                Console.WriteLine(output[i+6]);
                output.Insert(i + 7, "");
                Console.WriteLine(output[i + 7]);
            }
        }

        private string[] PrintList<T>(string nameOfList, List<T> List)
        {
            string[] outputString = new string[2];
            outputString[0] = $"{nameOfList}: ";
            foreach (var value in List)
            {
                outputString[1] += $"{value}, ";
            }
            outputString[1] = outputString[1].Remove(outputString[1].Length - 2);
            return outputString;
        }
        #endregion
    }

    internal class SortingMethodsClass<T>
    {
        static internal List<T> BubbleSort(List<T> listToSort)
        {
            List<T> newList = listToSort.GetRange(0, listToSort.Count);
            for (int i = newList.Count - 2; i >= 0; i--)
            {
                int current = i;
                int compare = current + 1;
                while (CompareElements(newList[current], newList[compare]))
                {
                    newList = SwitchElements(newList, current, compare);
                    if (current < newList.Count - 2)
                    {
                        current = compare;
                        compare++;
                    }
                }
            }
            return newList;
        }

        #region MergeSort
        internal static List<T> MergeSort(List<T> numbers)
        {
            return Divide(numbers.GetRange(0, numbers.Count));
        }

        private static List<T> Divide(List<T> list)
        {
            List<T> newList1 = list.GetRange(0, list.Count / 2 + list.Count % 2);
            List<T> newList2 = list.GetRange(list.Count / 2 + list.Count % 2, list.Count / 2);

            if (newList1.Count >= 2) newList1 = Divide(list.GetRange(0, list.Count / 2 + list.Count % 2));
            if (newList2.Count >= 2) newList2 = Divide(list.GetRange(list.Count / 2 + list.Count % 2, list.Count / 2));

            if (newList2.Count == 0) return newList1;
            return SortAndMerge(newList1, newList2);
        }

        private static List<T> SortAndMerge(List<T> list1, List<T> list2)
        {
            List<T> listCombined = new List<T>();

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
        internal static List<T> QuickSort(List<T> list)
        {
            List<T> listToSort = list.GetRange(0, list.Count);

            if (listToSort.Count < 2) return listToSort;

            SortAroundPivot(listToSort, 0, listToSort.Count / 2, listToSort.Count - 1);

            return listToSort;
        }

        private static void SortAroundPivot(List<T> listToSort, int start, int pivot, int end)
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
        internal static bool IsSorted(List<T> list)
        {
            if (list.GetType() == typeof(List<int>))
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (int.Parse(list[i].ToString()) > int.Parse(list[i + 1].ToString())) return false;
                }
                return true;
            }
            else if (list.GetType() == typeof(List<char>))
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if ((list[i].ToString()[0]) > list[i + 1].ToString()[0]) return false;
                }
                return true;
            }
            throw new Exception("invalid input! Must be ints or chars!");
        }

        internal static List<T> SwitchElements(List<T> listToSort, int current, int compare)
        {
            T temp = listToSort[current];
            listToSort[current] = listToSort[compare];
            listToSort[compare] = temp;

            return listToSort;
        }

        internal static bool CompareElements(T element1, T element2)
        {
            if (typeof(T) == typeof(int))
            {
                int a = int.Parse(element1.ToString());
                int b = int.Parse(element2.ToString());
                if (a > b) return true;
                else return false;
            }
            else if (typeof(T) == typeof(char))
            {
                char a = element1.ToString()[0];
                char b = element2.ToString()[0];
                if (a > b) return true;
                else return false;
            }
            throw new Exception("invalid input! Must be ints or chars!");
        }
        #endregion
    }
}