using System;
using System.Text.Json;

public class User
{
    private string _name;
    private int _score;

    public string name
    {
        get => _name;
        set => _name = value;
    }
    public int score
    {
        get => _score;
        set => _score = value;
    }

    public User(string name)
    {
        _name = name;
        _score = 0;
    }

    public string GetUserName()
    {
        return _name;
    }

    public int GetScore()
    {
        return _score;
    }

    public void UpdateScore(int points)
    {
        _score += points;
    }

    // convert User object to JSON
    public string ToJson()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }

    // create User object from JSON
    public static User FromJson(string json)
    {
        return JsonSerializer.Deserialize<User>(json);
    }
}
