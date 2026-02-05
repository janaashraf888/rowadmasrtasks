using System;

namespace day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1
            try
            {
                Console.Write("Enter first number: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                int num2 = int.Parse(Console.ReadLine());
                int result = num1 / num2;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid integers.");
            }
            finally
            {
                Console.WriteLine("Operation complete");
            }
            #endregion

            #region Problem 2
            TestDefensiveCode();
            #endregion

            #region Problem 3
            int? number = null;
            int result0 = number ?? 10;
            Console.WriteLine("Nullable number: " + number);
            Console.WriteLine("Result after ?? operator: " + result0);
            if (number.HasValue)
            {
                Console.WriteLine("Using HasValue: Value = " + number.Value);
            }
            else
            {
                Console.WriteLine("Using HasValue: number is null");
            }
            number = 25;
            Console.WriteLine("\nAfter assigning a value:");
            Console.WriteLine("Nullable number: " + number);
            if (number.HasValue)
            {
                Console.WriteLine("Using HasValue: Value = " + number.Value);
            }
            Console.WriteLine("Using Value property: " + number.Value);
            #endregion

            #region Problem 4
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (i + 1) * 10;
            }
            try
            {
                Console.Write("Enter an index to access (0 - 4): ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("Value at index " + index + ": " + numbers[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Index is out of range. Please enter a value between 0 and 4.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid integer.");
            }
            finally
            {
                Console.WriteLine("Program finished.");
            }
            #endregion

            #region Problem 5
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Enter element [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 3; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < 3; j++)
                    rowSum += matrix[i, j];
                Console.WriteLine($"Row {i + 1} Sum = {rowSum}");
            }
            for (int j = 0; j < 3; j++)
            {
                int colSum = 0;
                for (int i = 0; i < 3; i++)
                    colSum += matrix[i, j];
                Console.WriteLine($"Column {j + 1} Sum = {colSum}");
            }
            #endregion

            #region Problem 6
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[4];
            jaggedArray[2] = new int[3];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                    jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                    Console.Write(jaggedArray[i][j] + " ");
                Console.WriteLine();
            }
            #endregion

            #region Problem 7
#nullable enable
            string? name = null;
            string? choice = Console.ReadLine();
            if (choice?.ToLower() == "yes")
                name = Console.ReadLine();
            if (name != null)
                Console.WriteLine("Hello, " + name!);
            else
                Console.WriteLine("No name was entered.");
#nullable disable
            #endregion

            #region Problem 8
            try
            {
                int num = 50;
                object boxedNumber = num;
                int unboxedNumber = (int)boxedNumber;
                object text = "Hello";
                int invalidCast = (int)text;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Error: Invalid cast");
            }
            #endregion

            #region Problem 9
            int num01, num02;
            num01 = int.Parse(Console.ReadLine());
            num02 = int.Parse(Console.ReadLine());
            int sum, product;
            SumAndMultiply(num01, num02, out sum, out product);
            Console.WriteLine(sum);
            Console.WriteLine(product);
            #endregion

            #region Problem 10
            PrintMultipleTimes("Hello World");
            PrintMultipleTimes(message: "Hi there!", count: 3);
            static void PrintMultipleTimes(string message, int count = 5)
            {
                for (int i = 0; i < count; i++)
                    Console.WriteLine(message);
            }
            #endregion

            #region Problem 11
            int?[]? nullableArray = null;
            int? length = nullableArray?.Length;
            nullableArray = new int?[5] { 1, null, 3, 4, null };
            for (int i = 0; i < nullableArray?.Length; i++)
                Console.WriteLine(nullableArray?[i]?.ToString() ?? "null");
            #endregion

            #region Problem 12
            string? day = Console.ReadLine();
            int dayNumber = day?.ToLower() switch
            {
                "monday" => 1,
                "tuesday" => 2,
                "wednesday" => 3,
                "thursday" => 4,
                "friday" => 5,
                "saturday" => 6,
                "sunday" => 7,
                _ => 0
            };
            Console.WriteLine(dayNumber != 0 ? dayNumber.ToString() : "Invalid day");
            #endregion

            #region Problem 13
            int sum1 = SumArray(1, 2, 3, 4, 5);
            int[] arr = { 10, 20, 30 };
            int sum2 = SumArray(arr);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            #endregion

            #region Problem 14
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
                Console.WriteLine(i);
            #endregion

            #region Problem 15
            int m = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 12; i++)
                Console.WriteLine(m * i);
            #endregion

            #region Problem 16
            int ev = int.Parse(Console.ReadLine());
            for (int i = 2; i <= ev; i += 2)
                Console.WriteLine(i);
            #endregion

            #region Problem 17
            int baseNum = int.Parse(Console.ReadLine());
            int exponent = int.Parse(Console.ReadLine());
            int resultExp = 1;
            for (int i = 0; i < exponent; i++)
                resultExp *= baseNum;
            Console.WriteLine(resultExp);
            #endregion

            #region Problem 18
            string txt = Console.ReadLine();
            char[] arrTxt = txt.ToCharArray();
            Array.Reverse(arrTxt);
            Console.WriteLine(new string(arrTxt));
            #endregion

            #region Problem 19
            int val = int.Parse(Console.ReadLine());
            int reversed = 0;
            while (val > 0)
            {
                reversed = reversed * 10 + val % 10;
                val /= 10;
            }
            Console.WriteLine(reversed);
            #endregion

            #region Problem 20
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = int.Parse(Console.ReadLine());
            int maxDist = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        maxDist = Math.Max(maxDist, j - i - 1);
                }
            }
            Console.WriteLine(maxDist);
            #endregion

            #region Problem 21
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(' ');
            Array.Reverse(words);
            Console.WriteLine(string.Join(" ", words));
            #endregion
        }

        #region Problem 2 Method
        static void TestDefensiveCode()
        {
            int x, y;
            do
            {
                x = int.Parse(Console.ReadLine());
            }
            while (x <= 0);
            do
            {
                y = int.Parse(Console.ReadLine());
            }
            while (y <= 1);
        }
        #endregion

        #region Problem 9 Method
        static void SumAndMultiply(int x, int y, out int sum, out int product)
        {
            sum = x + y;
            product = x * y;
        }
        #endregion

        #region Problem 13 Method
        static int SumArray(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
                sum += num;
            return sum;
        }
        #endregion
    }
}
