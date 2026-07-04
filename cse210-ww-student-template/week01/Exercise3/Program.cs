using System;
class Program
{
    static void Main(string[] args)
    {      
        string playAgain = "yes";
        while (playAgain == "yes")
        {
            long currentTicks = System.DateTime.Now.Ticks;
            int magicNumber = (int)(currentTicks % 100) + 1;
            
            int guess = 0;
            int guessCount = 0; 
            while (guess != magicNumber)
            {
                System.Console.Write("What is your guess? ");
                string userInput = System.Console.ReadLine();                
                guess = int.Parse(userInput);
                guessCount = guessCount + 1; 
               
                if (guess < magicNumber)
                {
                    System.Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    System.Console.WriteLine("Lower");
                }
                else
                {
                    System.Console.WriteLine("You guessed it!");
                }
            }
            System.Console.WriteLine("It took you " + guessCount + " guesses.");
                       
            System.Console.Write("Would you like to play again? (yes/no) ");
            playAgain = System.Console.ReadLine();
        }
        System.Console.WriteLine("Thanks for playing!");
    }
}
