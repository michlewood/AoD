using System;
using System.Collections.Generic;
using System.Text;

namespace Övningar
{
    class MyGenericArray<T>
    {
        private T[] array;
        public MyGenericArray (int size)
        {
            array = new T[size + 1];
        }

        public T GetItem(int index)
        {
            return array[index];
        }

        public void SetItem(int index, T value)
        {
            array[index] = value;
        }
    }
}
