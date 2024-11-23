public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints
    ) : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordProgress()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                return _points + _bonusPoints;
            }
            return _points;
        }
        return 0;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    public override string GetProgress()
    {
        return $"{(_currentCount >= _targetCount ? "[X]" : "[ ]")}";
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }
}
