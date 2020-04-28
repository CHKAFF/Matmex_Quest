using System;
using System.Drawing;
using MATMEH_QUEST;
using MATMEH_QUEST.Domain;
using NUnit.Framework;

namespace TESTS
{
    [TestFixture]
    public class TestDoor
    {
        [Test]
        public void TestDoorOpen()
        {
            var door = new Door(Door.DoorState.Close, new Room(), new Point(1,0));
            door.Open();
            var actual = door.State;
            var excepted = new Door(Door.DoorState.Open, new Room(), new Point(1,0)).State;
            Assert.AreEqual(excepted, actual);
        }
        
        [Test]
        public void TestDoorClose()
        {
            var door = new Door(Door.DoorState.Open, new Room(), new Point(1,0));
            door.Close();
            var actual = door.State;
            var excepted = new Door(Door.DoorState.Close, new Room(), new Point(1,0)).State;
            Assert.AreEqual(excepted, actual);
        }
        
        [Test]
        public void TestIsOpenWhenDoorOpen()
        {
            var door = new Door(Door.DoorState.Open, new Room(), new Point(1,0));
            var actual = door.IsOpen();
            Assert.AreEqual(true, actual);
        }
        
        [Test]
        public void TestIsOpenWhenDoorClose()
        {
            var door = new Door(Door.DoorState.Close, new Room(), new Point(1,0));
            var actual = door.IsOpen();
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void TestEnterInRoom()
        {
            var door = new Door(Door.DoorState.Close, new Room(), new Point(1, 0));
            Assert.AreNotEqual(door.EnterRoom(), null);
        }
    }
}