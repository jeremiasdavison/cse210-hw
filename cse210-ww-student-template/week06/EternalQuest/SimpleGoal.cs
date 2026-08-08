using System;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points, bool isComplete) : base(name, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStatus()
    {
        if (_isComplete)
        {
            return "[X] " + GetName();
        }
        else
        {
            return "[ ] " + GetName();
        }
    }

    public override string GetStringRepresentation()
    {
        return "SimpleGoal~|~" + GetName() + "~|~" + GetPoints() + "~|~" + _isComplete;
    }
}
