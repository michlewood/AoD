using System;

namespace Övningar
{
    internal class Fibonaccis
    {
        internal void Start()
        {
            while (true)
            {
                long f0 = 1;
                long f1 = 1;
                long f2 = 2;
                int n = 0;
                int generations = 5;
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write("How many generations: ");
                    isValid = int.TryParse(Console.ReadLine(), out generations);
                    if (generations < 3) isValid = false;
                }

                while (n <= generations)
                {
                    f2 = f1 + f0;
                    Console.WriteLine($"gen {n}: {f2} = {f1} + {f0}");
                    f0 = f1;
                    f1 = f2;
                    n++;
                    if (f1 < 0 || f0 < 0)
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid) Console.WriteLine($"efter {--n} månader finns {f2} kaniner");

                else Console.WriteLine($"numbers to big! Last generation that worked was {n - 2}.");
                Console.WriteLine();
            }
        }
    }
}