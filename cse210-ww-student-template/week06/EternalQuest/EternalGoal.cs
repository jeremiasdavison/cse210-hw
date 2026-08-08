using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return "[ ] " + GetName() + " (never ending)";
    }

    public override string GetStringRepresentation()
    {
        return "EternalGoal~|~" + GetName() + "~|~" + GetPoints();
    }
}
