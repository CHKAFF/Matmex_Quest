using System;
using MATMEH_QUEST.Domain;
using NUnit.Framework;
using  System.Drawing;

namespace TESTS
{
    [TestFixture]
    public class TestGame
    {
        [Test]
        public void GlobalTest()
        {
            var game = new Game();
            var startPosition = game.Player.Location.X;
            for (int i = 0; i < 10; i++)
            {
                game.Player.MoveRight();
            }
            Assert.AreEqual(startPosition+10, game.Player.Location.X);
            game.EnterInRoom();
            Assert.AreNotEqual(game.room, null);
        }
    }
}