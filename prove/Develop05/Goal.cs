public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Method to get the name
    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    // Method to get the points
    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordProgress();
    public abstract string GetProgress();
    public abstract bool IsComplete();
}
