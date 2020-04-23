using System;
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
            var door = new Door(Door.DoorState.Close);
            door.Open();
            var actual = door.State;
            var excepted = new Door(Door.DoorState.Open).State;
            Assert.AreEqual(excepted, actual);
        }
        
        [Test]
        public void TestDoorClose()
        {
            var door = new Door(Door.DoorState.Open);
            door.Close();
            var actual = door.State;
            var excepted = new Door(Door.DoorState.Close).State;
            Assert.AreEqual(excepted, actual);
        }
        
        [Test]
        public void TestIsOpenWhenDoorOpen()
        {
            var door = new Door(Door.DoorState.Open);
            var actual = door.IsOpen();
            Assert.AreEqual(true, actual);
        }
        
        [Test]
        public void TestIsOpenWhenDoorClose()
        {
            var door = new Door(Door.DoorState.Close);
            var actual = door.IsOpen();
            Assert.AreEqual(false, actual);
        }
    }
}