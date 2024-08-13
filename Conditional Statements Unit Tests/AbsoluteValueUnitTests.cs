using Conditional_Statements;

namespace Conditional_Statements_Unit_Tests
{
    public class AbsoluteValueUnitTests
    {
        [Theory]
        [InlineData(4, 4)]
        [InlineData(13, 13)]
        [InlineData(-4, 4)]
        [InlineData(-134, 134)]
        public void AbosluteValueTests(int a, int expected)
        {
            //arragne

            //act
            int actual = Program.AbsoluteValue(a);
            //assert
            Assert.Equal(expected, actual);
        }
    }

    public class DivisibleBy2Or3UnitTests
    {
        [Theory]
        [InlineData(4, 8, 32)]
        [InlineData(9, 15, 135)]
        [InlineData(7, 11, 18)]
        [InlineData(21, 8, 29)]
        public void DivisibleBy2Or3Tests(int a, int b, int expected)
        {
            //arragne

            //act
            int actual = Program.DivisibleBy2Or3(a, b);
            //assert
            Assert.Equal(expected, actual);
        }

    }
    public class IfConsistsOfUppercaseLettersUnitTests
    {
        [Theory]
        [InlineData("BOB", true)]
        [InlineData("Hej", false)]
        [InlineData("xyz", false)]
        [InlineData("MAR", true)]
        [InlineData("Jo!", false)]
        [InlineData("TIN", true)]
        [InlineData("?!?", false)]
        public void IfConsistsOfUppercaseLettersTests(string a, bool expected)
        {
            //arragne

            //act
            bool actual = Program.IfConsistsOfUppercaseLetters(a);
            //assert
            Assert.Equal(expected, actual);
        }
    }

    public class IfGreaterThanThirdOneUnitTests
    {
        [Theory]
        [InlineData((int[])[1, 2, 3], false)]
        [InlineData((int[])[4, 6, 23], true)]
        [InlineData((int[])[4, 6, 25], false)]
        public void IfGreaterThanThirdOneTests(int[] a, bool expected)
        {
        //arragne

        //act
        bool actual = Program.IfGreaterThanThirdOne(a);
        //assert
        Assert.Equal(expected, actual);
        }
    }

    public class IfNumberIsEvenUnitTests
    {
        [Theory]
        [InlineData(721,false)]
        [InlineData(1248,true)]
        public void IfNumberIsEvenTests(int a, bool expected)
        {
            //arragne

            //act
            bool actual = Program.IfNumberIsEven(a);
            //assert
            Assert.Equal(expected, actual);
        }
    }

    public class IfSortedAscendingUnitTests
    {
        [Theory]
        [InlineData((int[])[1,2,3],true)]
        [InlineData((int[])[1,3,2],false)]
        [InlineData((int[])[11,21,31],true)]
        [InlineData((int[])[41,33,12],false)]
        public void IfSortedAscendingTests(int[] a, bool expected)
        {
            //arragne

            //act
            bool actual = Program.IfSortedAscending(a);
            //assert
            Assert.Equal(expected, actual);
        }
    }

    public class PositiveNegativeOrZeroUnitTests
    {
        [Theory]
        [InlineData(5.5, "Positive")]
        [InlineData(0.0, "Zero")]
        [InlineData(-5.5, "Negative")]
        public void PositiveNegativeOrZeroTests(double a, string expected)
        {
            //arragne

            //act
            string actual = Program.PositiveNegativeOrZero(a);
            //assert
            Assert.Equal(expected, actual);
        }

    }

    public class IfYearIsLeapUnitTests
    {
        [Theory]
        [InlineData(1900, false)]
        [InlineData(1902, false)]
        [InlineData(1904, true)]
        [InlineData(1996, true)]
        [InlineData(1998, false)]
        [InlineData(2000, true)]
        [InlineData(2002, false)]
        [InlineData(2004, true)]
        public void IfYearIsLeapTests(int a, bool expected)
        {
            //arragne

            //act
            bool actual = Program.IfYearIsLeap(a);
            //assert
            Assert.Equal(expected, actual);
        }
    }
}