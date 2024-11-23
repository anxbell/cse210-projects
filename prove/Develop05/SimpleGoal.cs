public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public void MarkComplete()
    {
        _isComplete = true;
    }

    public override int RecordProgress()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetProgress()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}
