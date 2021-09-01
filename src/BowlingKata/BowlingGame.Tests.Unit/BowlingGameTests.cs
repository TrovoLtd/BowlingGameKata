using NUnit.Framework;

namespace BowlingGame.Tests.Unit
{
    public class BowlingGameTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void TestGutterGame()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, _game.Score());
        }


        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void TestOneSpare()
        {
            RollSpare();
            _game.Roll(3);

            RollMany(17, 0);

            Assert.AreEqual(16, _game.Score());
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }
        }

    }
}