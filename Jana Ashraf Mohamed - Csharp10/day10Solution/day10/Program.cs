using System;
using System.Collections.Generic;

namespace day10
{
    public class Employee : ICloneable, IComparable<Employee>
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public Employee() { }
        public Employee(string name, double salary) { Name = name; Salary = salary; }
        public object Clone() { return new Employee(Name, Salary); }
        public int CompareTo(Employee other) { return Salary.CompareTo(other.Salary); }
    }

    public class Manager : Employee, IComparable<Manager>
    {
        public Manager(string name, double salary) : base(name, salary) { }
        public int CompareTo(Manager other) { return Salary.CompareTo(other.Salary); }
    }

    public class SortingAlgorithm<T>
    {
        public void Sort(T[] arr, Func<T, T, bool> compare)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (!compare(arr[j], arr[j + 1]))
                        Swap(ref arr[j], ref arr[j + 1]);
        }
        public static void Swap<TU>(ref TU a, ref TU b)
        {
            TU temp = a;
            a = b;
            b = temp;
        }
    }

    public static class SortingTwo<T>
    {
        public static void Sort(T[] arr, Comparison<T> comparison)
        {
            Array.Sort(arr, comparison);
        }
    }

    internal class Program
    {
        delegate string StringDelegate(string s);
        delegate int IntOperation(int a, int b);
        delegate R Transformer<T, R>(T input);

        static void Main()
        {
            #region Problem 1
            Employee[] e1 = { new Employee("A", 5000), new Employee("B", 3000), new Employee("C", 4000) };
            SortingAlgorithm<Employee> sa1 = new SortingAlgorithm<Employee>();
            sa1.Sort(e1, (x, y) => x.Salary < y.Salary);
            #endregion

            #region Problem 2
            int[] nums1 = { 5, 1, 4, 2, 3 };
            SortingTwo<int>.Sort(nums1, (x, y) => y.CompareTo(x));
            #endregion

            #region Problem 3
            string[] s1 = { "one", "three", "two", "four" };
            SortingTwo<string>.Sort(s1, (x, y) => x.Length.CompareTo(y.Length));
            #endregion

            #region Problem 4
            Manager[] m1 = { new Manager("M1", 7000), new Manager("M2", 6000) };
            SortingTwo<Manager>.Sort(m1, (x, y) => x.CompareTo(y));
            #endregion

            #region Problem 5
            Employee[] e2 = { new Employee("Ali", 5000), new Employee("Omar", 4000) };
            SortingAlgorithm<Employee> sa2 = new SortingAlgorithm<Employee>();
            Func<Employee, Employee, bool> compName = (x, y) => x.Name.Length < y.Name.Length;
            sa2.Sort(e2, compName);
            #endregion

            #region Problem 6
            int[] nums2 = { 4, 2, 1, 3 };
            SortingTwo<int>.Sort(nums2, delegate (int x, int y) { return x.CompareTo(y); });
            int[] nums3 = { 4, 2, 1, 3 };
            SortingTwo<int>.Sort(nums3, (x, y) => x.CompareTo(y));
            #endregion

            #region Problem 7
            int[] swapArr = { 1, 2, 3 };
            SortingAlgorithm<int>.Swap(ref swapArr[0], ref swapArr[2]);
            #endregion

            #region Problem 8
            Employee[] e3 = { new Employee("Ali", 5000), new Employee("Adam", 5000), new Employee("Sara", 4000) };
            SortingTwo<Employee>.Sort(e3, (x, y) => { int r = x.Salary.CompareTo(y.Salary); return r != 0 ? r : x.Name.CompareTo(y.Name); });
            #endregion

            #region Problem 9
            int d1 = GetDefault<int>();
            Employee d2 = GetDefault<Employee>();
            #endregion

            #region Problem 10
            Employee[] e4 = { new Employee("A", 5000), new Employee("B", 3000) };
            Employee[] cloneArr = new Employee[e4.Length];
            for (int i = 0; i < e4.Length; i++) cloneArr[i] = (Employee)e4[i].Clone();
            SortingAlgorithm<Employee> sa3 = new SortingAlgorithm<Employee>();
            sa3.Sort(cloneArr, (x, y) => x.Salary < y.Salary);
            #endregion

            #region Problem 11
            List<string> list1 = new List<string> { "one", "two", "three" };
            List<string> upper = Apply(list1, s => s.ToUpper());
            List<string> reverse = Apply(list1, s => { char[] c = s.ToCharArray(); Array.Reverse(c); return new string(c); });
            #endregion

            #region Problem 12
            int r1 = Operate(5, 3, (a, b) => a + b);
            int r2 = Operate(5, 3, (a, b) => a - b);
            int r3 = Operate(5, 3, (a, b) => a * b);
            int r4 = Operate(6, 3, (a, b) => a / b);
            #endregion

            #region Problem 13
            List<int> li = new List<int> { 1, 2, 3 };
            List<string> ls = Transform(li, x => x.ToString());
            #endregion

            #region Problem 14
            Func<int, int> square = x => x * x;
            List<int> li2 = new List<int> { 1, 2, 3 };
            List<int> sq = ApplyFunc(li2, square);
            #endregion

            #region Problem 15
            Action<string> print = s => Console.WriteLine(s);
            ApplyAction(new List<string> { "a", "b", "c" }, print);
            #endregion

            #region Problem 16
            Predicate<int> even = x => x % 2 == 0;
            List<int> evens = Filter(new List<int> { 1, 2, 3, 4, 5 }, even);
            #endregion

            #region Problem 17
            List<string> f1 = FilterStrings(new List<string> { "apple", "banana", "avocado" }, delegate (string s) { return s.StartsWith("a"); });
            #endregion

            #region Problem 18
            int op1 = OperateAnon(4, 2, delegate (int a, int b) { return a + b; });
            int op2 = OperateAnon(4, 2, delegate (int a, int b) { return a - b; });
            int op3 = OperateAnon(4, 2, delegate (int a, int b) { return a * b; });
            #endregion

            #region Problem 19
            List<string> f2 = FilterStrings(new List<string> { "one", "three", "ten" }, s => s.Length > 3 || s.Contains("e"));
            #endregion

            #region Problem 20
            double dres1 = OperateDouble(5, 2, (a, b) => a / b);
            double dres2 = OperateDouble(2, 3, (a, b) => Math.Pow(a, b));
            #endregion
        }

        static T GetDefault<T>() { return default(T); }
        static List<string> Apply(List<string> list, StringDelegate del) { List<string> r = new List<string>(); foreach (var s in list) r.Add(del(s)); return r; }
        static int Operate(int a, int b, IntOperation op) { return op(a, b); }
        static List<R> Transform<T, R>(List<T> list, Transformer<T, R> del) { List<R> r = new List<R>(); foreach (var i in list) r.Add(del(i)); return r; }
        static List<int> ApplyFunc(List<int> list, Func<int, int> f) { List<int> r = new List<int>(); foreach (var i in list) r.Add(f(i)); return r; }
        static void ApplyAction(List<string> list, Action<string> act) { foreach (var s in list) act(s); }
        static List<int> Filter(List<int> list, Predicate<int> p) { List<int> r = new List<int>(); foreach (var i in list) if (p(i)) r.Add(i); return r; }
        static List<string> FilterStrings(List<string> list, Func<string, bool> f) { List<string> r = new List<string>(); foreach (var s in list) if (f(s)) r.Add(s); return r; }
        static int OperateAnon(int a, int b, IntOperation op) { return op(a, b); }
        static double OperateDouble(double a, double b, Func<double, double, double> f) { return f(a, b); }
    }
}