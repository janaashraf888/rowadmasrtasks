using System;
using System.Text;

namespace day03
{
    internal class Program
    {
        class MyClass
        {
            public int Value;
        }
        static void Main(string[] args)
        {
            #region problem 1

            try
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();

                // Using int.Parse
                int number1 = int.Parse(input);
                Console.WriteLine("Using int.Parse: " + number1);

                // Using Convert.ToInt32
                int number2 = Convert.ToInt32(input);
                Console.WriteLine("Using Convert.ToInt32: " + number2);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: The number is too large or too small.");
            }
            #endregion

            #region problem 2
            Console.Write("Enter a number: ");
            string inputt = Console.ReadLine();

            int number;

            if (int.TryParse(inputt, out number))
            {
                Console.WriteLine("Valid number entered: " + number);
            }
            else
            {
                Console.WriteLine("Error: Invalid integer input.");
            }

            #endregion

            #region problem 3

            object obj;

            // Assign int
            obj = 10;
            Console.WriteLine("Value: " + obj);
            Console.WriteLine("HashCode: " + obj.GetHashCode());

            // Assign string
            obj = "Hello";
            Console.WriteLine("\nValue: " + obj);
            Console.WriteLine("HashCode: " + obj.GetHashCode());

            // Assign double
            obj = 25.5;
            Console.WriteLine("\nValue: " + obj);
            Console.WriteLine("HashCode: " + obj.GetHashCode());

            #endregion

            #region problem 4

            // Step 1: Create an object and assign a value
            MyClass obj1 = new MyClass();
            obj1.Value = 10;

            // Step 2: Create a second reference to the same object
            MyClass obj2 = obj1;

            // Step 3: Modify the value using one reference
            obj1.Value = 50;

            // Print value using the other reference
            Console.WriteLine("Value from obj2: " + obj2.Value);

            #endregion

            #region problem 5

            // Declare string
            string text = "Hello";

            // Print HashCode before modification
            Console.WriteLine("Before modification:");
            Console.WriteLine("Text: " + text);
            Console.WriteLine("HashCode: " + text.GetHashCode());

            // Modify string by concatenation
            text = text + " Hi Willy";

            // Print HashCode after modification
            Console.WriteLine("\nAfter modification:");
            Console.WriteLine("Text: " + text);
            Console.WriteLine("HashCode: " + text.GetHashCode());

            #endregion

            #region problem 6

            // Create StringBuilder
            StringBuilder sb = new StringBuilder("Hi Willy");

            // Print HashCode before modification
            Console.WriteLine("Before modification:");
            Console.WriteLine("Text: " + sb.ToString());
            Console.WriteLine("HashCode: " + sb.GetHashCode());

            // Append text
            sb.Append(" Welcome!");

            // Print HashCode after modification
            Console.WriteLine("\nAfter modification:");
            Console.WriteLine("Text: " + sb.ToString());
            Console.WriteLine("HashCode: " + sb.GetHashCode());

            #endregion

            #region problem 7

            Console.Write("Enter first number: ");
            int input1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int input2 = int.Parse(Console.ReadLine());

            int sum = input1 + input2;

            // 1. Concatenation (+ operator)
            Console.WriteLine("Sum is " + sum);

            // 2. Composite formatting
            Console.WriteLine(string.Format("Sum is {0}", sum));

            // 3. String interpolation
            Console.WriteLine($"Sum is {sum}");

            #endregion

            #region problem 8

            StringBuilder sbb = new StringBuilder("Hello");

            // Append text
            sb.Append(" World");
            Console.WriteLine("After Append: " + sbb.ToString());

            // Replace a substring
            sb.Replace("World", "C#");
            Console.WriteLine("After Replace: " + sbb.ToString());

            // Insert a string at a specific position
            sb.Insert(5, " Amazing");
            Console.WriteLine("After Insert: " + sbb.ToString());

            // Remove a portion of text
            sb.Remove(5, 8); // removes " Amazing"
            Console.WriteLine("After Remove: " + sbb.ToString());

            #endregion
        }
    }
}
