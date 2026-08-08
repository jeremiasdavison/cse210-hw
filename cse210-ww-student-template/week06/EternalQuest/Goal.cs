using System;

abstract class Goal
{
    private string _name;
    private int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStatus();

    public abstract string GetStringRepresentation();
}
