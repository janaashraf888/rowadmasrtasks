using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace day002
{
    class Product { public string ProductName; public string Category; public double UnitPrice; public int UnitsInStock; }
    class Order { public double Total; public DateTime OrderDate; }
    class Customer { public string CustomerID; public string Region; public List<Order> Orders; }
    static class ListGenerators
    {
        public static List<Product> ProductList = new List<Product>();
        public static List<Customer> CustomerList = new List<Customer>();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem1
            var p1 = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0);
            #endregion
            #region Problem2
            var p2 = ListGenerators.ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            #endregion
            #region Problem3
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var p3 = digits.Where((d, i) => d.Length < i);
            #endregion
            #region Problem4
            var p4 = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            #endregion
            #region Problem5
            var p5 = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            #endregion
            #region Problem6
            int[] nums6 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var p6 = nums6.Where(n => n > 5).Skip(1).FirstOrDefault();
            #endregion
            #region Problem7
            int[] nums7 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var p7 = nums7.Count(n => n % 2 == 1);
            #endregion
            #region Problem8
            var p8 = ListGenerators.CustomerList.Select(c => new { c.CustomerID, OrderCount = c.Orders.Count });
            #endregion
            #region Problem9
            var p9 = ListGenerators.ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count() });
            #endregion
            #region Problem10
            int[] nums10 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var p10 = nums10.Sum();
            #endregion
            #region Problem11
            var words11 = File.Exists("dictionary_english.txt") ? File.ReadAllLines("dictionary_english.txt") : new string[0];
            var p11 = words11.Sum(w => w.Length);
            #endregion
            #region Problem12
            var p12 = ListGenerators.ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, TotalStock = g.Sum(p => p.UnitsInStock) });
            #endregion
            #region Problem13
            var words13 = File.Exists("dictionary_english.txt") ? File.ReadAllLines("dictionary_english.txt") : new string[0];
            var p13 = words13.Length > 0 ? words13.Min(w => w.Length) : 0;
            #endregion
            #region Problem14
            var p14 = ListGenerators.ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, MinPrice = g.Min(p => p.UnitPrice) });
            #endregion
            #region Problem15
            var p15 = from p in ListGenerators.ProductList
                      group p by p.Category into g
                      let minPrice = g.Min(x => x.UnitPrice)
                      from p in g
                      where p.UnitPrice == minPrice
                      select p;
            #endregion
            #region Problem16
            var words16 = File.Exists("dictionary_english.txt") ? File.ReadAllLines("dictionary_english.txt") : new string[0];
            var p16 = words16.Length > 0 ? words16.Max(w => w.Length) : 0;
            #endregion
            #region Problem17
            var p17 = ListGenerators.ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.UnitPrice) });
            #endregion
            #region Problem18
            var p18 = from p in ListGenerators.ProductList
                      group p by p.Category into g
                      let maxPrice = g.Max(x => x.UnitPrice)
                      from p in g
                      where p.UnitPrice == maxPrice
                      select p;
            #endregion
            #region Problem19
            var words19 = File.Exists("dictionary_english.txt") ? File.ReadAllLines("dictionary_english.txt") : new string[0];
            var p19 = words19.Length > 0 ? words19.Average(w => w.Length) : 0;
            #endregion
            #region Problem20
            var p20 = ListGenerators.ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.UnitPrice) });
            #endregion
            #region Problem21
            var p21 = ListGenerators.ProductList.OrderBy(p => p.ProductName);
            #endregion
            #region Problem22
            string[] words22 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var p22 = words22.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            #endregion
            #region Problem23
            var p23 = ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock);
            #endregion
            #region Problem24
            string[] digits24 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var p24 = digits24.OrderBy(w => w.Length).ThenBy(w => w);
            #endregion
            #region Problem25
            string[] words25 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var p25 = words25.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            #endregion
            #region Problem26
            var p26 = ListGenerators.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            #endregion
            #region Problem27
            string[] words27 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var p27 = words27.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            #endregion
            #region Problem28
            string[] digits28 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var p28 = digits28.Where(w => w.Length > 1 && w[1] == 'i').Reverse().ToList();
            #endregion
            #region Problem29
            var p29 = ListGenerators.ProductList.Select(p => p.ProductName);
            #endregion
            #region Problem30
            string[] words30 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var p30 = words30.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            #endregion
            #region Problem31
            var p31 = ListGenerators.ProductList.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });
            #endregion
            #region Problem32
            int[] nums32 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var p32 = nums32.Select((n, i) => new { Number = n, InPlace = n == i });
            #endregion
            #region Problem33
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var p33 = from a in numbersA from b in numbersB where a < b select new { a, b };
            #endregion
            #region Problem34
            var p34 = ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500);
            #endregion
            #region Problem35
            var p35 = ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
            #endregion
            #region Problem36
            var p36 = ListGenerators.CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Take(3);
            #endregion
            #region Problem37
            var p37 = ListGenerators.CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Skip(2);
            #endregion
            #region Problem38
            int[] numbers38 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var p38 = numbers38.TakeWhile((n, i) => n >= i);
            #endregion
            #region Problem39
            int[] numbers39 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var p39 = numbers39.SkipWhile(n => n % 3 != 0);
            #endregion
            #region Problem40
            int[] numbers40 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var p40 = numbers40.SkipWhile((n, i) => n >= i);
            #endregion
            #region Problem41
            var words41 = File.Exists("dictionary_english.txt") ? File.ReadAllLines("dictionary_english.txt") : new string[0];
            var p41 = words41.Any(w => w.Contains("ei"));
            #endregion
            #region Problem42
            var p42 = ListGenerators.ProductList.GroupBy(p => p.Category).Where(g => g.Any(p => p.UnitsInStock == 0));
            #endregion
            #region Problem43
            var p43 = ListGenerators.ProductList.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock > 0));
            #endregion
        }
    }
}