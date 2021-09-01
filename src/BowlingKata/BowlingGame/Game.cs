namespace BowlingGame
{
    public class Game
    {
        private int[] _rolls;
        private int _currentRoll;
        
        public Game()
        {
            _rolls = new int[21];
        }

        public int Score() 
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {

                if (IsStrike(frameIndex))
                {
                    score += StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }

    }
}