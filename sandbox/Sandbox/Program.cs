using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = GetValidatedInput("Enter your journal entry: ");
        Console.WriteLine($"You entered: {userInput}");
    }

    // here we are using abstraction for validating user input
    static string GetValidatedInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input)); // we make a simple validation check

        return input;
    }
}