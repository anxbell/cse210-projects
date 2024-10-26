using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    { //getting random scriptures
        List<Scripture> library = Scripture.InitializeScriptureLibrary();
        Scripture randomScripture = Scripture.GetRandomScripture(library);

        //loop to display with underscores
        while (!randomScripture.AllWordsHidden())
        {
            randomScripture.ClearConsole();
            randomScripture.ShowScripture(); //scripture with hidden words atm
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            randomScripture.HideWords(3);
        }
        //changed scripture to selectedScripture
        randomScripture.ClearConsole();
        randomScripture.ShowScripture(); //result
        Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
    }
}