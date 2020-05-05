using System;
using MATMEH_QUEST.Domain;
using NUnit.Framework;
using  System.Drawing;
using System.Linq;

namespace TESTS
{
    [TestFixture]
    public class TestGame
    {
        [Test]
        public void GlobalTest()
        {
            var game = new Game(); 
            game.New();
            var startPosition = game.Player.Location.X;
            for (var i = 0; i < 20; i++)
            {
                game.PlayerMoveRight();
            }
            Assert.AreEqual(startPosition+20, game.Player.Location.X);
            var locationInWorld = game.Player.Location;
            game.EnterInRoom();
            Assert.AreNotEqual(game.room, null);
            for (var i = 0; i < 10; i++)
            {
                game.PlayerMoveRight();
            }
            game.TalkWithHuman();
            Assert.AreEqual(game.World.Doors[game.room.Humans[0].MissionID].State, Door.DoorState.Open);
            game.LeaveFromRoom();
            Assert.AreEqual(game.room, null);
            Assert.AreEqual(locationInWorld, game.Player.Location);
            startPosition = game.Player.Location.X;
            for (var i = 0; i < 20; i++)
            {
                game.PlayerMoveLeft();
            }
            Assert.AreEqual(startPosition-20, game.Player.Location.X);
            game.EnterInRoom();
            game.Inventory.PutItem(game.room.GetItem(new Point(15, 15)));
            Assert.AreEqual(0, game.room.LevelItems.Count);
            Assert.AreEqual(1,game.Inventory.items.Count);
            game.LeaveFromRoom();
            for (var i = 0; i < 20; i++)
            {
                game.PlayerMoveRight();
            }
            game.EnterInRoom();
            for (var i = 0; i < 10; i++)
            {
                game.PlayerMoveRight();
            }
            game.GiveItem(game.Inventory.items.Keys.ToList().FirstOrDefault());
            Assert.AreEqual(0, game.room.Humans[0].expectedItems.Count);
            Assert.AreEqual(Human.HumanState.NotReady,game.room.Humans[0].State);
            Assert.AreEqual(0, game.Inventory.items.Count);
        }
    }
}