public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordProgress()
    {
        return _points;
    }

    public override string GetProgress()
    {
        return "[ ]";
    }

    public override bool IsComplete()
    {
        return false;
    }
}
