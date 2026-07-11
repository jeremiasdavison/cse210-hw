using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator generator = new PromptGenerator();
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("");
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._prompt = prompt;
                newEntry._response = response;

                myJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string saveFile = Console.ReadLine();
                myJournal.SaveToFile(saveFile);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string loadFile = Console.ReadLine();
                myJournal.LoadFromFile(loadFile);
            }
            else if (choice == "5")
            {
                keepRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
            }
        }
    }
}