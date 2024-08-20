using System.Xml;

namespace YatzyGame
{
    internal class Player
    {
        private int _BonusCheckSum = 0;
        public int BonusCheckSum
        {
            get { return _BonusCheckSum; }
        }
        private int _Bonus = 0;

        public int Bonus
        {
            get { return _Bonus; }
        }
        private bool _DoPlayerHaveBonus = false;
        private int _UpperSumTotal = -1;

        public int[] ScoreCard = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};

        public Player()
        {

        }

        public int SumCheck()
        {
            if (!_DoPlayerHaveBonus) {
                int SumTotal = 0;
                for (int i = 0; i < 6; i++)
                {
                    if(ScoreCard[i] > 0)
                    {
                        SumTotal += ScoreCard[i];
                    }
                }
                if (SumTotal > 62)
                {
                    _Bonus = 50;
                }
                _UpperSumTotal = SumTotal;
                return _UpperSumTotal;
            }
            return _UpperSumTotal;
        }

        public int GetTotalScore()
        {
            int output = 0;

            SumCheck();
            foreach (var item in ScoreCard)
            {
                output += item;
            }
            output += Bonus;

            return output;
        }
    }
}
