/*
Exceeding the core requirements:

1. A fourth activity was added: the Gratitude Activity. It asks short prompts and
   the user answers with one specific thing they are grateful for, then it reads
   the whole list back to them at the end of the session.
2. The program keeps a log of how many sessions of each activity were completed
   and how many total seconds were spent on them (menu option 5).
3. The log is saved to and loaded from mindfulness_log.txt, and the gratitude
   answers are saved to mindfulness_gratitude.txt, so the history survives
   between runs. The five most recent gratitude entries are shown in the log.
4. Random prompts and questions never repeat until every option in the list has
   been used, which is handled by the PromptQueue class.
5. The breathing activity uses a growing and shrinking bar that moves quickly at
   first and slows down near the end of each breath, with a countdown next to it.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog("mindfulness_log.txt", "mindfulness_gratitude.txt");
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");
            Console.WriteLine("  5. View your activity log");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                RunActivity(new BreathingActivity(), log);
            }
            else if (choice == "2")
            {
                RunActivity(new ReflectingActivity(), log);
            }
            else if (choice == "3")
            {
                RunActivity(new ListingActivity(), log);
            }
            else if (choice == "4")
            {
                RunActivity(new GratitudeActivity(), log);
            }
            else if (choice == "5")
            {
                log.Display();
            }
            else if (choice == "6" || choice == null)
            {
                Console.Clear();
                Console.WriteLine("Thank you for taking time to be mindful. See you soon!");
                running = false;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a number from 1 to 6.");
                Console.WriteLine();
            }
        }
    }

    static void RunActivity(Activity activity, ActivityLog log)
    {
        activity.Run();
        log.RecordActivity(activity.GetName(), activity.GetDuration());

        GratitudeActivity gratitude = activity as GratitudeActivity;

        if (gratitude != null)
        {
            log.RecordNotes(gratitude.GetNotes());
        }
    }
}
