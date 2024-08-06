namespace Conditional_Statements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Absolute value
            Console.WriteLine(AbsoluteValue(6832));
            Console.WriteLine(AbsoluteValue(-392));

            //multResult % 2 == 0
            Console.WriteLine(DivisibleBy2Or3(15, 30));
            Console.WriteLine(DivisibleBy2Or3(2, 90));
            Console.WriteLine(DivisibleBy2Or3(7, 12));

            //If consists of uppercase letters
            Console.WriteLine(IfConsistsOfUppercaseLetters("xyz"));
            Console.WriteLine(IfConsistsOfUppercaseLetters("DOG"));
            Console.WriteLine(IfConsistsOfUppercaseLetters("L9#"));

            //If greater than third one
            Console.WriteLine(IfGreaterThanThirdOne([2, 7, 12]));
            Console.WriteLine(IfGreaterThanThirdOne([-5, -8, 50]));

            //If number is even
            Console.WriteLine(IfNumberIsEven(721));
            Console.WriteLine(IfNumberIsEven(1248));

            //If sorted ascending
            Console.WriteLine(IfSortedAscending([3, 7, 10]));
            Console.WriteLine(IfSortedAscending([74, 62, 99]));

            //Positive, negative or zero
            Console.WriteLine(PositiveNegativeOrZero(5.24));
            Console.WriteLine(PositiveNegativeOrZero(0.0));
            Console.WriteLine(PositiveNegativeOrZero(-994.53));

            //If year is leap
            Console.WriteLine(IfYearIsLeap(2016));
            Console.WriteLine(IfYearIsLeap(2018));
        }


        private static int AbsoluteValue(int v)
        {
            if (v < 0)
            {
                v *= -1;
            }
            return v;
        }

        private static int DivisibleBy2Or3(int v1, int v2)
        {  
            if ((v1 % 2 == 0 || v1 % 3 == 0) && (v2 % 2 == 0 || v2 % 3 == 0))
            {
                return v1 * v2;
            }
            return v1 + v2;
        }
        
        private static bool IfConsistsOfUppercaseLetters(string v)
        {
            return v.All(char.IsUpper);
        }

        private static bool IfGreaterThanThirdOne(int[] v)
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

        private static bool IfNumberIsEven(int v)
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

        private static bool IfSortedAscending(int[] v)
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

        private static string PositiveNegativeOrZero(double v)
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


        private static bool IfYearIsLeap(int v)
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
