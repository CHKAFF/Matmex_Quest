using System;
using MATMEH_QUEST;
using MATMEH_QUEST.Domain;
using NUnit.Framework;

namespace TESTS
{
    [TestFixture]
    public class TestDoor
    {
        [SetUp]
        public Door SetUp()
        {
            return new Door(Door.State.Close);
        }

        [Test]
        public void Test1()
        {
            var door = SetUp();
            var excepted = new Door(Door.State.Open);
            door.Open();
            Assert.AreEqual(excepted, door);
        }
    }
}