using BowlingGameScore;
using NUnit.Framework;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BowlingGameScoreTests
{
    public class BowlingGameScoreTests
    {
        private BowlingGame game;

        [SetUp]
        public void Setup()
        {
            game = new BowlingGame();
        }

        [Test]
        public void When_Roll_GutterGame_Returns_0()
        {
            // Arrange
            // Act
            RollMany(20, 0);
            // Assert
            Assert.AreEqual(0, game.Score);
        }

         [Test]
        public void When_Roll_AllOnes_Returns_20()
        {
            // Arrange
            // Act
            RollMany(20, 1);
            // Assert
            Assert.AreEqual(20, game.Score);
        }
        [Test]
        public void When_Roll_SpareAndThree_Returns_16()
        {
            // Arrange
            // Act
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(17, 0);
            // Assert
            Assert.AreEqual(16, game.Score);
        }
        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }

    }
}