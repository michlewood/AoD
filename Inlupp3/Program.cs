using System;

namespace Inlupp3
{
    class Program
    {
        static string[] menuOptions = { "G", "VG" };
        static bool enterPressed = false;
        static void Main(string[] args)
        {
            Choose();
        }

        private static void Choose()
        {
            while (true)
            {
                int currentPosition = 0;

                Console.WriteLine("G or VG?");


                while (!enterPressed)
                {
                    ShowMenu(currentPosition);
                    currentPosition = ReadUserInput(currentPosition);
                }
                Console.Clear();
                MenuOptions(currentPosition);
                Console.Clear();
                enterPressed = false;
            }
        }

        private static void MenuOptions(int currentPosition)
        {
            switch (currentPosition)
            {
                case 0:
                    ClubMembers cm = new ClubMembers();
                    cm.Start();
                    break;
                case 1:
                    Sorting sorting = new Sorting();
                    sorting.Start();
                    break;


                default:
                    throw new Exception("Menu option not implemented!");
            }
        }

        private static int ReadUserInput(int currentPosition)
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
                        Environment.Exit(0);
                        break;

                    default:
                        break;

                }
            }
        }

        private static void ShowMenu(int currentPosition)
        {
            Console.SetCursorPosition(0, 1);
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
        }
    }
}
