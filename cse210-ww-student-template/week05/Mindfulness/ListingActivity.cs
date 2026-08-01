using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private PromptQueue _prompts;
    private int _count;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new PromptQueue(new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });

        _count = 0;
    }

    public int GetCount()
    {
        return _count;
    }

    protected override void RunActivity()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_prompts.GetNext()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine();

        DateTime endTime = GetEndTime();
        List<string> items = new List<string>();

        while (GetSecondsRemaining(endTime) > 0)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item.Trim());
            }
        }

        _count = items.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
    }
}
