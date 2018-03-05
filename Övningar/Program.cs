using System;

namespace Övningar
{
    class Program
    {
        public Program()
        {
            //Fibonaccis();

            //GenericsÖvning1();

            FruktAffär();
        }

        #region Frukt
        private void FruktAffär()
        {
            ÖvningFruktAffär FA = new ÖvningFruktAffär();
            FA.Start();
        }
        #endregion

        #region Fibonaccis
        public void Fibonaccis()
        {
            Fibonaccis fibonaccis = new Fibonaccis();

            fibonaccis.Start();
        }
        #endregion

        #region GenericsÖvning1
        private static void GenericsÖvning1()
        {
            //Ints();
            Chars();
        }

        private static void Ints()
        {
            int size = 5;

            MyGenericArray<int> intArray = new MyGenericArray<int>(size);

            for (int i = 0; i < size; i++)
            {
                intArray.SetItem(i, i * 5);
            }
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(intArray.GetItem(i) + " ");
            }
        }

        private static void Chars()
        {
            int size = 5;

            MyGenericArray<char> charArray = new MyGenericArray<char>(size);

            for (int i = 0; i < size; i++)
            {
                charArray.SetItem(i, (char)(i + 97));
            }
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(charArray.GetItem(i) + " ");
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Program program = new Program();
        }
    }
}
