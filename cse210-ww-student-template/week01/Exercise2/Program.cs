using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage in CSW 210? ");
        int grade = int.Parse(Console.ReadLine());
        if (grade >= 90)
        {
            if ((grade / 10) >= 7)
            {
                Console.WriteLine("+A");
            }
            else
            {
                Console.WriteLine("You got an A!");
            }
        }
        else if (grade >= 80)
        {
            Console.WriteLine("You got a B!");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("You got a C!");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("You got a D!");
        }
        else if (grade < 60)
        {
            if ((grade / 10) >= 7)
            {
                Console.WriteLine("+F");
            }
            else
            {
                Console.WriteLine("You got an F!");
            }
        }
    }
}