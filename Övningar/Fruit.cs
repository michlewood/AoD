using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Övningar
{
    class Fruit
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsInStock { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, In Stock: {IsInStock}";
        }
    }
}
