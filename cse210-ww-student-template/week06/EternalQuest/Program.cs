using System;

// To exceed the requirements, I added a simple leveling system: the user's
// level goes up for every 1000 points earned and is shown next to the score.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("");
            Console.WriteLine("Eternal Quest Menu");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal(manager);
            }
            else if (choice == "2")
            {
                manager.DisplayGoals();
            }
            else if (choice == "3")
            {
                manager.DisplayGoals();
                Console.Write("Which goal number did you accomplish? ");
                int index = int.Parse(Console.ReadLine()) - 1;
                manager.RecordEvent(index);
            }
            else if (choice == "4")
            {
                manager.DisplayScore();
            }
            else if (choice == "5")
            {
                Console.Write("What is the filename? ");
                string saveFile = Console.ReadLine();
                manager.SaveToFile(saveFile);
            }
            else if (choice == "6")
            {
                Console.Write("What is the filename? ");
                string loadFile = Console.ReadLine();
                manager.LoadFromFile(loadFile);
            }
            else if (choice == "7")
            {
                keepRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("What type of goal do you want to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("What is the name of the goal? ");
        string name = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            manager.AddGoal(new SimpleGoal(name, points, false));
        }
        else if (type == "2")
        {
            manager.AddGoal(new EternalGoal(name, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int targetAmount = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            manager.AddGoal(new ChecklistGoal(name, points, targetAmount, bonus, 0));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }
}
