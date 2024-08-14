using DiceLib;

namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            int numberOfDice = 0;
            List<Dice> diceBag = new List<Dice>();

            Console.WriteLine("Hello, World!");
            Console.WriteLine("Today we are rolling dice.");
            Console.WriteLine("");
            Console.WriteLine("We are going to be rolling until all the dice hit natural 6's");
            while (true)
            {
                bool isRollingDice = true;
                int counter = 0;

                Console.WriteLine("Pick how many dice we are going to roll:");
                userInput = Console.ReadLine();
                try
                {
                    numberOfDice = int.Parse(userInput);
                }catch (Exception)
                {
                    Console.WriteLine("ERROR: Could not convert the input to an Integer");
                    Console.WriteLine();
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine($"Adding {numberOfDice} Dice to the dicebag");
                for (int i = 0; i < numberOfDice; i++)
                {
                    diceBag.Add(new Dice());
                }
                while (isRollingDice)
                {
                    int numberOfSixes = 0;
                    foreach (Dice dice in diceBag)
                    {
                        dice.RollDie();
                        if (dice.LastRoll == 6)
                        {
                            numberOfSixes++;
                        }
                    }
                    if (numberOfSixes == numberOfDice)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"It took {counter} tries to get all natural sixes with {numberOfDice} dice.");
                        break;
                    }
                    counter++;
                    if (counter % 100000 == 0)
                    {
                        Console.Write($"\rCurrently rolling, tried {counter} times");
                    }
                }
            }
        }
    }
}
