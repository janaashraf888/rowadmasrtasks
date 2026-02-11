using System;

namespace day07
{
    internal class Program
    {
        static void Main()
        {
            #region problem 1
            Car car1 = new Car();
            Car car2 = new Car(101);
            Car car3 = new Car(102, "Toyota");
            Car car4 = new Car(103, "Honda", 25000);
            Console.WriteLine(car1);
            Console.WriteLine(car2);
            Console.WriteLine(car3);
            Console.WriteLine(car4);
            #endregion

            #region problem 2
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Sum(2, 3));
            Console.WriteLine(calc.Sum(1, 2, 3));
            Console.WriteLine(calc.Sum(2.5, 3.5));
            #endregion

            #region problem 3
            Child child = new Child(5, 10, 15);
            Console.WriteLine(child.X);
            Console.WriteLine(child.Y);
            Console.WriteLine(child.Z);
            #endregion

            #region problem 4
            Parent parentObj = new Parent(2, 3);
            Child childObj = new Child(4, 5, 6);
            Console.WriteLine(parentObj.Product());
            Console.WriteLine(childObj.ProductHiding());
            Console.WriteLine(childObj.Product());
            Console.WriteLine(((Parent)childObj).Product());
            #endregion

            #region problem 5
            Parent p = new Parent(1, 2);
            Child c = new Child(3, 4, 5);
            Console.WriteLine(p);
            Console.WriteLine(c);
            #endregion

            #region problem 6
            RectangleShape rect = new RectangleShape(5, 10);
            rect.Draw();
            Console.WriteLine(rect.Area);
            #endregion

            #region problem 7
            IShape2 circleShape = new Circle(7);
            circleShape.Draw();
            circleShape.PrintDetails();
            #endregion

            #region problem 8
            IMovable movableCar = new MovableCar();
            movableCar.Move();
            #endregion

            #region problem 9
            File file = new File();
            file.Read();
            file.Write();
            #endregion

            #region problem 10
            RectangleShape2 rect2 = new RectangleShape2(4, 6);
            rect2.Draw();
            Console.WriteLine(rect2.CalculateArea());
            #endregion
        }
    }

    #region problem 1 class
    class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public Car() { Id = 0; Brand = "Unknown"; Price = 0; }
        public Car(int id) { Id = id; Brand = "Unknown"; Price = 0; }
        public Car(int id, string brand) { Id = id; Brand = brand; Price = 0; }
        public Car(int id, string brand, double price) { Id = id; Brand = brand; Price = price; }
        public override string ToString() => $"Car [Id={Id}, Brand={Brand}, Price={Price}]";
    }
    #endregion

    #region problem 2 class
    class Calculator
    {
        public int Sum(int a, int b) => a + b;
        public int Sum(int a, int b, int c) => a + b + c;
        public double Sum(double a, double b) => a + b;
    }
    #endregion

    #region problem 3 and 4 class
    class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Parent(int x, int y) { X = x; Y = y; }
        public virtual int Product() => X * Y;
        public override string ToString() => $"({X}, {Y})";
    }

    class Child : Parent
    {
        public int Z { get; set; }
        public Child(int x, int y, int z) : base(x, y) { Z = z; }
        public new int ProductHiding() => X * Y * Z;
        public override int Product() => X * Y * Z;
        public override string ToString() => $"({X}, {Y}, {Z})";
    }
    #endregion

    #region problem 6 class
    interface IShape
    {
        double Area { get; }
        void Draw();
    }

    class RectangleShape : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public RectangleShape(double width, double height) { Width = width; Height = height; }
        public double Area => Width * Height;
        public void Draw() => Console.WriteLine("Drawing Rectangle");
    }
    #endregion

    #region problem 7 class
    interface IShape2
    {
        double Area { get; }
        void Draw();
        void PrintDetails() => Console.WriteLine("Shape details: Area = " + Area);
    }

    class Circle : IShape2
    {
        public double Radius { get; set; }
        public Circle(double radius) { Radius = radius; }
        public double Area => 3.14 * Radius * Radius;
        public void Draw() => Console.WriteLine("Drawing Circle");
    }
    #endregion

    #region problem 8 class
    interface IMovable { void Move(); }
    class MovableCar : IMovable { public void Move() => Console.WriteLine("Car is moving"); }
    #endregion

    #region problem 9 class
    interface IReadable { void Read(); }
    interface IWritable { void Write(); }
    class File : IReadable, IWritable
    {
        public void Read() => Console.WriteLine("Reading file");
        public void Write() => Console.WriteLine("Writing file");
    }
    #endregion

    #region problem 10 class
    abstract class ShapeBase
    {
        public virtual void Draw() => Console.WriteLine("Drawing Shape");
        public abstract double CalculateArea();
    }

    class RectangleShape2 : ShapeBase
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public RectangleShape2(double width, double height) { Width = width; Height = height; }
        public override void Draw() => Console.WriteLine("Drawing Rectangle");
        public override double CalculateArea() => Width * Height;
    }
    #endregion
}

