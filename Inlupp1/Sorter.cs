using System;
using System.Collections.Generic;
using System.Threading;

namespace Inlupp1
{
    internal class Sorter
    {
        List<int> numbers = new List<int> { 5, -3, 22, 9001, -105, -33, -88, 1004, 5832, -2602 };
        volatile int timesToLoop = 100;

        public Sorter()
        {
            //Start();
            Loopthrough();
        }

        private void Loopthrough()
        {
            bool isSorted = false;
            long fastestBubble = long.MaxValue;
            long slowestBubble = -1;
            long averageBubble = 0;

            long fastestMerge = long.MaxValue;
            long slowestMerge = -1;
            long averageMerge = 0;

            long fastestMerge1 = long.MaxValue;
            long slowestMerge1 = -1;
            long averageMerge1 = 0;

            long fastestQuick = long.MaxValue;
            long slowestQuick = -1;
            long averageQuick = 0;

            long fastestAQuick = long.MaxValue;
            long slowestAQuick = -1;
            long averageAQuick = 0;

            var list = new List<int>();
            int currentLoop = 0;

            Thread escapeThread = new Thread(CheckIfEscapeKeyIsPressed);
            escapeThread.Start();
            for (int i = 1; i <= timesToLoop; i++)
            {
                currentLoop = i;
                RandomNumbers(50000);
                Console.WriteLine($"current loop: {currentLoop}");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Is sorted from start: {!IsSorted(numbers)}");

                //Console.WriteLine("Bubble sort: ");
                //var watch = System.Diagnostics.Stopwatch.StartNew();
                //list = BubbleSort();
                //watch.Stop();
                //isSorted = IsSorted(list);
                //Console.WriteLine($"Is sorted: {isSorted}");
                //Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                //if (watch.ElapsedMilliseconds < fastestBubble) fastestBubble = watch.ElapsedMilliseconds;
                //if (watch.ElapsedMilliseconds > slowestBubble) slowestBubble = watch.ElapsedMilliseconds;
                //averageBubble += watch.ElapsedMilliseconds;
                //if (!isSorted) break;

                Console.WriteLine("Merge sort: ");
                watch = System.Diagnostics.Stopwatch.StartNew();
                list = MergeSort3();
                watch.Stop();
                isSorted = IsSorted(list);
                Console.WriteLine($"Is sorted: {isSorted}");
                Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                if (watch.ElapsedMilliseconds < fastestMerge) fastestMerge = watch.ElapsedMilliseconds;
                if (watch.ElapsedMilliseconds > slowestMerge) slowestMerge = watch.ElapsedMilliseconds;
                averageMerge += watch.ElapsedMilliseconds;
                if (!isSorted) break;

                Console.WriteLine("Merge sort: ");
                watch = System.Diagnostics.Stopwatch.StartNew();
                list = MergeSort2();
                watch.Stop();
                isSorted = IsSorted(list);
                Console.WriteLine($"Is sorted: {isSorted}");
                Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                if (watch.ElapsedMilliseconds < fastestMerge) fastestMerge1 = watch.ElapsedMilliseconds;
                if (watch.ElapsedMilliseconds > slowestMerge) slowestMerge1 = watch.ElapsedMilliseconds;
                averageMerge1 += watch.ElapsedMilliseconds;
                if (!isSorted) break;

                //Console.WriteLine("Quick sort: ");
                //watch = System.Diagnostics.Stopwatch.StartNew();
                //list = QuickSort3();
                //watch.Stop();
                //isSorted = IsSorted(list);
                //Console.WriteLine($"Is sorted: {isSorted}");
                //Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                //if (watch.ElapsedMilliseconds < fastestQuick) fastestQuick = watch.ElapsedMilliseconds;
                //if (watch.ElapsedMilliseconds > slowestQuick) slowestQuick = watch.ElapsedMilliseconds;
                //averageQuick += watch.ElapsedMilliseconds;
                //if (!isSorted) break;

                Console.WriteLine("AQuick sort: ");
                watch = System.Diagnostics.Stopwatch.StartNew();
                list = ActualQuickSort();
                watch.Stop();
                isSorted = IsSorted(list);
                Console.WriteLine($"Is sorted: {isSorted}");
                Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                if (watch.ElapsedMilliseconds < fastestAQuick) fastestAQuick = watch.ElapsedMilliseconds;
                if (watch.ElapsedMilliseconds > slowestAQuick) slowestAQuick = watch.ElapsedMilliseconds;
                averageAQuick += watch.ElapsedMilliseconds;
                if (!isSorted) break;

                Console.WriteLine();
            }
            Console.WriteLine(
                $"\nbubble sort:\n" +
                $"fastest bubble sort: {fastestBubble}\n" +
                $"slowest bubble sort: {slowestBubble}\n" +
                $"average bubble sort: {averageBubble / currentLoop}\n" +
                $"\nmerge sort:\n" +
                $"fastest merge sort: {fastestMerge}\n" +
                $"slowest merge sort: {slowestMerge}\n" +
                $"average merge sort: {averageMerge / currentLoop}\n" +
                $"\nmerge sort:\n" +
                $"fastest merge sort: {fastestMerge1}\n" +
                $"slowest merge sort: {slowestMerge1}\n" +
                $"average merge sort: {averageMerge1 / currentLoop}\n" +
                $"\nquick sort:\n" +
                $"fastest quick sort: {fastestQuick}\n" +
                $"slowest quick sort: {slowestQuick}\n" +
                $"average quick sort: {averageQuick / currentLoop}\n" +
                $"\nAquick sort:\n" +
                $"fastest quick sort: {fastestAQuick}\n" +
                $"slowest quick sort: {slowestAQuick}\n" +
                $"average quick sort: {averageAQuick / currentLoop}\n"
                );

        }

        private void Start()
        {

            //numbers = ReadNumbersFromFile();
            List<string> output = new List<string>();
            RandomNumbers(1000);
            var list = new List<int>();
            output.Add(PrintList("Unsorted", numbers));

            output.Add($"Is sorted: {IsSorted(numbers)}");
            Console.WriteLine(output[output.Count - 1]);

            output.Add("\n");
            Console.WriteLine();

            list = BubbleSort();
            output.Add(PrintList("BubbleSort", list));
            output.Add($"Is sorted: {IsSorted(list)}");
            Console.WriteLine(output[output.Count - 1]);

            output.Add("\n");
            Console.WriteLine();

            list = MergeSort3();
            output.Add(PrintList("MergeSort", list));
            output.Add($"Is sorted: {IsSorted(list)}");
            Console.WriteLine(output[output.Count - 1]);

            output.Add("\n");
            Console.WriteLine();

            list = ActualQuickSort();
            output.Add(PrintList("QuickSort", list));
            output.Add($"Is sorted: {IsSorted(list)}");
            Console.WriteLine(output[output.Count - 1]);

            output.Add("\n");
            Console.WriteLine();

            list = QuickSort3();
            output.Add(PrintList("QuickSort", list));
            output.Add($"Is sorted: {IsSorted(list)}");
            Console.WriteLine(output[output.Count - 1]);

            WriteToFile(output.ToArray());
        }

        private void WriteToFile(string[] output)
        {
            System.IO.File.WriteAllLines($"{Environment.CurrentDirectory}/numbersOutput.txt", output);
        }

        private List<int> ReadNumbersFromFile()
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

            return numbers;
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
        private List<int> MergeSort3()
        {
            List<int> listToSort = Divide3(numbers);

            return listToSort;
        }

        private List<int> Divide3(List<int> list)
        {
            List<int> newList1 = list.GetRange(0, list.Count / 2 + list.Count % 2);
            List<int> newList2 = list.GetRange(list.Count / 2 + list.Count % 2, list.Count / 2);

            if (newList1.Count >= 2) newList1 = Divide(list.GetRange(0, list.Count / 2 + list.Count % 2));
            if (newList2.Count >= 2) newList2 = Divide(list.GetRange(list.Count / 2 + list.Count % 2, list.Count / 2));

            if (newList2.Count == 0) return newList1;
            return SortAndMerge(newList1, newList2);
        }

        private List<int> SortAndMerge3(List<int> list1, List<int> list2)
        {
            List<int> listCombined = new List<int>();

            int list1ToCompare = 0;
            int list2ToCompare = 0;
            bool continueLoop = true;
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

            if (continueLoop)
            {
                listCombined = SortAndMerge(list1.GetRange(list1ToCompare, list1.Count - 1), list2.GetRange(list2ToCompare, list2.Count - 1));
            }
            return listCombined;
        }
        #endregion

        #region QuickSort
        private List<int> ActualQuickSort()
        {
            List<int> listToSort = numbers.GetRange(0, numbers.Count);

            if (listToSort.Count < 2) return listToSort;

            int pivotPoint = listToSort.Count / 2 + 1;

            listToSort = SwitchElements(listToSort, pivotPoint, listToSort.Count - 1);

            listToSort = SortAroundPivot4(listToSort, 0, listToSort.Count / 2, listToSort.Count - 1);

            return listToSort;
        }

        private List<int> SortAroundPivot4(List<int> listToSort, int start, int pivot, int end)
        {
            if (start >= end) return listToSort;
            int wall = start;
            listToSort = SwitchElements(listToSort, pivot, end);

            for (int i = wall; i <= end; i++)
            {
                if (!CompareElements(listToSort[i], listToSort[end]))
                {
                    SwitchElements(listToSort, i, wall);
                    wall++;
                }
            }

            listToSort = SortAroundPivot4(listToSort, start, (start + wall - 2) / 2, wall - 2);
            listToSort = SortAroundPivot4(listToSort, wall, (wall + end) / 2, end);

            return listToSort;
        }

        private List<int> QuickSort3()
        {
            List<int> listToSort = numbers.GetRange(0, numbers.Count);

            if (listToSort.Count < 2) return listToSort;

            listToSort = SortAroundPivot3(listToSort);
            return listToSort;
        }

        private List<int> SortAroundPivot3(List<int> listToSort)
        {
            if (listToSort.Count < 2) return listToSort;
            listToSort = SwitchElements(listToSort, listToSort.Count / 2, listToSort.Count - 1);
            int pivot = listToSort.Count - 1;
            int newPivot = 0;

            List<int> newList = new List<int>();
            newList.Add(listToSort[pivot]);
            for (int i = 0; i < pivot; i++)
            {
                bool biggerThanPivot = CompareElements(listToSort[i], listToSort[pivot]);

                if (biggerThanPivot) newList.Add(listToSort[i]);
                else
                {
                    newList.Insert(0, listToSort[i]);
                    newPivot++;
                }
            }

            var partialList = SortAroundPivot3(newList.GetRange(0, newPivot));
            newList.RemoveRange(0, newPivot);
            newList.InsertRange(0, partialList);

            partialList = SortAroundPivot3(newList.GetRange(newPivot + 1, newList.Count - newPivot - 1));
            newList.RemoveRange(newPivot + 1, listToSort.Count - newPivot - 1);
            newList.InsertRange(newPivot + 1, partialList);

            return newList;
        }
        #endregion

        #region Itirations

        #region MergeSort

        private List<int> MergeSort()
        {
            return SortAndMerge(
                SortAndMerge(
                    SortAndMerge(
                        SortAndMerge(numbers.GetRange(0, 1), numbers.GetRange(1, 1)),
                        SortAndMerge(numbers.GetRange(2, 1), numbers.GetRange(3, 1))
                    ),
                    SortAndMerge(
                        SortAndMerge(numbers.GetRange(4, 1), numbers.GetRange(5, 1)),
                        SortAndMerge(numbers.GetRange(6, 1), numbers.GetRange(7, 1))
                    )
                ),
                SortAndMerge(numbers.GetRange(8, 1), numbers.GetRange(9, 1)));
        }

        private List<int> MergeSort2()
        {
            List<int> listToSort = Divide(numbers);

            return listToSort;
        }

        private List<int> Divide(List<int> list)
        {
            List<int> newList1 = list.GetRange(0, list.Count / 2 + list.Count % 2);
            List<int> newList2 = list.GetRange(list.Count / 2 + list.Count % 2, list.Count / 2);

            if (newList1.Count >= 2) newList1 = Divide(list.GetRange(0, list.Count / 2 + list.Count % 2));
            if (newList2.Count >= 2) newList2 = Divide(list.GetRange(list.Count / 2 + list.Count % 2, list.Count / 2));

            if (newList2.Count == 0) return newList1;
            return SortAndMerge(newList1, newList2);
        }

        private List<int> SortAndMerge(List<int> list1, List<int> list2)
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

            listToSort = SortAroundPivot(listToSort);

            return listToSort;
        }

        private List<int> SortAroundPivot(List<int> listToSort)
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
            if (!IsSorted(listToSort.GetRange(0, pivot)))
            {
                var partialList = SortAroundPivot(listToSort.GetRange(0, pivot));
                listToSort.RemoveRange(0, pivot);
                listToSort.InsertRange(0, partialList);
            }
            if (!IsSorted(listToSort.GetRange(pivot + 1, listToSort.Count - pivot - 1)))
            {
                var partialList = SortAroundPivot(listToSort.GetRange(pivot + 1, listToSort.Count - pivot - 1));
                listToSort.RemoveRange(pivot + 1, listToSort.Count - pivot - 1);
                listToSort.InsertRange(pivot + 1, partialList);
            }

            return listToSort;
        }

        private List<int> QuickSort2()
        {
            List<int> listToSort = numbers.GetRange(0, numbers.Count);

            if (listToSort.Count < 2) return listToSort;

            listToSort = SortAroundPivot2(listToSort);

            return listToSort;
        }

        private List<int> SortAroundPivot2(List<int> listToSort)
        {
            //    if (listToSort.Count == 1) return listToSort;
            //    listToSort = SwitchElements(listToSort, listToSort.Count / 2 + 1, listToSort.Count - 1);
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

            if (listToSort.GetRange(0, pivot).Count > 1)
            {
                var partialList = SortAroundPivot2(listToSort.GetRange(0, pivot));
                listToSort.RemoveRange(0, pivot);
                listToSort.InsertRange(0, partialList);
            }
            if (listToSort.GetRange(pivot + 1, listToSort.Count - pivot - 1).Count > 1)
            {
                var partialList = SortAroundPivot2(listToSort.GetRange(pivot + 1, listToSort.Count - pivot - 1));
                listToSort.RemoveRange(pivot + 1, listToSort.Count - pivot - 1);
                listToSort.InsertRange(pivot + 1, partialList);
            }
            return listToSort;
        }
        #endregion

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

        private void CheckIfEscapeKeyIsPressed()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                timesToLoop = 0;
            }
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