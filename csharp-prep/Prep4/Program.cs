using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {

        // using System.Collections.Generic;
        // Any file that uses Lists

        // List<int> numbers = new List<int>();
        // declares a list

        // To add items to the list, you use the 
        //numbers.Add() method:

        // size of the list
        // Console.WriteLine(words.Count);

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        List<int> numbers = new List<int>();
        int number = -1;
        int sum = 0; 

        while (number != 0) {
 

            Console.WriteLine("Enter number: ");
            number = int.Parse(Console.ReadLine());


            if (number != 0) {

            numbers.Add(number);

            }


            sum += number;
        

        }


        float avg = 0;

        avg = ((float)sum) / numbers.Count;

        Console.WriteLine($"The summary is: {sum}");
        Console.WriteLine($"The average is: {avg}");

        int max = numbers[0];

        foreach (int num in numbers)
        {
            if (num > max)
            {
                // if this number is greater than the max, we have found the new max!         numbers.Sort();
                max = num;
            }
        }

        int min = numbers[0];

            foreach (int num in numbers)
                {
                    if (num > 0)
                    {

                        if (num < min) {
                        // if this number is greater than the max, we have found the new max!         
                        min = num;
                        }
                    }
                }


        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest number is: {min}");
        Console.WriteLine("The sorted list is:");

        numbers.Sort();
        foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

    }
}