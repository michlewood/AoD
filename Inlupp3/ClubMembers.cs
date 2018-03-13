using System;
using System.Collections.Generic;
using System.Linq;

namespace Inlupp3
{
    internal class ClubMembers
    {
        public ClubMembers()
        {
        }

        List<Member> members;
        List<Member> fullMembersList;
        string errorMessage = "                                      ";
        bool searchWithPersonnummer = false;
        bool searchWithLastname = false;
        bool enterPressed = false;
        bool continueLoop = true;
        String LastSortedBy = "Unsorted                                            ";

        string[] menuOptions = { "Sort by Personnummer", "Sort by Lastname",
            "Show Members who have not paid", "Search Personnummer", "Search Lastname" };

        internal void Start()
        {
            Console.CursorVisible = false;

            PopulateMembersList();

            members = fullMembersList;
            Console.WriteLine($"SortedBy: {LastSortedBy}");
            Console.WriteLine("-------------------------------");

            int currentPosition = 0;
            PrintList(members, currentPosition);


            while (continueLoop)
            {
                if (enterPressed)
                {
                    errorMessage = "                              ";

                    try
                    {
                        members = MenuOptions(currentPosition);
                    }
                    catch (Exception e)
                    {
                        errorMessage = e.Message;
                    }
                    PrintList(members, currentPosition);

                }
                enterPressed = false;
                if (searchWithPersonnummer)
                {
                    HideMenu();
                    members = SearchWithPersonnummer();
                    Console.WriteLine("                                              ");
                    Console.WriteLine("                                              ");
                    searchWithPersonnummer = false;
                    PrintList(members, currentPosition);
                    Console.CursorVisible = false;
                }
                else if (searchWithLastname)
                {
                    HideMenu();
                    members = SearchWithLastname();
                    Console.WriteLine("                                              ");
                    Console.WriteLine("                                              ");
                    searchWithLastname = false;
                    PrintList(members, currentPosition);
                    Console.CursorVisible = false;

                }
                else
                {
                    ShowMenu(currentPosition, errorMessage);
                    currentPosition = ReadUserInput(currentPosition);
                }
            }
        }

        private void PopulateMembersList()
        {
            fullMembersList = new List<Member>
            {
                new Member(201005171234, "Spånberg", "Johan", true),
                new Member(194210181234, "Wood", "Michael", false),
                new Member(200801321234, "Kleiser", "Ludwig", true),
                new Member(194210181244, "Wood", "NotMichael", true),
                new Member(198702191234, "Spånberg", "InteJohan", false),
                new Member(191902262322, "Siepen", "Peter",  false),
                new Member(197705121383, "Jonsson", "Goliat",  true),
                new Member(198208171366, "Spånberg", "Sara", true),
                new Member(197104090990, "Kleiser", "Gurk", false),
                new Member(199901011232, "von Sydow", "Stina", true),
                new Member(192202162322, "Eriksson", "Lisa",  true),
                new Member(198605125383, "Nilsson", "Stefan", true),
                new Member(198808171376, "Frostberg", "Erik", false),
                new Member(192204090190, "Eliasson", "Abraham", false),
                new Member(196401011282, "Hammarhorn", "Per", true),
                new Member(193202162322, "Eriksson", "Erik", true),
                new Member(194605125383, "Nilsson", "Adam", true),
                new Member(199808171376, "Andersson", "Stylt", false),
                new Member(196204090190, "Gullberg", "Knapp-Bertil", false),
                new Member(196501011282, "Spånberg", "Gren", true)
            };
        }

        private List<Member> MenuOptions(int currentPosition)
        {
            switch (currentPosition)
            {
                case 0:
                    members = fullMembersList;
                    LastSortedBy = "Personnummer                                    ";
                    return QuickSortPersonnummer(members);
                case 1:
                    members = fullMembersList;
                    LastSortedBy = "LastName                                        ";
                    return QuickSortLastName(members);
                case 2:
                    members = fullMembersList;
                    LastSortedBy = "Membership dues                                 ";
                    return members.Where(x => x.HasPaidMembershipDues == false).ToList();
                case 3:
                    searchWithPersonnummer = true;
                    return members;
                case 4:
                    searchWithLastname = true;
                    return members;

                default:
                    throw new Exception("Menu option not implemented!");
            }
        }

        private int ReadUserInput(int currentPosition)
        {
            int lastMenuItem = menuOptions.Length - 1;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            if (currentPosition == lastMenuItem) return 0;
                            return ++currentPosition;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentPosition == 0) return lastMenuItem;
                            return --currentPosition;
                        }
                    case ConsoleKey.Enter:
                        {
                            enterPressed = true;
                            return currentPosition;
                        }
                    case ConsoleKey.Escape:
                        continueLoop = false;
                        return 0;

                    default:
                        break;

                }
            }
        }

        private void ShowMenu(int currentPosition, string errorMessage)
        {
            Console.SetCursorPosition(0, members.Count + 2);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (currentPosition == i) Console.BackgroundColor = ConsoleColor.White;
                Console.Write(menuOptions[i]);
                for (int j = 0; j < 31 - menuOptions[i].Length; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine(errorMessage);
            for (int i = 0; i < fullMembersList.Count - members.Count; i++)
            {
                Console.WriteLine("                                               ");
            }
        }

        private void HideMenu()
        {
            Console.SetCursorPosition(0, members.Count + 2);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < menuOptions.Length + 1; i++)
            {
                Console.WriteLine("                                               ");
            }
            Console.SetCursorPosition(0, members.Count + 5);
            Console.WriteLine("-------------------------------");
            Console.WriteLine(errorMessage);
            Console.SetCursorPosition(0, members.Count + 3);
        }

        private List<Member> SearchWithPersonnummer()
        {
            bool validInput = false;
            string output = String.Empty;
            long result = 0;
            var searchList = new List<Member>();
            while (!validInput)
            {
                Console.WriteLine("Enter Personnumer (12 numbers):    ");
                Console.CursorVisible = true;
                var input = Console.ReadLine();

                validInput = long.TryParse(input, out result);

                if (input == "esc") return members;

                else if (!validInput || (validInput && result.ToString().Length != 12))
                {
                    validInput = false;
                    Console.CursorTop++;
                    Console.WriteLine("Invalid Search!       ");
                    Console.CursorTop -= 4;
                }
            }
            searchList = fullMembersList.Where(x => x.PersonNummer == result).ToList();

            var temp = LastSortedBy;
            LastSortedBy = "Search for specified personnummer";

            if (searchList.Count == 0)
            {
                errorMessage = "Not Found!                                        ";
                searchList = members;
                LastSortedBy = temp;
            }
            Console.CursorVisible = false;
            return searchList;

        }

        private List<Member> SearchWithLastname()
        {
            bool validInput = false;
            string input = String.Empty;
            var searchList = new List<Member>();
            while (!validInput)
            {
                validInput = true;
                Console.WriteLine("Enter a Lastname (esc to exit):    ");
                Console.CursorVisible = true;
                input = Console.ReadLine();
                if (input.Length == 0)
                {
                    validInput = false;
                    Console.CursorTop++;
                    Console.WriteLine("Invalid Search!       ");
                    Console.CursorTop -= 4;
                }
                if (input == "esc") return members;
            }
            searchList = fullMembersList.Where(x => x.LastName.ToLower() == input.ToLower()).ToList();

            var temp = LastSortedBy;
            LastSortedBy = "Search for specified lastname";


            if (searchList.Count == 0)
            {
                errorMessage = "Not Found!                                        ";
                searchList = members;
                LastSortedBy = temp;
            }
            Console.CursorVisible = false;
            return searchList;

        }

        private void PrintList(List<Member> members, int currentPosition)
        {
            Console.SetCursorPosition(0, 2);
            foreach (var member in members)
            {
                Console.WriteLine(member + "                   ");
            }
            for (int i = 0; i < fullMembersList.Count - members.Count; i++)
            {
                Console.WriteLine("                                                                   ");
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"SortedBy: {LastSortedBy}                      ");

            Console.SetCursorPosition(0, currentPosition + members.Count);
        }

        #region Sorting
        internal static List<Member> QuickSortPersonnummer(List<Member> list)
        {
            List<Member> listToSort = list.GetRange(0, list.Count);

            if (listToSort.Count < 2) return listToSort;

            SortAroundPivotPersonnummer(listToSort, 0, listToSort.Count / 2, listToSort.Count - 1);

            return listToSort;
        }

        private static void SortAroundPivotPersonnummer(List<Member> listToSort, int start, int pivot, int end)
        {
            if (start >= end) return;
            int wall = start;
            SwitchElements(listToSort, pivot, end);

            for (int i = wall; i <= end; i++)
            {
                if (!CompareElements(listToSort[i].PersonNummer, listToSort[end].PersonNummer))
                {
                    SwitchElements(listToSort, i, wall);
                    wall++;
                }
            }

            SortAroundPivotPersonnummer(listToSort, start, (start + wall - 2) / 2, wall - 2);
            SortAroundPivotPersonnummer(listToSort, wall, (wall + end) / 2, end);

        }

        internal static List<Member> QuickSortLastName(List<Member> list)
        {
            List<Member> listToSort = list.GetRange(0, list.Count);

            if (listToSort.Count < 2) return listToSort;

            SortAroundPivotLastName(listToSort, 0, listToSort.Count / 2, listToSort.Count - 1);

            return listToSort;
        }

        private static void SortAroundPivotLastName(List<Member> listToSort, int start, int pivot, int end)
        {
            if (start >= end) return;
            int wall = start;
            SwitchElements(listToSort, pivot, end);

            for (int i = wall; i <= end; i++)
            {
                if (!CompareElements(listToSort[i].LastName, listToSort[end].LastName))
                {
                    SwitchElements(listToSort, i, wall);
                    wall++;
                }
            }

            SortAroundPivotLastName(listToSort, start, (start + wall - 2) / 2, wall - 2);
            SortAroundPivotLastName(listToSort, wall, (wall + end) / 2, end);

        }

        internal static List<Member> SwitchElements(List<Member> listToSort, int current, int compare)
        {
            Member temp = listToSort[current];
            listToSort[current] = listToSort[compare];
            listToSort[compare] = temp;

            return listToSort;
        }

        internal static bool CompareElements<T>(T element1, T element2)
        {
            if (typeof(T) == typeof(long))
            {
                long a = long.Parse(element1.ToString());
                long b = long.Parse(element2.ToString());
                if (a > b) return true;
                else return false;
            }

            else if (typeof(T) == typeof(string))
            {
                if (element1.ToString().CompareTo(element2.ToString()) > 0) return true;
                else return false;
            }

            else if (typeof(T) == typeof(bool))
            {
                if (element1.ToString().CompareTo(element2.ToString()) < 0) return true;
                else return false;
            }
            throw new Exception("invalid input! Must be ints or chars!");
        }
        #endregion
    }
}