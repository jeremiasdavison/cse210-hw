using System;
using System.Collections.Generic;

class GratitudeActivity : Activity
{
    private PromptQueue _prompts;
    private List<string> _notes;

    public GratitudeActivity() : base(
        "Gratitude Activity",
        "This activity will help you notice the good that is already in your day. You will answer short prompts with one specific thing you are grateful for, and your answers will be saved so you can read them again later.")
    {
        _prompts = new PromptQueue(new List<string>
        {
            "Name one small thing that went well today.",
            "Name a person who made your day easier.",
            "Name something your body allowed you to do today.",
            "Name a place where you felt calm this week.",
            "Name something you learned recently that you are glad to know.",
            "Name a problem you no longer have."
        });

        _notes = new List<string>();
    }

    public List<string> GetNotes()
    {
        return _notes;
    }

    protected override void RunActivity()
    {
        Console.WriteLine("Answer each prompt with one short, specific sentence.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.Clear();

        DateTime endTime = GetEndTime();

        while (GetSecondsRemaining(endTime) > 0)
        {
            Console.WriteLine();
            Console.WriteLine(_prompts.GetNext());
            Console.Write("> ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                _notes.Add(answer.Trim());
            }
        }

        string label = _notes.Count == 1 ? "thing" : "things";

        Console.Clear();
        Console.WriteLine($"You recorded {_notes.Count} {label} you are grateful for:");
        Console.WriteLine();

        foreach (string note in _notes)
        {
            Console.WriteLine($"  - {note}");
        }

        Console.WriteLine();
        Console.Write("Take them in for a moment: ");
        ShowSpinner(5);
        Console.WriteLine();
    }
}
