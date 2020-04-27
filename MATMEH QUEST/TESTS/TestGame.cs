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
<<<<<<< HEAD
            var startPosition = game.Player.Location.X;
            for (int i = 0; i < 10; i++)
=======
            var player = game.Player;
            var inventory = game.Inventory;
            var startPosition = player.Location.X;
            for (var i = 0; i < 10; i++)
>>>>>>> class_Player
            {
                game.Player.MoveRight();
            }
<<<<<<< HEAD
            Assert.AreEqual(startPosition+10, game.Player.Location.X);
=======
            Assert.AreEqual(startPosition + 10, player.Location.X);
>>>>>>> class_Player
            game.EnterInRoom();
            Assert.AreNotEqual(game.room, null);
        }
    }
}