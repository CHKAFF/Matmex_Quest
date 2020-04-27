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
            var player = game.Player;
            var inventory = game.Inventory;
            var startPosition = player.Location.X;
            for (var i = 0; i < 10; i++)
            {
                player.MoveRight();
            }
            Assert.AreEqual(startPosition + 10, player.Location.X);
            game.EnterInRoom();
            Assert.AreNotEqual(game.room, null);
        }
    }
}