using System;
using System.Collections.Generic;
using System.IO;

class ActivityLog
{
    private string _logFile;
    private string _notesFile;
    private List<string> _names;
    private Dictionary<string, int> _counts;
    private Dictionary<string, int> _seconds;

    public ActivityLog(string logFile, string notesFile)
    {
        _logFile = logFile;
        _notesFile = notesFile;
        _names = new List<string>();
        _counts = new Dictionary<string, int>();
        _seconds = new Dictionary<string, int>();

        Load();
    }

    public void RecordActivity(string name, int duration)
    {
        if (!_counts.ContainsKey(name))
        {
            _names.Add(name);
            _counts[name] = 0;
            _seconds[name] = 0;
        }

        _counts[name] = _counts[name] + 1;
        _seconds[name] = _seconds[name] + duration;

        Save();
    }

    public void RecordNotes(List<string> notes)
    {
        if (notes.Count == 0)
        {
            return;
        }

        List<string> lines = new List<string>();
        string stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        foreach (string note in notes)
        {
            lines.Add($"{stamp} | {note}");
        }

        File.AppendAllLines(_notesFile, lines);
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Your Mindfulness Log");
        Console.WriteLine();

        if (_names.Count == 0)
        {
            Console.WriteLine("You have not completed any activities yet.");
        }
        else
        {
            int totalSessions = 0;
            int totalSeconds = 0;

            foreach (string name in _names)
            {
                Console.WriteLine($"  {name}: {_counts[name]} sessions, {_seconds[name]} seconds");
                totalSessions += _counts[name];
                totalSeconds += _seconds[name];
            }

            Console.WriteLine();
            Console.WriteLine($"  Total: {totalSessions} sessions, {totalSeconds} seconds of mindfulness.");
        }

        DisplayRecentNotes();

        Console.WriteLine();
        Console.Write("Press enter to return to the menu.");
        Console.ReadLine();
        Console.Clear();
    }

    private void DisplayRecentNotes()
    {
        if (!File.Exists(_notesFile))
        {
            return;
        }

        string[] lines = File.ReadAllLines(_notesFile);

        if (lines.Length == 0)
        {
            return;
        }

        int start = lines.Length - 5;

        if (start < 0)
        {
            start = 0;
        }

        Console.WriteLine();
        Console.WriteLine("The last things you were grateful for:");

        for (int i = start; i < lines.Length; i++)
        {
            Console.WriteLine($"  {lines[i]}");
        }
    }

    private void Load()
    {
        if (!File.Exists(_logFile))
        {
            return;
        }

        foreach (string line in File.ReadAllLines(_logFile))
        {
            string[] parts = line.Split('|');

            if (parts.Length != 3)
            {
                continue;
            }

            int count = 0;
            int seconds = 0;

            if (int.TryParse(parts[1], out count) && int.TryParse(parts[2], out seconds))
            {
                _names.Add(parts[0]);
                _counts[parts[0]] = count;
                _seconds[parts[0]] = seconds;
            }
        }
    }

    private void Save()
    {
        List<string> lines = new List<string>();

        foreach (string name in _names)
        {
            lines.Add($"{name}|{_counts[name]}|{_seconds[name]}");
        }

        File.WriteAllLines(_logFile, lines);
    }
}
