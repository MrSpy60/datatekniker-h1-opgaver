namespace Lommeregner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lastResult = 0;
            Console.WriteLine("WELCOME TO THE BESTEST CALCULATOR ON THIS PC (cos windows didnt come with one for some reason)");
            Console.WriteLine("Type 'exit' to quit the program");
            while (true)
            {
                char operatorType = '\0';
                double firstValue, secondValue;
                string[] tempData = new string[2];

                Console.WriteLine("what do we need to calculate today, pinky?");
                string? input = Console.ReadLine();
                

                if (input == "" || input == null) // empty or NULL detecter
                {
                    Console.WriteLine("HOOMAN ERROR: Input empty or NULL");
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Bye Bye 0/");
                    Console.WriteLine("Press Enter to close application");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        operatorType = c;
                        break;
                    }
                }
                if (operatorType == '\0')
                {
                    Console.WriteLine("HOOMAN ERROR: No Operator found (i think)");
                    continue;
                }
                tempData = input.Split(operatorType);
                foreach (string s in tempData)
                {
                    foreach (char c in s)
                    {
                        if (!char.IsDigit(c))
                        {
                            continue;
                        }
                    }
                }
                Console.WriteLine(tempData[0].Length);
                if (tempData[0].Length != 0)
                {
                    firstValue = int.Parse(tempData[0]);
                }
                else
                {
                    firstValue = lastResult;
                }
                secondValue = int.Parse(tempData[1]);
                switch (operatorType)
                {
                    case '+':
                        lastResult = Add(firstValue,secondValue);
                        Console.WriteLine(lastResult);
                        break;
                    case '-':
                        lastResult = Subtract(firstValue, secondValue);
                        Console.WriteLine(lastResult);
                        break;
                    case '/':
                        if (secondValue == 0){
                            Console.WriteLine("HOOMAN ERROR: Divide By 0 Not Allowed!");
                            break;
                        }
                        lastResult = divide(firstValue, secondValue);
                        Console.WriteLine(lastResult);
                        break;
                    case '*':
                        lastResult = Multiply(firstValue, secondValue);
                        Console.WriteLine(lastResult);
                        break;
                    case '%':
                        lastResult = Modulus(firstValue, secondValue);
                        Console.WriteLine(lastResult);
                        break;
                    case '^':
                        lastResult = toThePowerOf(firstValue, secondValue);
                        Console.WriteLine(lastResult);
                        break;

                    default:
                        Console.WriteLine("Operator not supported or implemented yet!!!");
                        break;
                }

            }
        }

        private static double toThePowerOf(double firstValue, double secondValue)
        {
            double output = firstValue;
            for (int i = 1; i < secondValue; i++)
            {
                output *= firstValue;
            }
            return output;
        }

        private static double Modulus(double firstValue, double secondValue)
        {
            double output;
            output = firstValue % secondValue;
            return output;
        }

        private static double Multiply(double firstValue, double secondValue)
        {
            double output;
            output = firstValue * secondValue;
            return output;
        }

        private static double divide(double firstValue, double secondValue)
        {
            double output;
            output = firstValue / secondValue;
            return output;
        }

        private static double Subtract(double firstValue, double secondValue)
        {
            double output;
            output = firstValue - secondValue;
            return output;
        }

        private static double Add(double firstValue, double secondValue)
        {
            double output;
            output = firstValue + secondValue;
            return output;
        }
    }
}
