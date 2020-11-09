using BowlingGameScore;
using NUnit.Framework;

namespace BowlingGameScoreTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_RollGutterGame_Returns_0()
        {
            // Arrange
            var game = new BowlingGame();
            // Act
            for (int i = 0; i < 20; i++)
                game.Roll(0);
            // Assert
            Assert.AreEqual(0, game.Score);
        }
    }
}