using System;

namespace day09
{
    internal class Program
    {
        static void Main()
        {
            //part 1
            #region problem 1
            foreach (Weekdays d in Enum.GetValues(typeof(Weekdays)))
                Console.WriteLine($"{d} {(int)d}");
            #endregion
            #region problem 2
            foreach (Grades g in Enum.GetValues(typeof(Grades)))
                Console.WriteLine($"{g} {(short)g}");
            #endregion
            #region problem 3
            Person p1 = new Person("Ali", "IT");
            Person p2 = new Person("Sara", "HR");
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            #endregion
            #region problem 4
            Child ch = new Child();
            ch.DisplaySalary();
            #endregion
            #region problem 5
            Console.WriteLine(Utility.Perimeter(5, 4));
            #endregion
            #region problem 6
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(1, 4);
            Console.WriteLine(c1 * c2);
            #endregion
            #region problem 7
            Console.WriteLine(sizeof(byte));
            Console.WriteLine(sizeof(int));
            #endregion
            #region problem 8
            Console.WriteLine(Utility.ConvertTemp(0, true));
            Console.WriteLine(Utility.ConvertTemp(32, false));
            #endregion
            #region problem 9
            if (Enum.TryParse("A", out Grades r))
                Console.WriteLine(r);
            else
                Console.WriteLine("Invalid");
            #endregion
            #region problem 10
            Employee e1 = new Employee(1, "Omar");
            Employee e2 = new Employee(2, "Mona");
            Employee[] arr = { e1, e2 };
            Console.WriteLine(Helper2<Employee>.SearchArray(arr, new Employee(1, "Omar")));
            #endregion
            #region problem 11
            Console.WriteLine(Helper.Max(5, 9));
            Console.WriteLine(Helper.Max(3.5, 7.2));
            Console.WriteLine(Helper.Max("A", "B"));
            #endregion
            #region problem 12
            int[] x = { 1, 2, 1 };
            Helper2<int>.ReplaceArray(x, 1, 9);
            string[] y = { "a", "b", "a" };
            Helper2<string>.ReplaceArray(y, "a", "z");
            #endregion
            #region problem 13
            Rectangle r1 = new Rectangle { Length = 5, Width = 3 };
            Rectangle r2 = new Rectangle { Length = 2, Width = 1 };
            SwapRect(ref r1, ref r2);
            #endregion
            #region problem 14
            Department d1 = new Department(1, "IT");
            Department d2 = new Department(2, "HR");
            Employee ee1 = new Employee(1, "A", d1);
            Employee ee2 = new Employee(2, "B", d2);
            Employee[] emps = { ee1, ee2 };
            Console.WriteLine(Helper2<Employee>.SearchArray(emps, new Employee(0, "", d1)));
            #endregion
            #region problem 15
            CircleStruct cs1 = new CircleStruct { Radius = 5, Color = "Red" };
            CircleStruct cs2 = new CircleStruct { Radius = 5, Color = "Red" };
            Console.WriteLine(cs1 == cs2);
            Console.WriteLine(cs1.Equals(cs2));
            CircleClass cc1 = new CircleClass { Radius = 5, Color = "Red" };
            CircleClass cc2 = new CircleClass { Radius = 5, Color = "Red" };
            Console.WriteLine(cc1 == cc2);
            Console.WriteLine(cc1.Equals(cc2));
            #endregion

            //part 2
            #region problem 1
            int[] a = { 1, 2, 3, 4 };
            string[] b = { "A", "B", "C" };
            var ra = ReverseArray(a);
            var rb = ReverseArray(b);
            #endregion
            #region problem 2
            MyStack<int> s = new MyStack<int>(5);
            s.Push(10);
            s.Push(20);
            s.Peek();
            s.Pop();
            #endregion
            #region problem 3
            int[] arr2 = { 1, 2, 3 };
            Swap(arr2, 0, 2);
            #endregion
            #region problem 4
            int[] nums = { 5, 9, 3 };
            Console.WriteLine(MaxElement(nums));
            #endregion
        }

        static T[] ReverseArray<T>(T[] arr)
        {
            T[] r = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                r[i] = arr[arr.Length - 1 - i];
            return r;
        }

        static void Swap<T>(T[] arr, int i, int j)
        {
            T t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        static T MaxElement<T>(T[] arr) where T : IComparable
        {
            T m = arr[0];
            foreach (T x in arr)
                if (x.CompareTo(m) > 0) m = x;
            return m;
        }

        static void SwapRect(ref Rectangle r1, ref Rectangle r2)
        {
            Rectangle t = r1;
            r1 = r2;
            r2 = t;
        }
    }

    enum Weekdays { Monday = 1, Tuesday, Wednesday, Thursday, Friday }
    enum Grades : short { A = 1, B = 2, C = 3, D = 4, F = -1 }
    enum Gender : byte { Male = 1, Female = 2 }

    class Person
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Person(string n, string d) { Name = n; Department = d; }
        public override string ToString() => $"{Name} {Department}";
    }

    class Parent
    {
        public virtual decimal Salary { get; } = 1000;
    }

    class Child : Parent
    {
        public sealed override decimal Salary => 2000;
        public void DisplaySalary() { Console.WriteLine(Salary); }
    }

    static class Utility
    {
        public static double Perimeter(double l, double w) => 2 * (l + w);
        public static double ConvertTemp(double v, bool cToF) => cToF ? (v * 9 / 5) + 32 : (v - 32) * 5 / 9;
    }

    class ComplexNumber
    {
        public double Real { get; set; }
        public double Imag { get; set; }
        public ComplexNumber(double r, double i) { Real = r; Imag = i; }
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real * b.Real - a.Imag * b.Imag, a.Real * b.Imag + a.Imag * b.Real);
        public override string ToString() => $"{Real}+{Imag}i";
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public Employee(int id, string name) { Id = id; Name = name; }
        public Employee(int id, string name, Department d) { Id = id; Name = name; Department = d; }
        public override bool Equals(object obj)
        {
            if (obj is Employee e)
                return Department != null && e.Department != null ? Department.Equals(e.Department) : Id == e.Id && Name == e.Name;
            return false;
        }
        public override int GetHashCode() => Id.GetHashCode();
    }

    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department(int id, string name) { Id = id; Name = name; }
        public override bool Equals(object obj)
        {
            if (obj is Department d) return Id == d.Id && Name == d.Name;
            return false;
        }
        public override int GetHashCode() => Id.GetHashCode();
    }

    static class Helper
    {
        public static T Max<T>(T a, T b) where T : IComparable
            => a.CompareTo(b) > 0 ? a : b;
    }

    static class Helper2<T>
    {
        public static int SearchArray(T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i].Equals(value)) return i;
            return -1;
        }
        public static void ReplaceArray(T[] arr, T oldValue, T newValue)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i].Equals(oldValue)) arr[i] = newValue;
        }
    }

    struct Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }
    }

    struct CircleStruct
    {
        public double Radius { get; set; }
        public string Color { get; set; }
        public static bool operator ==(CircleStruct a, CircleStruct b)
            => a.Radius == b.Radius && a.Color == b.Color;
        public static bool operator !=(CircleStruct a, CircleStruct b) => !(a == b);
        public override bool Equals(object obj)
        {
            if (obj is CircleStruct c) return this == c;
            return false;
        }
        public override int GetHashCode() => Radius.GetHashCode();
    }

    class CircleClass
    {
        public double Radius { get; set; }
        public string Color { get; set; }
    }

    class MyStack<T>
    {
        T[] arr;
        int top = -1;
        public MyStack(int size) { arr = new T[size]; }
        public void Push(T item) { arr[++top] = item; }
        public T Pop() { return arr[top--]; }
        public T Peek() { return arr[top]; }
    }
}