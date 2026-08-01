using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void Run()
    {
        DisplayStartingMessage();
        RunActivity();
        DisplayEndingMessage();
    }

    protected abstract void RunActivity();

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = GetPositiveNumber();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Console.Write("  ");
        ShowSpinner(5);
        Console.Clear();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.Write("  ");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        Console.Write("  ");
        ShowSpinner(5);
        Console.Clear();
    }

    protected DateTime GetEndTime()
    {
        return DateTime.Now.AddSeconds(_duration);
    }

    protected int GetSecondsRemaining(DateTime endTime)
    {
        double remaining = (endTime - DateTime.Now).TotalSeconds;

        if (remaining < 0)
        {
            return 0;
        }

        return (int)Math.Ceiling(remaining);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            string frame = frames[index % frames.Count];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index++;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();
            Console.Write(text);
            Thread.Sleep(1000);

            foreach (char letter in text)
            {
                Console.Write("\b \b");
            }
        }
    }

    protected int GetPositiveNumber()
    {
        int number = 0;

        while (number <= 0)
        {
            string answer = Console.ReadLine();

            if (!int.TryParse(answer, out number) || number <= 0)
            {
                number = 0;
                Console.Write("Please enter a whole number of seconds greater than zero: ");
            }
        }

        return number;
    }
}
