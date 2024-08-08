namespace Lommeregner
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                firstValue = int.Parse(tempData[0]);
                secondValue = int.Parse(tempData[1]);
                switch (operatorType)
                {
                    case '+':
                        Console.WriteLine(Add(firstValue,secondValue));
                        break;
                    case '-':
                            Console.WriteLine(Subtract(firstValue, secondValue));
                        break;
                    case '/':
                        if (secondValue == 0){
                            Console.WriteLine("HOOMAN ERROR: Divide By 0 Not Allowed!");
                            break;
                        }
                        Console.WriteLine(divide(firstValue, secondValue));
                        break;
                    case '*':
                        Console.WriteLine(Multiply(firstValue, secondValue));
                        break;
                    case '%':
                        Console.WriteLine(Modulus(firstValue, secondValue));
                        break;
                    default:
                        Console.WriteLine("Operator not supported or implemented yet!!!");
                        break;
                }

            }
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
