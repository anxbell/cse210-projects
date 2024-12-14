using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Leaderboard
{
    public List<User> Users { get; private set; } = new List<User>();

    // update user in the leaderboard
    public void AddUser(User user)
    { //if user exists (no names repeated)
    //asking for usernames instead of names in menu guide the user if it exist or not
        var existingUser = Users.Find(u => u.GetUserName() == user.GetUserName());
        if (existingUser != null)
        {
            // update user's score
            existingUser.UpdateScore(user.GetScore());
        }
        else
        {
            // add new user if not found
            Users.Add(user);
        }
    }

    // display the leaderboard
public void DisplayLeaderboard()
{
    Console.WriteLine("\n========== Leaderboard ==========");

    // Sort the users by score in descending order
    Users.Sort((user1, user2) => user2.GetScore().CompareTo(user1.GetScore()));

    Console.WriteLine($"{"Rank",-5}{"Player",-20}{"Score",10}");
    Console.WriteLine(new string('=', 40));

    int rank = 1;
    foreach (var user in Users)
    {
        Console.WriteLine($"{rank,-5}{user.GetUserName(),-20}{user.GetScore(),10}");
        rank++;
    }

    Console.WriteLine(new string('=', 40));
    Console.WriteLine();
}


public void SaveToFile(string fileName)
    {
        // sort before saving
        Users.Sort((user1, user2) => user2.GetScore().CompareTo(user1.GetScore()));

        string json = JsonSerializer.Serialize(
            Users,
            new JsonSerializerOptions { WriteIndented = true }
        );
        File.WriteAllText(fileName, json);
    }


    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            Users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        else
        {
            Console.WriteLine("Leaderboard file not found. Starting with an empty leaderboard.");
        }
    }
}
