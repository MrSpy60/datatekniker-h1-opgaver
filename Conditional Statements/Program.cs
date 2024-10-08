﻿namespace Conditional_Statements
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Absolute value
            Console.WriteLine(AbsoluteValue(6832));
            Console.WriteLine(AbsoluteValue(-392));
            Console.WriteLine();

            //multResult % 2 == 0
            Console.WriteLine(DivisibleBy2Or3(15, 30));
            Console.WriteLine(DivisibleBy2Or3(2, 90));
            Console.WriteLine(DivisibleBy2Or3(7, 12));
            Console.WriteLine();

            //If consists of uppercase letters
            Console.WriteLine(IfConsistsOfUppercaseLetters("xyz"));
            Console.WriteLine(IfConsistsOfUppercaseLetters("DOG"));
            Console.WriteLine(IfConsistsOfUppercaseLetters("L9#"));
            Console.WriteLine();

            //If greater than third one
            Console.WriteLine(IfGreaterThanThirdOne([2, 7, 12]));
            Console.WriteLine(IfGreaterThanThirdOne([-5, -8, 50]));
            Console.WriteLine();

            //If number is even
            Console.WriteLine(IfNumberIsEven(721));
            Console.WriteLine(IfNumberIsEven(1248));
            Console.WriteLine();

            //If sorted ascending
            Console.WriteLine(IfSortedAscending([3, 7, 10]));
            Console.WriteLine(IfSortedAscending([74, 62, 99]));
            Console.WriteLine();

            //Positive, negative or zero
            Console.WriteLine(PositiveNegativeOrZero(5.24));
            Console.WriteLine(PositiveNegativeOrZero(0.0));
            Console.WriteLine(PositiveNegativeOrZero(-994.53));
            Console.WriteLine();

            //If year is leap
            Console.WriteLine(IfYearIsLeap(2016));
            Console.WriteLine(IfYearIsLeap(2018));
            Console.WriteLine();
        }


        public static int AbsoluteValue(int v)
        {
            if (v < 0)
            {
                v *= -1;
            }
            return v;
        }

        public static int DivisibleBy2Or3(int v1, int v2)
        {  
            if ((v1 % 2 == 0 && v2 % 2 == 0 ) || (v1 % 3 == 0 && v2 % 3 == 0))
            {
                return v1 * v2;
            }
            return v1 + v2;
        }

        public static bool IfConsistsOfUppercaseLetters(string v)
        {
            foreach (char c in v)
            {
                if (!char.IsUpper(c))
                {
                    return false;
                }
            }
            return true;
            //gamme
            //return v.All(char.IsUpper);
        }

        public static bool IfGreaterThanThirdOne(int[] v)
        {
            if (v[0] * v[1] > v[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IfNumberIsEven(int v)
        {
            int remainerOfV = v % 2;
            switch (remainerOfV)
            {
                case 0:
                    return true;
                case 1:
                    return false;
            }
            throw new NotImplementedException();
        }

        public static bool IfSortedAscending(int[] v)
        {
            int vLength = v.Length;
            for (int i = 1; i < vLength; i++)
            {
                if (v[i - 1] > v[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static string PositiveNegativeOrZero(double v)
        {
            if (v == 0.0)
            {
                return "Zero";
            }
            else if (v > 0.0)
            {
                return "Positive";
            }
            else
            {
                return "Negative";
            }
        }


        public static bool IfYearIsLeap(int v)
        {
            if (v % 4 == 0)
            {
                if ((v % 100) == 0)
                {
                    if (v % 400 == 0)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
