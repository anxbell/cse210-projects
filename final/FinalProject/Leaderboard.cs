using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Leaderboard
{
    public List<User> Users { get; private set; } = new List<User>();

    // Add or update user in the leaderboard
    public void AddUser(User user)
    {
        // Check if the user already exists
        var existingUser = Users.Find(u => u.name == user.name);
        if (existingUser != null)
        {
            // Update the existing user's score
            existingUser.UpdateScore(user.GetScore());
        }
        else
        {
            // Add new user if not found
            Users.Add(user);
        }
    }

    // Display the leaderboard
    public void DisplayLeaderboard()
    {
        Console.WriteLine("\nLeaderboard:");
        foreach (var user in Users)
        {
            Console.WriteLine($"{user.GetUserName()}: {user.GetScore()} points");
        }
        Console.WriteLine();
    }

    public void SaveToFile(string fileName)
    {
        string json = JsonSerializer.Serialize(Users, new JsonSerializerOptions { WriteIndented = true });
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
