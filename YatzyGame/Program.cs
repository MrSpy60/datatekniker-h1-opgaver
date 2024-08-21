using DiceLib;

namespace YatzyGame
{

    internal class Program
    {
        //Global variables
        public static List<Dice> Dices =
            [
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice()
            ];

        public static List<bool> isDielocked =
            [
                false,
                false,
                false,
                false,
                false
            ];
        public static int TurnStatus = 0;
        public static int SelectedField = 0;
        public static int DiceCount = Dices.Count;
        public static Player CurrentPlayer;
        public static int CurrentPlayerIndex = 0;
        public static int GamerulePlayerCount = 6;

        static void Main(string[] args)
        {
            //local variables
            int GameruleLength = 15; //number of fields on a 5-diced Yatzy score sheet
            int GameruleDiceThrows = 3;
            int PickerPosition = 23 + (GamerulePlayerCount * 4);
            ConsoleKeyInfo userInput;
            List<Player> Players = [];

            for (int i = 0; i < GamerulePlayerCount; i++)
            {
                Players.Add(new Player());
            }

            //Drawing Interface
            DrawTitle();
            DrawScoreboard();
            DrawControls();

            //Gameplay Loop
            for (int i = 0; i < GameruleLength; i++)
            {
                //Multiple players loop go here! (just testing 1 player right now)
                foreach (Player currentPlayer in Players)
                {
                    CurrentPlayer = currentPlayer;
                    CurrentPlayerIndex++;

                    // Reset turn variables
                    TurnStart();
                    // Roll Dice and picking
                    for (int j = 1; j < GameruleDiceThrows; j++)
                    {
                        RollDice();
                        DrawDice(35, 15);
                        do
                        {
                            bool IsValidKey = false;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(0, 28);
                            userInput = Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            //Console.Write(userInput.Key);
                            switch (userInput.Key)
                            {
                                case ConsoleKey.D1:
                                    isDielocked[0] = !isDielocked[0];
                                    IsValidKey = true;
                                    break;
                                case ConsoleKey.D2:
                                    isDielocked[1] = !isDielocked[1];
                                    IsValidKey = true;
                                    break;
                                case ConsoleKey.D3:
                                    isDielocked[2] = !isDielocked[2];
                                    IsValidKey = true;
                                    break;
                                case ConsoleKey.D4:
                                    isDielocked[3] = !isDielocked[3];
                                    IsValidKey = true;
                                    break;
                                case ConsoleKey.D5:
                                    isDielocked[4] = !isDielocked[4];
                                    IsValidKey = true;
                                    break;
                                default: break;
                            }
                            if (IsValidKey)
                            {
                                DrawDice(35, 15);
                            }
                        } while (userInput.Key != ConsoleKey.Spacebar);

                        if (isDielocked[0] && isDielocked[1] && isDielocked[2] && isDielocked[3] && isDielocked[4])
                        {
                            break;
                        }
                    }
                    RollDice();
                    LockDice();
                    DrawDice(35, 15);
                    TurnStatus = 1;

                    // Pick Scoring Field
                    DrawPicker();
                    int lastPickerLine;
                    do
                    {
                        lastPickerLine = Console.CursorTop;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(0, 28);
                        userInput = Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //Console.Write(userInput.Key);
                        switch (userInput.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.SetCursorPosition(PickerPosition, lastPickerLine);
                                Console.Write("    ");
                                do
                                {
                                    SelectedField--;
                                    if (SelectedField < 0)
                                    {
                                        SelectedField += 15;
                                    }
                                } while (currentPlayer.ScoreCard[SelectedField] != -1);
                                DrawPicker();
                                break;
                            case ConsoleKey.DownArrow:
                                Console.SetCursorPosition(PickerPosition, lastPickerLine);
                                Console.Write("    ");
                                do
                                {
                                    SelectedField++;
                                    if (SelectedField > 14)
                                    {
                                        SelectedField -= 15;
                                    }
                                } while (currentPlayer.ScoreCard[SelectedField] != -1);


                                DrawPicker();
                                break;
                            case ConsoleKey.Spacebar:
                                if (ScoreValidation(currentPlayer))
                                {
                                    TurnStatus = 2;
                                }
                                break;
                        }
                    } while (TurnStatus == 1);
                    Console.SetCursorPosition(PickerPosition, lastPickerLine);
                    Console.Write("    ");
                    DrawScore(lastPickerLine, currentPlayer.ScoreCard[SelectedField]);
                }
                //End of round
                CurrentPlayerIndex = 0;
            }
            //End of game
            foreach (Player currentPlayer in Players)
            {
                CurrentPlayerIndex++;
                DrawScore(16, currentPlayer.SumCheck(), true);
                DrawScore(17, currentPlayer.Bonus, true);
                DrawScore(27, currentPlayer.GetTotalScore(), true);
            }

            Console.SetCursorPosition(40, 28);
            Console.Write($"Press 'Escape' to close the game");
            //press escape to end game, prevents termination of game if spacebar is held
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, 28);
                userInput = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Gray;
            } while (userInput.Key != ConsoleKey.Escape);
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
            int PlayerOffset = (GamerulePlayerCount - 1) * 4;
            int StartX = 27 + PlayerOffset;
            int StartY = 10;
            int buffer = 0;
            int SelectedLine;

            if (SelectedField > 5)
            {
                buffer = 2;
            }
            SelectedLine = StartY + buffer + SelectedField;

            Console.SetCursorPosition(StartX, SelectedLine);
            Console.Write("<---");
        }

        public static void DrawScore(int startY, int score, bool isMiscFields = false)
        {
            string Output = " X ";
            int scoreLenght = score.ToString().Length;
            int StartX = 22 - scoreLenght + (4 * CurrentPlayerIndex);
            int StartY = startY;
            if (score > 0 && isMiscFields == false || isMiscFields)
            {
                Output = $"{score}";
            }
            else
            {
                StartX = 19 + (4 * CurrentPlayerIndex);
            }
            Console.SetCursorPosition(StartX, StartY);
            Console.Write($"{Output}");
        }

        public static void TurnStart()
        {
            TurnStatus = 0;
            SelectedField = 0;
            while (CurrentPlayer.ScoreCard[SelectedField] != -1)
            {
                SelectedField++;
            }
            for (int i = 0; i < 5; i++)
            {
                isDielocked[i] = false;
            }
            DrawCurrentPlayer();
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
            int StartX = startX + (GamerulePlayerCount - 1) * 4;
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

            if (!isDielocked[diceIndex])
            {
                Console.SetCursorPosition(StartX, CurrentLine);
                Console.Write("     ");
            }
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
            if (isDielocked[diceIndex])
            {
                Console.SetCursorPosition(StartX, CurrentLine);
                Console.Write("     ");
            }
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
            string ExtraPlayerSheets = "";
            string[] UIScoreSheet = [
                "|   Maximum points  |   |",
                "|1'ere             5|   |",
                "|2'ere            10|   |",
                "|3'ere            15|   |",
                "|4'ere            20|   |",
                "|5'ere            25|   |",
                "|6'ere            30|   |",
                "|Sum                |   |",
                "|Bonus            50|   |",
                "|1 par            12|   |",
                "|2 par            22|   |",
                "|3 ens            18|   |",
                "|4 ens            24|   |",
                "|Lille straight   15|   |",
                "|Stor straight    20|   |",
                "|Hus              28|   |",
                "|Chance           30|   |",
                "|YATZY            50|   |",
                "|Total              |   |"
                ];
            for (int i = 1; i < GamerulePlayerCount; i++)
            {
                ExtraPlayerSheets += "   |";
            }

            foreach (string SheetLine in UIScoreSheet)
            {
                Console.SetCursorPosition(StartX, CurrentLine);
                Console.Write(SheetLine);
                Console.Write(ExtraPlayerSheets);
                CurrentLine++;
            }
        }

        public static void DrawControls()
        {
            //Draw dice numbers 
            int DiceStartX = 33 + GamerulePlayerCount * 4;
            int DiceStartY = 23;
            Console.SetCursorPosition(DiceStartX, DiceStartY);
            Console.Write("1      2      3      4      5");

            //Draw controls
            int ControlStartX = 55;
            int ControlStartY = 2;
            int CurrentLine = ControlStartY;
            string[] Controls = [
                "Controls:",
                "To lock or unlock a dice press the number shown below it,",
                "Red dice are locked, Green dice will get rerolled.",
                "press Spacebar to Reroll dice.",
                "",
                "After 3 rolls or if all 5 dice are locked,",
                "use the arrowkeys up and down, to pick what field",
                "to fill out or crossout"
                ];

            foreach (string Line in Controls)
            {
                Console.SetCursorPosition(ControlStartX, CurrentLine);
                Console.Write(Line);
                CurrentLine++;
            }
        }

        public static void DrawCurrentPlayer()
        {
            //Current play text
            int CurrentStartX = 33 + GamerulePlayerCount * 4;
            int CurrentStartY = 12;
            Console.SetCursorPosition(CurrentStartX, CurrentStartY);
            Console.Write($"Player {CurrentPlayerIndex}'s turn");

            //
            int DiceStartX = 20 + CurrentPlayerIndex * 4;
            int DiceStartY = 8;
            int LastPositionoffset;
            Console.SetCursorPosition(DiceStartX, DiceStartY);
            Console.Write("V");
            if (CurrentPlayerIndex == 1 ) { LastPositionoffset = 20; } else {LastPositionoffset = -4; }
            Console.SetCursorPosition(DiceStartX + LastPositionoffset, DiceStartY);
            Console.Write(" ");

        }

        public static bool ScoreValidation(Player player)
        {
            int[] DieFaces = new int[7];
            foreach (var die in Dices)
            {
                DieFaces[die.LastRoll]++;
            }
            if (player.ScoreCard[SelectedField] == -1)
            {
                switch (SelectedField)
                {
                    //single face
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        player.ScoreCard[SelectedField] = ScoreSingles(SelectedField + 1);
                        break;
                    //pars
                    case 6:
                    case 7:
                        player.ScoreCard[SelectedField] = ScorePairs(DieFaces, SelectedField - 5);
                        break;
                    // 3 and 4 of a kind
                    case 8:
                    case 9:
                        player.ScoreCard[SelectedField] = ScoreOfAKind(DieFaces, SelectedField - 5);
                        break;
                    //low and high straight
                    case 10:
                    case 11:
                        player.ScoreCard[SelectedField] = ScoreStraight(DieFaces, SelectedField - 10);
                        break;
                    //house
                    case 12:
                        player.ScoreCard[SelectedField] = ScoreHouse(DieFaces);
                        break;
                    //chance
                    case 13:
                        player.ScoreCard[SelectedField] = ScoreChance();
                        break;
                    //YATZY
                    case 14:
                        player.ScoreCard[SelectedField] = ScoreOfAKind(DieFaces, SelectedField - 9);
                        break;
                    default:
                        throw new Exception("Out of scope");

                }
                return true;
            }
            return false;
        }

        private static int ScoreSingles(int dieFaceToCheckFor)
        {
            int Output = 0;
            int DieFace = dieFaceToCheckFor;
            foreach (var die in Dices)
            {
                if (DieFace == die.LastRoll)
                {
                    Output += DieFace;
                }
            }
            return Output;
        }

        private static int ScorePairs(int[] dieFaces, int numberOfPairs)
        {
            int Output = 0;
            for (int i = 6; i > 0; i--)
            {
                if (dieFaces[i] >= 2)
                {
                    if (numberOfPairs > 1)
                    {
                        for (int j = i - 1; j > 0; j--)
                        {
                            if (dieFaces[j] >= 2)
                            {
                                Output = j * 2 + i * 2;
                                return Output;
                            }

                        }
                    }
                    else
                    {
                        Output = i * 2;
                        return Output;
                    }
                }
            }
            return Output;
        }

        private static int ScoreOfAKind(int[] dieFaces, int ofAKindSize)
        {
            int Output = 0;
            for (int i = 6; i > 0; i--)
            {
                if (dieFaces[i] >= ofAKindSize)
                {
                    Output = i * ofAKindSize;
                    break;
                }
            }
            //YATZY check
            if (Output > 0 && ofAKindSize == 5)
            {
                Output = 50;
            }

            return Output;
        }

        private static int ScoreStraight(int[] dieFaces, int ishighStraight)
        {
            int Output = 0;
            if (dieFaces[1 + ishighStraight] == 1 && dieFaces[2 + ishighStraight] == 1 && dieFaces[3 + ishighStraight] == 1 && dieFaces[4 + ishighStraight] == 1 && dieFaces[5 + ishighStraight] == 1)
            {
                if (ishighStraight == 1)
                {
                    Output = 20;
                }
                else
                {
                    Output = 15;
                }
            }
            return Output;
        }

        private static int ScoreHouse(int[] dieFaces)
        {
            int Output = 0;
            int ThreeOfAKind = 0;
            int TwoOfAKind = 0;
            for (int i = 1; i < 7; i++)
            {
                if (dieFaces[i] == 2)
                {
                    TwoOfAKind = i;
                }
                if (dieFaces[i] == 3)
                {
                    ThreeOfAKind = i;
                }
            }
            if (TwoOfAKind > 0 && ThreeOfAKind > 0)
            {
                Output = TwoOfAKind * 2 + ThreeOfAKind * 3;
            }
            return Output;
        }

        private static int ScoreChance()
        {
            int Output = 0;

            foreach (var die in Dices)
            {
                Output += die.LastRoll;
            }

            return Output;
        }
    }
}
