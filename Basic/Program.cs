using System.Globalization;
using System.Xml;

namespace Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {




            //Add two numbers
            Console.WriteLine(AddAndMultiply(2, 4, 5));
            Console.WriteLine();

            //Celsius to Fahrenheit
            Console.WriteLine(CtoF(0));
            Console.WriteLine(CtoF(100));
            Console.WriteLine(CtoF(-300));
            Console.WriteLine();

            //Elementary operations
            Console.WriteLine(ElementaryOperations(3, 8));
            Console.WriteLine();

            //Is result the same
            Console.WriteLine(IsResultTheSame(2 + 2, 2 * 2));
            Console.WriteLine(IsResultTheSame(9 / 3, 16 - 1));
            Console.WriteLine();

            //Modulo operations
            Console.WriteLine(ModuloOperations(8,5,2));
            Console.WriteLine();

            //The cube of
            Console.WriteLine(CubeOf(2));
            Console.WriteLine(CubeOf(-5.5));
            Console.WriteLine();

            //Swap two numbers
            Console.WriteLine(SwapTwoNumbers(87, 45));
            Console.WriteLine(SwapTwoNumbers(-13, 2));
            Console.WriteLine();
        }

        static int AddAndMultiply(int a, int b, int c) 
        {
            int output = (a + b) * c;
            return output;
        }

        static string CtoF(int c)
        {
            string output;
            double fahrenheit = (c * 9 / 5) + 32;
            output = $"T = {fahrenheit}F";
            if (c < -271) 
            {
                output = "Temperature below absolute zero!";
            }
            return output;
        }

        static string ElementaryOperations(double a,double b)
        {
            string output = "";
            output += $"{a + b}, "; //Add
            output += $"{a - b}, "; //subtract
            output += $"{a * b}, "; //multiply
            if (b != 0)
            {
                output += $"{a / b}"; //divide
            }
            else
            {
                output += "can't divide any number by 0!";
            }
            return output;
        }

        static bool IsResultTheSame(int a,int b)
        {
            return a == b;
        }

        static int ModuloOperations(int a, int b, int c)
        {
            int output = (a % b) % c;
            return output;
        }

        static double CubeOf(double a)
        {
            double output = a * a * a;
            return output;
        }

        static string SwapTwoNumbers(int a, int b)
        {
            string output = $"Before: a = {a}, b = {b};";
            int temp = a;
            a = b;
            b = temp;
            output += $" After: a = {a}, b = {b}";
            return output;
        }

    }
}
