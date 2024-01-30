using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductExample
{   public class Product
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        public Product(string title, double price, string category)
        {
            Title = title;
            Price = price;
            Category = category;
        }
        public override string ToString()
        {
            return $"{Title} - {Price}: {Category}";
        }

    }

    public class Store : IEnumerable<Product>
    {
        private  List<Product> _listproducts = new();
        // public Store(List<Product> listproducts)
        // {
        //     _listproducts = listproducts ?? new List<Product>();
        // }

        public void AddProduct(Product product)
        {
            _listproducts.Add(product);
        }
        public IEnumerator<Product> GetEnumerator()
        {
            return _listproducts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // class Programm
    // {
    //     static void Main(string[] args)
    //     {
    //         Store store = new Store();
    //         store.AddProduct(new Product("Banana", 19.20, "Fruit"));
    //         store.AddProduct(new Product("Orange", 20, "Fruit"));
    //         store.AddProduct(new Product("Pomelo", 20.80, "Friut"));

    //         Console.WriteLine("Books in the store:");
    //         foreach (Product product in store)
    //         {
    //             Console.WriteLine(product);
    //         }
    //     }
    // }
}