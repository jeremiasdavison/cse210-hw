using System;
using System.Threading;

class BreathingActivity : Activity
{
    private int _breatheInSeconds;
    private int _breatheOutSeconds;
    private int _barWidth;

    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breatheInSeconds = 4;
        _breatheOutSeconds = 6;
        _barWidth = 24;
    }

    protected override void RunActivity()
    {
        DateTime endTime = GetEndTime();
        bool breatheIn = true;

        while (GetSecondsRemaining(endTime) > 0)
        {
            int seconds = breatheIn ? _breatheInSeconds : _breatheOutSeconds;
            int remaining = GetSecondsRemaining(endTime);

            if (remaining < seconds)
            {
                seconds = remaining;
            }

            string label = breatheIn ? "Breathe in... " : "Breathe out...";
            ShowBreath(label, seconds, breatheIn);

            breatheIn = !breatheIn;
        }
    }

    private void ShowBreath(string label, int seconds, bool growing)
    {
        double[] weights = new double[_barWidth + 1];
        double totalWeight = 0;

        for (int i = 0; i <= _barWidth; i++)
        {
            weights[i] = 1.0 + 2.0 * i / _barWidth;
            totalWeight += weights[i];
        }

        double elapsed = 0;

        for (int i = 0; i <= _barWidth; i++)
        {
            int size = growing ? i : _barWidth - i;
            int countDown = (int)Math.Ceiling(seconds - elapsed / 1000.0);

            if (countDown < 1)
            {
                countDown = 1;
            }

            string bar = new string('*', size).PadRight(_barWidth);
            Console.Write($"\r{label} {bar} {countDown} ");

            int pause = (int)(seconds * 1000 * weights[i] / totalWeight);
            Thread.Sleep(pause);
            elapsed += pause;
        }

        Console.Write($"\r{label} {new string(' ', _barWidth)}   ");
        Console.WriteLine();
    }
}
