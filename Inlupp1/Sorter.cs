using System;
using System.Collections.Generic;
using System.Threading;

namespace Inlupp1
{
    internal class Sorter
    {
        List<int> numbers = new List<int> { 5, -3, 22, 9001, -105, -33, -88, 1004, 5832, -2602, -106 };
        //List<int> numbers = new List<int> { 5, -3, 22, 9001, -105, -33, -88, 1004 };
        volatile int timesToLoop = 50;

        public Sorter()
        {
            //Start();
            //Loopthrough();
            BinaryTree();
        }

        private void BinaryTree()
        {
            foreach (var item in numbers)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            BinaryTreeNode firstNode = TreeSort();

            //foreach (var item in firstNode.GetTree())
            //{
            //    Console.Write($"{item.Value}, ");
            //}

            firstNode.PrintTree(50, 2);
        }

        private BinaryTreeNode TreeSort()
        {
            BinaryTreeNode firstNode = new BinaryTreeNode(numbers[0]);
            for (int i = 1; i < numbers.Count; i++)
            {
                firstNode.SetChild(new BinaryTreeNode(numbers[i]));
            }
            return firstNode;
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

            long fastestQuick = long.MaxValue;
            long slowestQuick = -1;
            long averageQuick = 0;

            long fastestAQuick = long.MaxValue;
            long slowestAQuick = -1;
            long averageAQuick = 0;

            long fastestBinaryTree = long.MaxValue;
            long slowestBinaryTree = -1;
            long averageBinaryTree = 0;

            var list = new List<int>();
            int currentLoop = 0;

            Thread escapeThread = new Thread(CheckIfEscapeKeyIsPressed);
            escapeThread.Start();
            for (int i = 1; i <= timesToLoop; i++)
            {
                currentLoop = i;
                RandomNumbers(100000);
                Console.WriteLine($"current loop: {currentLoop}");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Is sorted from start: {IsSorted(numbers)}");

                //Console.WriteLine("Bubble sort: ");
                //watch = System.Diagnostics.Stopwatch.StartNew();
                //list = BubbleSort();
                //watch.Stop();
                //isSorted = IsSorted(list);
                //Console.WriteLine($"Is sorted: {isSorted}");
                //Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                //if (watch.ElapsedMilliseconds < fastestBubble) fastestBubble = watch.ElapsedMilliseconds;
                //if (watch.ElapsedMilliseconds > slowestBubble) slowestBubble = watch.ElapsedMilliseconds;
                //averageBubble += watch.ElapsedMilliseconds;
                //if (!isSorted) break;

                //Console.WriteLine("Merge sort: ");
                //watch = System.Diagnostics.Stopwatch.StartNew();
                //list = MergeSort2();
                //watch.Stop();
                //isSorted = IsSorted(list);
                //Console.WriteLine($"Is sorted: {isSorted}");
                //Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                //if (watch.ElapsedMilliseconds < fastestMerge) fastestMerge = watch.ElapsedMilliseconds;
                //if (watch.ElapsedMilliseconds > slowestMerge) slowestMerge = watch.ElapsedMilliseconds;
                //averageMerge += watch.ElapsedMilliseconds;
                //if (!isSorted) break;

                //Console.WriteLine("False Quick sort: ");
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

                Console.WriteLine("Actual Quick sort: ");
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

                Console.WriteLine("BinaryTree sort: ");
                watch = System.Diagnostics.Stopwatch.StartNew();
                BinaryTreeNode firstNode = TreeSort();
                watch.Stop();
                isSorted = IsSorted(firstNode.GetIntTree());
                Console.WriteLine($"Is sorted: {isSorted}");
                Console.WriteLine($"time taken: {watch.ElapsedMilliseconds} ms");
                if (watch.ElapsedMilliseconds < fastestBinaryTree) fastestBinaryTree = watch.ElapsedMilliseconds;
                if (watch.ElapsedMilliseconds > slowestBinaryTree) slowestBinaryTree = watch.ElapsedMilliseconds;
                averageBinaryTree += watch.ElapsedMilliseconds;
                if (!isSorted) break;

                Console.WriteLine();

            }
            Console.WriteLine(
                //$"\nBubble sort:\n" +
                //$"fastest bubble sort: {fastestBubble}\n" +
                //$"slowest bubble sort: {slowestBubble}\n" +
                //$"average bubble sort: {averageBubble / currentLoop}\n" +
                //$"\nMerge sort:\n" +
                //$"fastest merge sort: {fastestMerge}\n" +
                //$"slowest merge sort: {slowestMerge}\n" +
                //$"average merge sort: {averageMerge / currentLoop}\n" +
                //$"\nFalse quick sort:\n" +
                //$"fastest false quick sort: {fastestQuick}\n" +
                //$"slowest false quick sort: {slowestQuick}\n" +
                //$"average false quick sort: {averageQuick / currentLoop}\n" +
                $"\nActual quick sort:\n" +
                $"fastest actual quick sort: {fastestAQuick}\n" +
                $"slowest actual quick sort: {slowestAQuick}\n" +
                $"average actual quick sort: {averageAQuick / currentLoop}\n" +
                $"\nBinaryTree sort:\n" +
                $"fastest BinaryTree sort: {fastestBinaryTree}\n" +
                $"slowest BinaryTree sort: {slowestBinaryTree}\n" +
                $"average BinaryTree sort: {averageBinaryTree / currentLoop}\n"
                );

        }

        private void Start()
        {
            numbers = ReadNumbersFromFile();
            List<string> output = new List<string>();
            //RandomNumbers(3);
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

            list = MergeSort2();
            output.Add(PrintList("MergeSort", list));
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

        #region MergeSort
        private List<int> MergeSort2()
        {
            return Divide(numbers.GetRange(0, numbers.Count));
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
        private List<int> ActualQuickSort()
        {
            List<int> listToSort = numbers.GetRange(0, numbers.Count);

            if (listToSort.Count < 2) return listToSort;

            SortAroundPivot4(listToSort, 0, listToSort.Count / 2, listToSort.Count - 1);

            return listToSort;
        }

        private void SortAroundPivot4(List<int> listToSort, int start, int pivot, int end)
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

            SortAroundPivot4(listToSort, start, (start + wall - 2) / 2, wall - 2);
            SortAroundPivot4(listToSort, wall, (wall + end) / 2, end);

        }
        #endregion

        #region Itirations

        #region MergeSort

        private List<int> MergeSort() // only works with list of size 10
        {
            return
                SortAndMerge(
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
                    SortAndMerge(numbers.GetRange(8, 1), numbers.GetRange(9, 1))
                );
        }

        private List<int> MergeSort3() // only works with list of size 10
        {
            List<int> list = numbers.GetRange(0, numbers.Count);
            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 8-i; j += i*2)
                {
                    list.InsertRange(j, SortAndMerge(list.GetRange(j, i), list.GetRange(j + i, i)));
                    list.RemoveRange(j + i * 2, i * 2);
                }
            }

            //for (int j = 0; j < 8; j += 2)
            //{
            //    Console.WriteLine(list.GetRange(j, 1)[0] + "," + list.GetRange(j + 1, 1)[0]);
            //}

            return list;
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
            SwitchElements(listToSort, listToSort.Count / 2, listToSort.Count - 1);
            int pivot = listToSort.Count - 1;
            int newPivot = 0;

            List<int> newList = new List<int>
            {
                listToSort[pivot]
            };
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