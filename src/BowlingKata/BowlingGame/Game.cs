namespace BowlingGame
{
    public class Game
    {
        public int Score { get; set; }

        public void Roll(int pins)
        {
            Score += pins;
        }
    }
}