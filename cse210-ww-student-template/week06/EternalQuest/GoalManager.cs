using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void AddGoal(Goal newGoal)
    {
        _goals.Add(newGoal);
    }

    public void RecordEvent(int index)
    {
        Goal goal = _goals[index];
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    public int GetGoalCount()
    {
        return _goals.Count;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return _score / 1000 + 1;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"You are level {GetLevel()}.");
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void SaveToFile(string filename)
    {
        StreamWriter outputFile = new StreamWriter(filename);

        outputFile.WriteLine(_score);

        foreach (Goal goal in _goals)
        {
            outputFile.WriteLine(goal.GetStringRepresentation());
        }

        outputFile.Close();
    }

    public void LoadFromFile(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("~|~");
            string goalType = parts[0];

            if (goalType == "SimpleGoal")
            {
                string name = parts[1];
                int points = int.Parse(parts[2]);
                bool isComplete = bool.Parse(parts[3]);
                _goals.Add(new SimpleGoal(name, points, isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                string name = parts[1];
                int points = int.Parse(parts[2]);
                _goals.Add(new EternalGoal(name, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = parts[1];
                int points = int.Parse(parts[2]);
                int targetAmount = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int amountCompleted = int.Parse(parts[5]);
                _goals.Add(new ChecklistGoal(name, points, targetAmount, bonus, amountCompleted));
            }
        }
    }
}
