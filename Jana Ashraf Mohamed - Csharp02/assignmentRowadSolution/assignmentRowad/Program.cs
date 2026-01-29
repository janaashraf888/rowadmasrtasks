using System;

namespace assignmentRowad
{
    internal class Program
    {
        class Person
        {
            public string Name;
        }

        static void Main()
        {
            #region Problem 1 - Sum of two numbers
            int x = 10;
            int y = 20;

            int sum = x + y;
            Console.WriteLine("Sum: " + sum);
            #endregion

            #region Problem 2 - Fixing errors
            int a = 10; 
            int b = 5;  

            Console.WriteLine(a + b); 
            #endregion

            #region Problem 3 - Variable declarations
            string fullName = "Your Full Name";
            int age = 21;
            double monthlySalary = 5000.50;
            bool isStudent = true;
            #endregion

            #region Problem 4 - Reference types behavior
            Person p1 = new Person();
            p1.Name = "Alice";

            Person p2 = p1; // Both point to same object
            p2.Name = "Bob";

            Console.WriteLine("p1 Name: " + p1.Name);
            Console.WriteLine("p2 Name: " + p2.Name);
            #endregion

            #region Problem 5 - Arithmetic operations
            int n = 15;
            int z = 4;

            int summ = n + z;
            int difference = n - z;
            int product = n * z;
            double division = n / z; 
            int remainder = n % z;

            Console.WriteLine("Sum: " + summ);
            Console.WriteLine("Difference: " + difference);
            Console.WriteLine("Product: " + product);
            Console.WriteLine("Division result: " + division);
            Console.WriteLine("Remainder: " + remainder);
            #endregion

            #region Problem 6 - Greater than 10 and even
            int number = 16;

            if (number > 10 && number % 2 == 0)
            {
                Console.WriteLine("The number is greater than 10 and even.");
            }
            else
            {
                Console.WriteLine("The number is NOT both greater than 10 and even.");
            }
            #endregion

            #region Problem 7 - Casting double to int
            Console.Write("Enter a double value: ");
            double num = double.Parse(Console.ReadLine());

            int explicitCast = (int)num;      // Explicit casting
            double implicitCast = explicitCast; // Implicit casting

            Console.WriteLine("Original double value: " + num);
            Console.WriteLine("After explicit casting to int: " + explicitCast);
            Console.WriteLine("After implicit casting back to double: " + implicitCast);
            #endregion

            #region Problem 8 - Parsing age
            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();

            int agee = int.Parse(ageInput);

            if (agee > 0)
            {
                Console.WriteLine("Age is valid.");
            }
            else
            {
                Console.WriteLine("Age is not valid.");
            }
            #endregion

            #region Problem 9 - Prefix vs Postfix increment
            int q = 5;

            Console.WriteLine("Postfix (q++): " + (q++)); // prints 5, then q becomes 6
            Console.WriteLine("Prefix (++q): " + (++q)); // q becomes 7, then prints 7
            #endregion
        }
    }
}
