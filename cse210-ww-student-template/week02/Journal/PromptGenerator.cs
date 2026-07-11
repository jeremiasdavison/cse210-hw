using System;
using System.Collections.Generic;

class PromptGenerator
{
public List<string> _prompts = new List<string>();
Random _random = new Random();
    int _lastIndex = -1;
    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I could redo one thing from today, what would it be?");
    }

public string GetRandomPrompt()
{
    int randomIndex = _random.Next(_prompts.Count);

    while (randomIndex == _lastIndex)
    {
        randomIndex = _random.Next(_prompts.Count);
    }

    _lastIndex = randomIndex;
    string randomPrompt = _prompts[randomIndex];
    return randomPrompt;
}
}