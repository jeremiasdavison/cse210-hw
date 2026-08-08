using System;

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public ChecklistGoal(string name, int points, int targetAmount, int bonus, int amountCompleted) : base(name, points)
    {
        _targetAmount = targetAmount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        if (_amountCompleted == _targetAmount)
        {
            return GetPoints() + _bonus;
        }
        else
        {
            return GetPoints();
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    public override string GetStatus()
    {
        string checkBox = IsComplete() ? "[X] " : "[ ] ";
        return checkBox + GetName() + " Completed " + _amountCompleted + "/" + _targetAmount + " times";
    }

    public override string GetStringRepresentation()
    {
        return "ChecklistGoal~|~" + GetName() + "~|~" + GetPoints() + "~|~" + _targetAmount + "~|~" + _bonus + "~|~" + _amountCompleted;
    }
}
