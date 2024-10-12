using System;

public class Entry
{

    public string _title;
    public string _content;
    public string _date;
    public string _prompt;


    public Entry(string title, string date, string prompt, string content)
    {
        _title = title;
        _date = date;
        _prompt = prompt;
        _content = content;


        //using Entry class (values passed as parameters) (object)
    }


    public void Display() {

    Console.WriteLine($"Title: {_title}");
    Console.WriteLine($"Date: {_date}");
    Console.WriteLine($"Prompt: {_prompt}");
    Console.WriteLine($"Content: {_content}");
        Console.WriteLine("-------------------------");
    }

}