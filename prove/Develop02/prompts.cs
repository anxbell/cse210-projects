using System;
using System.Collections.Generic;

public class Prompts {

    public List<String> _prompts = new List<String>();
    public Random _randomGenerator;


    public Prompts() {
        //creating prompts and storing them inside the list
        _prompts = new List<string>

        {
            "What was the best part of your day?", 
            "Describe a challenge you faced recently.",
            "What are you grateful for today?",
            "What made you smile today?",
            "What was the most interesting thing that happened to you today?",
            "What is something you wish you had done differently today?",
            "What is a book or movie that inspired you, and what did you take away from it?",
            "Imagine your ideal day. What would it look like?",
            "What do you do to take care of yourself when you're feeling stressed?"
        };

        _randomGenerator = new Random();
    }

    public string GeneratePrompt()
    {
        int index = _randomGenerator.Next(_prompts.Count);
        //getting random index for random prompt
        return _prompts[index];
    }

} 