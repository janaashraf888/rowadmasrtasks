using System;

namespace day04
{
    internal class Program
    {
        enum DayOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static void Main(string[] args)
        {
            #region Problem 1

            // 1) Array initialization using new int[size]
            int[] arr1 = new int[3];
            arr1[0] = 10;
            arr1[1] = 20;
            arr1[2] = 30;

            Console.WriteLine("Array 1 (new int[size]):");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }

            Console.WriteLine();

            // 2) Array initialization using initializer list
            int[] arr2 = { 40, 50, 60 };

            Console.WriteLine("Array 2 (initializer list):");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.WriteLine(arr2[i]);
            }

            Console.WriteLine();

            // 3) Array initialization using Array syntax sugar
            int[] arr3 = new int[] { 70, 80, 90 };

            Console.WriteLine("Array 3 (array syntax sugar):");
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.WriteLine(arr3[i]);
            }

            Console.WriteLine();

            // Demonstrating IndexOutOfRangeException
            try
            {
                Console.WriteLine("Accessing invalid index:");
                Console.WriteLine(arr1[5]); // Invalid index
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }

            #endregion

            #region Problem 2

            int[] arra1 = { 1, 2, 3 };

            // Shallow copy
            int[] arra2 = arra1;
            arra2[0] = 100;

            Console.WriteLine("After shallow copy modification:");
            Console.WriteLine(arra1[0]); // affected
            Console.WriteLine(arra2[0]);

            // Deep copy using Clone
            int[] arra3 = (int[])arra1.Clone();
            arra3[1] = 200;

            Console.WriteLine("\nAfter deep copy modification:");
            Console.WriteLine(arra1[1]); // not affected
            Console.WriteLine(arra3[1]);

            #endregion

            #region Problem 3

            int[,] grades = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter grades for Student {i + 1}:");
                for (int j = 0; j < 3; j++)
                {
                    grades[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nStudent Grades:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Student {i + 1}: ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grades[i, j] + " ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Problem 4

            int[] arr = { 5, 2, 9, 1, 7 };

            Console.WriteLine("Original Array:");
            PrintArray(arr);

            // Sort
            Array.Sort(arr);
            Console.WriteLine("\nAfter Sort():");
            PrintArray(arr);   // Array is sorted ascending

            // Reverse
            Array.Reverse(arr);
            Console.WriteLine("\nAfter Reverse():");
            PrintArray(arr);   // Order is reversed

            // IndexOf
            int index = Array.IndexOf(arr, 9);
            Console.WriteLine("\nIndexOf 9:");
            Console.WriteLine(index);   // Returns index of element

            // Copy
            int[] copyArr = new int[5];
            Array.Copy(arr, copyArr, arr.Length);
            Console.WriteLine("\nAfter Copy():");
            PrintArray(copyArr);   // New independent array

            // Clear
            Array.Clear(arr, 0, arr.Length);
            Console.WriteLine("\nAfter Clear():");
            PrintArray(arr);   // All elements set to 0

            static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
                Console.Write(item + " ");
            Console.WriteLine();

            
        }
            #endregion

            #region Problem 5

            int[] arra = { 10, 20, 30, 40, 50 };

            // for loop
            for (int i = 0; i < arra.Length; i++)
                Console.WriteLine(arra[i]);

            // foreach loop
            foreach (int item in arra)
                Console.WriteLine(item);

            // while loop (reverse order)
            int ind = arra.Length - 1;
            while (ind >= 0)
            {
                Console.WriteLine(arra[ind]);
                ind--;
            }

            #endregion

            #region Problem 6

            int number;
            bool isValid;

            do
            {
                Console.Write("Enter a positive odd number: ");
                isValid = int.TryParse(Console.ReadLine(), out number);

            } while (!isValid || number <= 0 || number % 2 == 0);

            Console.WriteLine("Valid number entered: " + number);

            #endregion

            #region Problem 7

            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            for (int i = 0; i < matrix.GetLength(0); i++) // rows
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // columns
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Problem 8

            Console.Write("Enter a month number (1-12): ");
            int month = int.Parse(Console.ReadLine());

            // Using if-else
            if (month == 1) Console.WriteLine("January");
            else if (month == 2) Console.WriteLine("February");
            else if (month == 3) Console.WriteLine("March");
            else if (month == 4) Console.WriteLine("April");
            else if (month == 5) Console.WriteLine("May");
            else if (month == 6) Console.WriteLine("June");
            else if (month == 7) Console.WriteLine("July");
            else if (month == 8) Console.WriteLine("August");
            else if (month == 9) Console.WriteLine("September");
            else if (month == 10) Console.WriteLine("October");
            else if (month == 11) Console.WriteLine("November");
            else if (month == 12) Console.WriteLine("December");
            else Console.WriteLine("Invalid month number");

            // Using switch
            switch (month)
            {
                case 1: Console.WriteLine("January"); break;
                case 2: Console.WriteLine("February"); break;
                case 3: Console.WriteLine("March"); break;
                case 4: Console.WriteLine("April"); break;
                case 5: Console.WriteLine("May"); break;
                case 6: Console.WriteLine("June"); break;
                case 7: Console.WriteLine("July"); break;
                case 8: Console.WriteLine("August"); break;
                case 9: Console.WriteLine("September"); break;
                case 10: Console.WriteLine("October"); break;
                case 11: Console.WriteLine("November"); break;
                case 12: Console.WriteLine("December"); break;
                default: Console.WriteLine("Invalid month number"); break;
            }

            #endregion

            #region Problem 9

            int[] array = { 5, 2, 8, 2, 9, 1 };

            Console.WriteLine("Original Array: " + string.Join(", ", array));

            // Sort the array
            Array.Sort(array);
            Console.WriteLine("Sorted Array: " + string.Join(", ", array));

            // Search for a value
            int value = 2;
            int firstIndex = Array.IndexOf(array, value);
            int lastIndex = Array.LastIndexOf(array, value);

            Console.WriteLine($"First index of {value}: {firstIndex}");
            Console.WriteLine($"Last index of {value}: {lastIndex}");

            #endregion

            #region Problem 10

            int[] ar = { 1, 2, 3, 4, 5 };

            // Using for loop
            int sumFor = 0;
            for (int i = 0; i < ar.Length; i++)
                sumFor += ar[i];
            Console.WriteLine("Sum using for loop: " + sumFor);

            // Using foreach loop
            int sumForeach = 0;
            foreach (int item in ar)
                sumForeach += item;
            Console.WriteLine("Sum using foreach loop: " + sumForeach);

            #endregion

            #region Problem 11

            Console.Write("Enter a number (1-7) for the day: ");
            int dayNumber;
            bool isValidd = int.TryParse(Console.ReadLine(), out dayNumber);

            if (isValidd && dayNumber >= 1 && dayNumber <= 7)
            {
                // Convert integer to enum using Enum.Parse
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayNumber.ToString());
                Console.WriteLine("Day: " + day);
            }
            else
            {
                Console.WriteLine("Invalid input! Enter a number between 1 and 7.");
            }

            #endregion
        }
    }
}
