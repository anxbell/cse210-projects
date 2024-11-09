using System;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Threading;

abstract class MindfulnessActivity
{
    private string _activityName;
    private int _duration;
    private string _description;
    private Random _randomGenerator = new Random();
    protected List<string> _prompts = new List<string>();

    //default Constructor
    public MindfulnessActivity()
    {
        _activityName = "activity";
        _description = "description";
        _duration = 10;
    }
    //Constructor
    public MindfulnessActivity(string activityName, string description, int duration)
    {
        _activityName = activityName;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity!\n");
        Console.WriteLine(_description);
    }

    public string GetReadyMessage()
    {
        return "Get Ready...";
    }

    public abstract void PerformActivity();

    public void SetDuration() //abstracting method to be implemented
    {
        // Ask the user for the duration in second
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        //
        // Read and parse the user input
        _duration = int.Parse(Console.ReadLine());
    }

    public void Countdown(string message)
    {
        Console.Write($"\n{message}");

        for (int i = 5; i > 0; i--)
        {
            Console.Write($" {i}");
            Thread.Sleep(1000);
            Console.Write("\b\b"); // Overwrite countdown number
        }

        Console.Write("  \r" + message); // Clear out remaining countdown
    }

    public void StartActivity()
    {
        DisplayStartMessage();
        SetDuration();
        Console.Clear();
        Console.WriteLine(GetReadyMessage());
        Animation();
        DateTime futureTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            PerformActivity();
        }

        WellDoneMessage();
        Animation();
        GetCompletedMessage();
        Animation();
        Console.Clear();
    }

    public static void WellDoneMessage()
    {
        Console.WriteLine("\nWell Done!");
    }

    public void GetCompletedMessage()
    {
        Console.WriteLine(
            $"\nYou have completed another {_duration} seconds of the {_activityName} Activity."
        );
    }

    public static void Animation()
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("—");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(10);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    // Method to get a random element from any list
    public T GetRandom<T>(List<T> list)
    {
        int index = _randomGenerator.Next(list.Count);
        return list[index];
    }

    public void DisplayRandomPrompt(List<string> prompts)
    {
        string randomPrompt = GetRandom(prompts);
        Console.WriteLine($" --- {randomPrompt} ---");
    }

    // Method to run any action repeatedly for the specified duration
    protected int RunActivityForDuration(Action action)
    {
        int listCount = 0;
        DateTime futureTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            action();
            listCount++; // Increment the counter after each action
        }

        return listCount; // Return the count after the loop ends
    }
}
