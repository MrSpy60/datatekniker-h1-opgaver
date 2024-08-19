using DiceLib;

namespace YatzyGame
{

    internal class Program
    {
        //Global variables
        public static List<Dice> Dices = new List<Dice>()
            {
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice()
            };

        public static List<bool> isDielocked = new List<bool>()
            {
                false,
                false,
                false,
                false,
                false
            };
        public static int TurnStatus = 0;
        public static int SelectedField = 0;
        public static int DiceCount = Dices.Count();

        static void Main(string[] args)
        {
            //local variables
            int GameruleLength = 15; //number of fields on a 5-diced Yatzy score table
            int GameruleDiceThrows = 3;
            ConsoleKeyInfo userInput;

            //player 1
            //Dictionary<string, int> YatzyScoreboard = new Dictionary<string, int>();


            //Drawing Interface
            DrawTitle();
            DrawScoreboard();
            DrawDice(35, 15);


            //Gameplay Loop
            for (int i = 0; i < GameruleLength; i++)
            {
                // Reset turn variables
                TurnStart();
                // Roll Dice and picking
                for(int j = 0; j < GameruleDiceThrows; j++)
                {
                    RollDice();
                    do
                    {
                        DrawDice(35, 15);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(0, 28);
                        userInput = Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //Console.Write(userInput.Key);
                        switch (userInput.Key)
                        {
                            case ConsoleKey.D1:
                                isDielocked[0] = !isDielocked[0];
                                break;
                            case ConsoleKey.D2:
                                isDielocked[1] = !isDielocked[1];
                                break;
                            case ConsoleKey.D3:
                                isDielocked[2] = !isDielocked[2];
                                break;
                            case ConsoleKey.D4:
                                isDielocked[3] = !isDielocked[3];
                                break;
                            case ConsoleKey.D5:
                                isDielocked[4] = !isDielocked[4];
                                break;
                            default: break;
                        }
                        
                    } while (userInput.Key != ConsoleKey.Spacebar);

                    if (isDielocked[0] && isDielocked[1] && isDielocked[2] && isDielocked[3] && isDielocked[4])
                    {
                        break;
                    }
                }
                LockDice();
                DrawDice(35, 15);
                TurnStatus = 1;
                // Pick Scoring Field
                DrawPicker();
                do
                {
                    int lastPickerLine = Console.CursorTop;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, 28);
                    userInput = Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write(userInput.Key);
                    switch (userInput.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.SetCursorPosition(27, lastPickerLine);
                            Console.Write("    ");
                            SelectedField--;
                            if(SelectedField < 0)
                            {
                                SelectedField += 15;
                            }
                            DrawPicker();
                            break;
                        case ConsoleKey.DownArrow:
                            Console.SetCursorPosition(27, lastPickerLine);
                            Console.Write("    ");
                            SelectedField++;
                            if(SelectedField > 14)
                            {
                                SelectedField -= 15;
                            }
                            DrawPicker();
                            break;
                        case ConsoleKey.Spacebar:
                            // Field Validation

                            break;
                    }
                } while (TurnStatus == 1);

            }
            Console.SetCursorPosition(0, 28);
            Console.Write(SelectedField);
        }

        private static void LockDice()
        {
            for (int i = 0; i < DiceCount; i++)
            {
                isDielocked[i] = true;

            }
        }

        public static void DrawPicker()
        {
            int StartX = 27;
            int StartY = 10;
            int buffer = 0;
            int SelectedLine = 0;

            if(SelectedField > 5)
            {
                buffer = 2;
            }
            SelectedLine = StartY + buffer + SelectedField;

            Console.SetCursorPosition(StartX, SelectedLine);
            Console.Write("<---");
        }
        public static void TurnStart()
        {
            TurnStatus = 0;
            SelectedField = 0;
            for (int i = 0; i < 5; i++)
            {
                isDielocked[i] = false;
            }
            DrawDice(35, 15);
        }

        public static void RollDice()
        {
            for (int i = 0; i < DiceCount; i++)
            {
                if (!isDielocked[i])
                {
                    Dices[i].RollDie();
                }
            }
        }

        public static void DrawDice(int startX, int startY)
        {
            int StartX = startX;
            int StartY = startY;

            DrawDie(StartX, StartY, 0);
            DrawDie(StartX + 7, StartY, 1);
            DrawDie(StartX + 14, StartY, 2);
            DrawDie(StartX + 21, StartY, 3);
            DrawDie(StartX + 28, StartY, 4);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DrawDie(int startXCord, int startYCord, int diceIndex)
        {
            int StartX = startXCord;
            int StartY = startYCord;
            int CurrentLine = StartY;

            if (isDielocked[diceIndex])
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                CurrentLine++;
            }

            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("     ");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("┌───┐");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("│   │");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write($"│ {Dices[diceIndex].LastRoll} │");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("│   │");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("└───┘");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("     ");
            CurrentLine++;
        }

        public static void DrawTitle()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(" __ __   ____  ______  _____  __ __ ");
            Console.WriteLine("|  T  T /    T|      T|     T|  T  T");
            Console.WriteLine("|  |  |Y  o  ||      |l__/  ||  |  |");
            Console.WriteLine("|  ~  ||     |l_j  l_j|   __j|  ~  |");
            Console.WriteLine("l___, ||  _  |  |  |  |  /  |l___, |");
            Console.WriteLine("|     !|  |  |  |  |  |     ||     !");
            Console.WriteLine("l____/ l__j__j  l__j  l_____jl____/ ");
        }

        public static void DrawScoreboard()
        {
            int StartX = 2;
            int StartY = 9;
            int CurrentLine = StartY;

            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|   Maximum points  |   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|1'ere             5|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|2'ere            10|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|3'ere            15|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|4'ere            20|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|5'ere            25|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|6'ere            30|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|Sum                |   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|Bonus            50|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|1 par            12|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|2 par            22|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|3 ens            18|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|4 ens            24|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|Lille straight   15|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|Stor straight    15|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|Hus              28|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|Chance           30|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|YATZY            50|   |");
            CurrentLine++;
            Console.SetCursorPosition(StartX, CurrentLine);
            Console.Write("|Total              |   |");

        }


        //Console.SetCursorPosition(0, Console.CursorTop);
        //Console.Write(new String(' ', Console.WindowWidth));
        //Console.SetCursorPosition(0, Console.CursorTop);
        //Console.Write($"Now Playing {soundLocation.Substring(71)}");
    }
}
