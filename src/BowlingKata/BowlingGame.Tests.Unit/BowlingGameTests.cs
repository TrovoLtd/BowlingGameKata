using NUnit.Framework;

namespace BowlingGame.Tests.Unit
{
    public class BowlingGameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGutterGame()
        {
            Game game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(0); 
            }

            Assert.AreEqual(0, game.Score);
        }
    }
}