using System;

namespace day06
{
    internal class Program
    {
        #region Problem 1
        struct Point1
        {
            public int X;
            public int Y;

            public Point1(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }
        #endregion

        #region Problem 2
        class TypeA
        {
            private int F = 10;
            internal int G = 20;
            public int H = 30;

            public int GetF()
            {
                return F;
            }
        }
        #endregion

        #region Problem 3
        struct EmployeeStruct
        {
            private int empId;
            private string name;
            private double salary;

            public void SetName(string n)
            {
                name = n;
            }

            public string GetName()
            {
                return name;
            }

            public int EmpId
            {
                get { return empId; }
                set { empId = value; }
            }

            public double Salary
            {
                get { return salary; }
                set { salary = value; }
            }
        }
        #endregion

        #region Problem 4
        struct PointOverload
        {
            public int X;
            public int Y;

            public PointOverload(int x)
            {
                X = x;
                Y = 0;
            }

            public PointOverload(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }
        #endregion

        #region Problem 5
        struct PointCustom
        {
            public int X;
            public int Y;

            public PointCustom(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"Point Coordinates -> X: {X}, Y: {Y}";
            }
        }
        #endregion

        #region Problem 6
        struct PointValue
        {
            public int X;
            public int Y;

            public PointValue(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }

        class EmployeeReference
        {
            public int EmpId;
            public string Name;

            public EmployeeReference(int id, string name)
            {
                EmpId = id;
                Name = name;
            }

            public override string ToString()
            {
                return $"EmpID: {EmpId}, Name: {Name}";
            }
        }
        #endregion

        static void Main()
        {
            #region Problem 1 Test
            Point1 p1 = new Point1(0, 0);
            Point1 p2 = new Point1(5, 10);
            Console.WriteLine("Problem 1:");
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine();
            #endregion

            #region Problem 2 Test
            TypeA obj = new TypeA();
            Console.WriteLine("Problem 2:");
            Console.WriteLine("G = " + obj.G);
            Console.WriteLine("H = " + obj.H);
            Console.WriteLine("F = " + obj.GetF());
            Console.WriteLine();
            #endregion

            #region Problem 3 Test
            EmployeeStruct emp = new EmployeeStruct();
            emp.EmpId = 101;
            emp.SetName("Ahmed");
            emp.Salary = 5000;
            Console.WriteLine("Problem 3:");
            Console.WriteLine("Employee ID: " + emp.EmpId);
            Console.WriteLine("Employee Name: " + emp.GetName());
            Console.WriteLine("Employee Salary: " + emp.Salary);
            Console.WriteLine();
            #endregion

            #region Problem 4 Test
            PointOverload po1 = new PointOverload(5);
            PointOverload po2 = new PointOverload(7, 10);
            Console.WriteLine("Problem 4:");
            Console.WriteLine(po1);
            Console.WriteLine(po2);
            Console.WriteLine();
            #endregion

            #region Problem 5 Test
            PointCustom[] points = new PointCustom[]
            {
                new PointCustom(1, 2),
                new PointCustom(5, 10),
                new PointCustom(7, 3),
                new PointCustom(0, 0)
            };
            Console.WriteLine("Problem 5:");
            foreach (var pt in points)
            {
                Console.WriteLine(pt);
            }
            Console.WriteLine();
            #endregion

            #region Problem 6 Test
            PointValue ptValue = new PointValue(5, 10);
            EmployeeReference empRef = new EmployeeReference(101, "Ahmed");

            Console.WriteLine("Problem 6: Value vs Reference Types");
            Console.WriteLine("Before method call:");
            Console.WriteLine("Point: " + ptValue);
            Console.WriteLine("Employee: " + empRef);

            ModifyPoint(ptValue);
            ModifyEmployee(empRef);

            Console.WriteLine("After method call:");
            Console.WriteLine("Point: " + ptValue);
            Console.WriteLine("Employee: " + empRef);
            #endregion
        }

        #region Problem 6 Methods
        static void ModifyPoint(PointValue p)
        {
            p.X = 100;
            p.Y = 200;
        }

        static void ModifyEmployee(EmployeeReference e)
        {
            e.EmpId = 999;
            e.Name = "Ali";
        }
        #endregion
    }
}

