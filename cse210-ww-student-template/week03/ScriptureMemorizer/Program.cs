using System;

class Program
{
    static void Main(string[] args)
    {
        // Extra credit: reference covers multiple verses, and the program
        // shows a progress count of how many words are hidden so far.
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Hidden: {scripture.CountHiddenWords()}/{scripture.CountTotalWords()}");
            Console.WriteLine();

            if (scripture.AllWordsHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}