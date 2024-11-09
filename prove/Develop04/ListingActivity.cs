using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;

class ListingActivity : MindfulnessActivity
{
    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            10
        )
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void DisplayListItem()
    {
        Console.Write("> ");
        string response = Console.ReadLine();
    }
    //use to count the list items with the time while loop



    public override void PerformActivity()
    {
        Console.WriteLine("\nList as many responses you can to the following prompt:");

        DisplayRandomPrompt(_prompts);

        Countdown("You may begin in:");
        Console.WriteLine();

        int listCount = RunActivityForDuration(DisplayListItem);

        Console.WriteLine($"You listed {listCount} items!");
    }
}

