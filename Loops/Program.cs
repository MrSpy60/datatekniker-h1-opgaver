namespace Loops
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Multiplication table
            MultiplicationTable();
            Console.WriteLine();

            //The biggest number
            Console.WriteLine(TheBiggestNumber([190, 291, 145, 209, 280, 200]));             
            Console.WriteLine(TheBiggestNumber([-9, -2, -7, -8, -4]));                       
            Console.WriteLine();                                                             
                                                                                             
            //Two 7s next to each other                                                      
            Console.WriteLine(Two7sNextToEachOther([8, 2, 5, 7, 9, 0, 7, 7, 3, 1]));         
            Console.WriteLine(Two7sNextToEachOther([9, 4, 5, 3, 7, 7, 7, 3, 2, 5, 7, 7]));   
            Console.WriteLine();                                                             
                                                                                             
            //Three increasing adjacent                                                      
            Console.WriteLine(ThreeIncreasingAdjacent([45, 23, 44, 68, 65, 70, 80, 81, 82]));
            Console.WriteLine(ThreeIncreasingAdjacent([7, 3, 5, 8, 9, 3, 1, 4]));
            Console.WriteLine();

            //Sieve of Eratosthenes
            Console.WriteLine(SieveOfEratosthenes(30));
            Console.WriteLine();

            //Extract string M
            Console.WriteLine(ExtractString("##abc##def"));
            Console.WriteLine(ExtractString("12####78"));
            Console.WriteLine(ExtractString("gar##d#en"));
            Console.WriteLine(ExtractString("++##--##++"));
            Console.WriteLine();

            //Full sequence of letters M
            Console.WriteLine(FullSequenceOfLetters("ds"));
            Console.WriteLine(FullSequenceOfLetters("or"));
            Console.WriteLine();

            Console.WriteLine(SumAndAverage(11, 66));
            Console.WriteLine(SumAndAverage(-10, 0));
            Console.WriteLine();

            //Draw triangle
            Console.ForegroundColor = ConsoleColor.Green;
            DrawTriangle();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.WriteLine(ToThePowerOf(-2, 3));
            Console.WriteLine(ToThePowerOf(5, 5));
            Console.WriteLine();
        }


        static void MultiplicationTable()
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string output = (i*j).ToString();
                    int length = output.Length;
                    switch (length)
                    {
                        case 1:
                            Console.Write(" ");
                            goto case 2;
                        case 2:
                            Console.Write(" ");
                            goto case 3;
                        case 3:
                            break;
                        default:
                            break;
                    }
                    Console.Write(output + " ");
                }
                Console.WriteLine("");
            }
        }

        static int TheBiggestNumber(int[] values)
        {
            int biggestNum = int.MinValue;
            foreach (int x in values)
            {
                if (x > biggestNum)
                {
                    biggestNum = x;
                }
            }
            return biggestNum;
        }

        static int Two7sNextToEachOther(int[] values)
        {
            int valuesLength = values.Length;
            int counter = 0;
            for (int i = 0; i < valuesLength - 1; i++)
            {
                if (values[i] == 7 && values[i + 1] == 7)
                {
                    counter++;
                }
            }
            return counter;
        }

        static bool ThreeIncreasingAdjacent(int[] value)
        {
            int valueLength = value.Length;
            for (int i = 0; i < valueLength-1; i++)
            {
                if (value[i]+1 == value[i+1] && value[i+1]+1 == value[i+2])
                    return true;
            }
            return false;
        }

        static string SieveOfEratosthenes(int v)
        {
            List<int> primes = new List<int>();
            bool[] sieve = new bool[v-1];
            int sieveLength = sieve.Length;

            primes.Add(2);

            Console.WriteLine($"[{string.Join(", ", primes)}]");
            for (int i = 0; i < sieveLength; i++)
            {
                sieve[i] = true;
            }

            for (int i = 0; i < sieveLength; i++)
            {
                foreach (int x in primes)
                {
                    if ((i + 2) % x == 0)
                    {
                        sieve[i] = false;
                    }
                }
                if (sieve[i]){
                    primes.Add(i + 2);
                }
                
            }
            return $"[{string.Join(", ", primes)}]";
        }

        static string ExtractString(string v)
        {
            string output = "";
            int firstPoint = 0;
            int secondPoint = 0;
            int vLength = v.Length;
            for (int i = 0; i < vLength-3; i++)
            {
                if (v[i] == '#' && v[i+1] == '#')
                {
                    firstPoint = i+2;
                    for (int j = i + 2; j < vLength-1; j++)
                    {
                        if (v[j] == '#' && v[j + 1] == '#')
                        {
                            secondPoint = j;

                            goto test;
                        }
                    }
                }
            }
        test:
            if (secondPoint != 0)
            {
                output = v.Substring(firstPoint, secondPoint - firstPoint);
            }
            return output;
        }

        static string FullSequenceOfLetters(string v)
        {
            string output = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char firstLetter = v[0];
            char secondLetter = v[1];

            for(int i = 0; i < 26; i++)
            {
                if (alphabet[i] == firstLetter)
                {
                    for (int j = i; j < 26; j++)
                    {
                        output += alphabet[j];
                        if (alphabet[j] == secondLetter)
                        {
                            break;
                        }
                    }
                    break;
                }
            }
            return output;
        }

        static string SumAndAverage(double v1, double v2)
        {
            double sum = 0;
            double counter = 0;
            double i = v1;
            while (i <= v2)
            {
                sum += i;
                counter++;
                i++;
            }
            return $"Sum: {sum}, Average: {sum / counter}";
        }

        static void DrawTriangle()
        {
            for (int i = 10; i > 0; i--)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (i < j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.Write("*");
                for (int j = 10; j >= 1; j--)
                {
                    if (i < j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
        }

        static int ToThePowerOf(int v1, int v2)
        {
            int output = v1;
            for (int i = 1; i < v2; i++)
            {
                output *= v1;
            }
            return output;
        }
    }
}
