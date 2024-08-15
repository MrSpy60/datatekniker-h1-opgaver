using DiceLib;
using System.Media;

namespace MusicalDiceGame
{
    internal class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SoundPlayer player = new SoundPlayer();

            string currentDiretory = Environment.CurrentDirectory;
            string filePath = Path.Combine(currentDiretory,"Data");

            Dice dice = new Dice();
            Dice instrumentDie = new Dice(4);
            string instrumentPicked = "piano";
            bool isRandomInstrument = false;

            string[] fileLocations = new string[32];

            //User Interface
            Console.WriteLine("Welcome to the Musical Dice Game");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("You have the following choices: (not case-sensitive)");
            Console.WriteLine("             Clarinet");
            Console.WriteLine("             Flute-Harp");
            Console.WriteLine("             Mbira");
            Console.WriteLine(" (default)   Piano ");
            Console.WriteLine("             Random");
            Console.WriteLine("------------------------------------------------------------");

            string userInput = Console.ReadLine();
            userInput.ToLower();
            if (userInput == "Clarinet" || userInput == "Flute-Harp" || userInput == "Mbira" || userInput == "Piano")
            {
                Console.WriteLine($"{userInput} was picked");
                instrumentPicked = userInput;
            }
            else if (userInput == "random")
            {
                isRandomInstrument = true;
            }


            for (int i = 0; i < 16; i++)
            {
                if (isRandomInstrument)
                {
                    instrumentPicked = instrumentChoosen(instrumentDie.RollDie());
                }

                int total = 0;
                total += dice.RollDie();
                total += dice.RollDie();

                fileLocations[i] = Path.Combine(filePath, instrumentPicked, $"minuet{i}-{total}.wav");
            }
            for (int i = 0; i < 16; i++)
            {
                if (isRandomInstrument)
                {
                    instrumentPicked = instrumentChoosen(instrumentDie.RollDie());
                }
                int total = 0;
                total += dice.RollDie();

                fileLocations[i+16] = Path.Combine(filePath, instrumentPicked, $"trio{i}-{total}.wav");
            }

            foreach (string soundLocation in fileLocations)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"Now Playing {soundLocation.Substring(71)}");
                
                playMelody(soundLocation, player);
            }

            
        }
        private static string instrumentChoosen(int a)
        {
            switch (a)
            {
                case 1:
                    return "clarinet";
                case 2:
                    return "flute-harp";
                case 3:
                    return "mbira";
                case 4:
                    return "piano";
                default:
                    return "ERROR";
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        private static void playMelody(string soundLocation, SoundPlayer player)
        {
            player.SoundLocation = soundLocation;
            player.Load();
            player.PlaySync();
            
        }
    }
}
