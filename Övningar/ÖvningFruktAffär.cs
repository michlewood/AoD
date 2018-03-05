using System;
using System.Collections.Generic;
using System.Text;

namespace Övningar
{
    class ÖvningFruktAffär
    {
        public List<Fruit> FruitList { get; set; } = new List<Fruit>();
        internal void Start()
        {
            FruitList.Add(new Fruit() { Name = "Banana", Price = 2.5, IsInStock = true });
            FruitList.Add(new Fruit() { Name = "Apple", Price = 1.5, IsInStock = true });
            FruitList.Add(new Fruit() { Name = "Watermelon", Price = 5, IsInStock = false });
            FruitList.Add(new Fruit() { Name = "Strawberry", Price = 1, IsInStock = false });
            FruitList.Add(new Fruit() { Name = "Pear", Price = 3, IsInStock = true });


            foreach (var fruit in FruitList)
            {
                Console.WriteLine(fruit);
            }
        }
    }
}
