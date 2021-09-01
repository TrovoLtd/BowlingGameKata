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

                if (IsSpare(frameIndex))
                {
                    score += 10 + _rolls[frameIndex + 2];
                }
                else
                {
                    score += _rolls[frameIndex] + _rolls[frameIndex + 1];
                }

                frameIndex += 2;
            }

            return score;
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