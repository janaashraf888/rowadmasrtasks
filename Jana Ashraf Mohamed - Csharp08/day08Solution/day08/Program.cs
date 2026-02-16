using System;
using System.Collections.Generic;

namespace day08
{
    internal class Program
    {
        static void Main()
        {
            #region Problem 1
            IVehicle car = new Car();
            IVehicle bike = new Bike();
            car.StartEngine();
            car.StopEngine();
            bike.StartEngine();
            bike.StopEngine();
            #endregion

            #region Problem 2
            Shape rectangle = new RectangleShape(5, 4);
            Shape circle = new CircleShape(3);
            rectangle.Display();
            Console.WriteLine(rectangle.GetArea());
            circle.Display();
            Console.WriteLine(circle.GetArea());
            #endregion

            #region Problem 3
            Product[] products ={
                new Product(1,"A",200),
                new Product(2,"B",100),
                new Product(3,"C",150)
            };
            Array.Sort(products);
            foreach (var p in products)
                Console.WriteLine(p.Name + " " + p.Price);
            #endregion

            #region Problem 4
            Student s1 = new Student(1, "Ali", 90);
            Student s2 = new Student(s1);
            s1.Name = "Omar";
            Console.WriteLine(s1.Name);
            Console.WriteLine(s2.Name);
            #endregion

            #region Problem 5
            Robot r = new Robot();
            r.Walk();
            ((IWalkable)r).Walk();
            #endregion

            #region Problem 6
            Account acc = new Account(1, "Ahmed", 5000);
            Console.WriteLine(acc.AccountHolder);
            Console.WriteLine(acc.Balance);
            #endregion

            #region Problem 7
            ILogger logger = new ConsoleLogger();
            logger.Log("Hello");
            #endregion

            #region Problem 8
            Book b1 = new Book();
            Book b2 = new Book("C#");
            Book b3 = new Book("C#", "John");
            Console.WriteLine(b1.Title);
            Console.WriteLine(b2.Title);
            Console.WriteLine(b3.Title + " " + b3.Author);
            #endregion

            #region Problem 9
            PrintTenShapes(new SquareSeries());
            PrintTenShapes(new CircleSeries());
            #endregion

            #region Problem 10
            ShapeItem[] shapes ={
                new ShapeItem("Square",16),
                new ShapeItem("Circle",12.5),
                new ShapeItem("Rectangle",20)
            };
            Array.Sort(shapes);
            foreach (var s in shapes)
                Console.WriteLine(s.Name + " " + s.Area);
            #endregion

            #region Problem 11
            GeometricShape g1 = new Triangle(4, 6);
            GeometricShape g2 = new GeoRectangle(5, 7);
            Console.WriteLine(g1.CalculateArea());
            Console.WriteLine(g1.Perimeter);
            Console.WriteLine(g2.CalculateArea());
            Console.WriteLine(g2.Perimeter);
            #endregion

            #region Problem 12
            int[] areas = { 16, 12, 20, 9, 25 };
            SelectionSort(areas);
            foreach (var a in areas)
                Console.WriteLine(a);
            #endregion

            #region Problem 13
            ShapeFactory factory = new ShapeFactory();
            GeometricShape f1 = factory.CreateShape("rectangle", 4, 5);
            GeometricShape f2 = factory.CreateShape("triangle", 3, 6);
            Console.WriteLine(f1.CalculateArea());
            Console.WriteLine(f2.CalculateArea());
            #endregion
        }

        #region Problem 1
        interface IVehicle
        {
            void StartEngine();
            void StopEngine();
        }

        class Car : IVehicle
        {
            public void StartEngine() { Console.WriteLine("Car started"); }
            public void StopEngine() { Console.WriteLine("Car stopped"); }
        }

        class Bike : IVehicle
        {
            public void StartEngine() { Console.WriteLine("Bike started"); }
            public void StopEngine() { Console.WriteLine("Bike stopped"); }
        }
        #endregion

        #region Problem 2
        abstract class Shape
        {
            public abstract double GetArea();
            public void Display() { Console.WriteLine("Shape"); }
        }

        class RectangleShape : Shape
        {
            double w, h;
            public RectangleShape(double w, double h) { this.w = w; this.h = h; }
            public override double GetArea() { return w * h; }
        }

        class CircleShape : Shape
        {
            double r;
            public CircleShape(double r) { this.r = r; }
            public override double GetArea() { return Math.PI * r * r; }
        }
        #endregion

        #region Problem 3
        class Product : IComparable<Product>
        {
            public int Id;
            public string Name;
            public double Price;

            public Product(int id, string name, double price)
            {
                Id = id; Name = name; Price = price;
            }

            public int CompareTo(Product other)
            {
                return Price.CompareTo(other.Price);
            }
        }
        #endregion

        #region Problem 4
        class Student
        {
            public int Id;
            public string Name;
            public int Grade;

            public Student(int id, string name, int grade)
            {
                Id = id; Name = name; Grade = grade;
            }

            public Student(Student s)
            {
                Id = s.Id;
                Name = string.Copy(s.Name);
                Grade = s.Grade;
            }
        }
        #endregion

        #region Problem 5
        interface IWalkable
        {
            void Walk();
        }

        class Robot : IWalkable
        {
            public void Walk() { Console.WriteLine("Robot normal walk"); }
            void IWalkable.Walk() { Console.WriteLine("Robot interface walk"); }
        }
        #endregion

        #region Problem 6
        struct Account
        {
            private int accountId;
            private string accountHolder;
            private double balance;

            public Account(int id, string holder, double bal)
            {
                accountId = id;
                accountHolder = holder;
                balance = bal;
            }

            public int AccountId { get { return accountId; } set { accountId = value; } }
            public string AccountHolder { get { return accountHolder; } set { accountHolder = value; } }
            public double Balance { get { return balance; } set { balance = value; } }
        }
        #endregion

        #region Problem 7
        interface ILogger
        {
            void Log(string msg)
            {
                Console.WriteLine("Log: " + msg);
            }
        }

        class ConsoleLogger : ILogger
        {
            public void Log(string msg)
            {
                Console.WriteLine("Console: " + msg);
            }
        }
        #endregion

        #region Problem 8
        class Book
        {
            public string Title;
            public string Author;

            public Book()
            {
                Title = "None";
                Author = "None";
            }

            public Book(string title)
            {
                Title = title;
                Author = "None";
            }

            public Book(string title, string author)
            {
                Title = title;
                Author = author;
            }
        }
        #endregion

        #region Problem 9
        interface IShapeSeries
        {
            int CurrentShapeArea { get; set; }
            void GetNextArea();
            void ResetSeries();
        }

        class SquareSeries : IShapeSeries
        {
            int side = 0;
            public int CurrentShapeArea { get; set; }

            public void GetNextArea()
            {
                side++;
                CurrentShapeArea = side * side;
            }

            public void ResetSeries()
            {
                side = 0;
                CurrentShapeArea = 0;
            }
        }

        class CircleSeries : IShapeSeries
        {
            int r = 0;
            public int CurrentShapeArea { get; set; }

            public void GetNextArea()
            {
                r++;
                CurrentShapeArea = (int)(Math.PI * r * r);
            }

            public void ResetSeries()
            {
                r = 0;
                CurrentShapeArea = 0;
            }
        }

        static void PrintTenShapes(IShapeSeries series)
        {
            series.ResetSeries();
            for (int i = 0; i < 10; i++)
            {
                series.GetNextArea();
                Console.WriteLine(series.CurrentShapeArea);
            }
        }
        #endregion

        #region Problem 10
        class ShapeItem : IComparable<ShapeItem>
        {
            public string Name;
            public double Area;

            public ShapeItem(string n, double a)
            {
                Name = n; Area = a;
            }

            public int CompareTo(ShapeItem other)
            {
                return Area.CompareTo(other.Area);
            }
        }
        #endregion

        #region Problem 11
        abstract class GeometricShape
        {
            public double Dimension1;
            public double Dimension2;

            public abstract double CalculateArea();
            public abstract double Perimeter { get; }
        }

        class Triangle : GeometricShape
        {
            public Triangle(double d1, double d2)
            {
                Dimension1 = d1;
                Dimension2 = d2;
            }

            public override double CalculateArea()
            {
                return 0.5 * Dimension1 * Dimension2;
            }

            public override double Perimeter
            {
                get { return Dimension1 + Dimension2 + Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2); }
            }
        }

        class GeoRectangle : GeometricShape
        {
            public GeoRectangle(double d1, double d2)
            {
                Dimension1 = d1;
                Dimension2 = d2;
            }

            public override double CalculateArea()
            {
                return Dimension1 * Dimension2;
            }

            public override double Perimeter
            {
                get { return 2 * (Dimension1 + Dimension2); }
            }
        }
        #endregion

        #region Problem 12
        static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                        min = j;
                }
                int temp = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = temp;
            }
        }
        #endregion

        #region Problem 13
        class ShapeFactory
        {
            public GeometricShape CreateShape(string type, double d1, double d2)
            {
                if (type.ToLower() == "rectangle")
                    return new GeoRectangle(d1, d2);
                if (type.ToLower() == "triangle")
                    return new Triangle(d1, d2);
                return null;
            }
        }
        #endregion
    }
}
