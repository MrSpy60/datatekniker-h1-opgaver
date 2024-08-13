using System.Text;

namespace Strings
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Add separator
            Console.WriteLine(AddSeparator("ABCD", "^"));
            Console.WriteLine(AddSeparator("chocolate", "-"));
            Console.WriteLine();

            //Is palindrome
            Console.WriteLine(IsPalindrome("eye"));
            Console.WriteLine(IsPalindrome("home"));
            Console.WriteLine();

            //Length of string
            Console.WriteLine(LengthOfAString("computer"));
            Console.WriteLine(LengthOfAString("ice cream"));
            Console.WriteLine();

            //String in reverse order
            Console.WriteLine(StringInReverseOrder("qwerty"));
            Console.WriteLine(StringInReverseOrder("oe93 kr"));
            Console.WriteLine();

            //Number of words
            Console.WriteLine(NumberOfWords("This is sample sentence"));
            Console.WriteLine(NumberOfWords("OK"));
            Console.WriteLine();

            //Revert words order
            Console.WriteLine(RevertWordsOrder("John Doe."));
            Console.WriteLine(RevertWordsOrder("A, B. C"));
            Console.WriteLine();

            //How many occurrences
            Console.WriteLine(HowManyOccurrences("do it now", "do"));
            Console.WriteLine(HowManyOccurrences("empty", "d"));
            Console.WriteLine();

            //Sort characters descending
            Console.WriteLine(SortCharactersDescending("onomatopoeia"));
            Console.WriteLine(SortCharactersDescending("fohjwf42os"));
            Console.WriteLine();

            //Compress string
            Console.WriteLine(CompressString("kkkktttrrrrrrrrrr"));
            Console.WriteLine(CompressString("p555ppp7www"));
        }

        static string AddSeparator(string v1, string v2)
        {
            string output = "";
            int v1Length = v1.Length - 1 ;
            for (int i = 0; i < v1Length; i++)
            {
                output += v1[i] + v2;
            }
            output += v1[v1Length];
            return output;
        }

        static bool IsPalindrome(string v)
        {
            int vLength = v.Length;
            for (int i = 0; i < (vLength/2); i++)
            {
                if (v[i] != v[vLength - 1 - i ])
                {
                    return false;
                }
            }
            return true;
        }

        static int LengthOfAString(string v)
        {
            int counter = 0;
            foreach (char c in v)
            {
                counter++;
            }
            return counter;
        }

        static string StringInReverseOrder(string v)
        {
            string output = "";
            foreach (char c in v)
            {
                output = c + output;
            }
            return output;
        }

        static int NumberOfWords(string v)
        {
            int output = 0;
            string[] strings = v.Split(" ");
            foreach (string s in strings)
            {
                if (s != "")
                {
                    output++;
                }
            }
            return output;
        }

        static string RevertWordsOrder(string v)
        {
            string output = "";
            string[] strings = v.Split(" ");
            int stringsLength = strings.Length; 
            List<int> periodAfter = new();
            int counter = 0;

            //finder hvilke ord der er et "." efter
            foreach (string s in strings)
            {
                if (s[s.Length-1] == '.')
                {
                    periodAfter.Add(counter);
                }
                counter++;
            }

            // bygger sætningen op igen men insætter ord i baglænds rækkefølge
            for (int i = 0; i < stringsLength; i++)
            {
                output += strings[stringsLength -1 - i].Split(".")[0] ;
                foreach (int j in periodAfter)
                {
                    if (j == i)
                    {
                        output += ".";
                    }
                }
                if (i < stringsLength-1)
                {
                    output += " ";
                }
            }
            return output;
        }

        static int HowManyOccurrences(string v1, string v2)
        {
            int output = 0;
            int v1Length = v1.Length;
            int v2Length = v2.Length;

            for (int i = 0; i < v1Length - v2Length+1; i++)
            {
                int counter = 0;
                foreach(char j in v2)
                {
                    if (v1[i+counter] != v2[counter])
                    {
                        break;
                    }
                    counter++;
                }
                if (counter == v2Length)
                {
                    output++;
                }
            }
            return output;
        }
        
        static string SortCharactersDescending(string v)
        {
            string output = "";

            char[] chars = v.ToCharArray();
            chars = chars.OrderByDescending(x => x).ToArray();
            output = string.Join("",chars);

            return output;
        }

        static string CompressString(string v)
        {
            string output = "";
            char compare = '\0';
            int count = 0;
            foreach (char c in v) 
            {
                if (c != compare)
                {
                    if (count > 0)
                    {
                        output += $"{compare}{count}";
                    }
                    compare = c;
                    count = 0;
                }
                count++;
            }
            output += $"{compare}{count}";
            return output;
        }
    }
}
