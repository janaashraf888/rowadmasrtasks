using System;
using ECommerceSystem.Data;
using ECommerceSystem.Models;
namespace ECommerceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new ECommerceContext();

            var category = new Category { Name = "Electronics" };

            var product = new Product
            {
                Name = "Laptop",
                Price = 1500,
                Category = category
            };

            context.Products.Add(product);

            context.SaveChanges();

            Console.WriteLine("Data Saved!");
        }
    }
}
