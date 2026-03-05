using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Models
{
    // Q1: Why did the property "Id" become a Primary Key without configuration?
    // Because EF Core uses naming conventions. Any property named "Id"
    // or "ClassNameId" is automatically treated as the Primary Key.

    // Q2: Why is "Country" nullable in database while "Price" is not?
    // Because nullable types (string? or DateTime?) allow null values,
    // while non-nullable types like decimal must always have a value.

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime? PublishedDate { get; set; }
    }
}
