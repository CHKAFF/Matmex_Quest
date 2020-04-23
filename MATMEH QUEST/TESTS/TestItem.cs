using System;
using System.Collections.Generic;
using System.Linq;
using MATMEH_QUEST;
using MATMEH_QUEST.Domain;
using NUnit.Framework;

namespace TESTS
{
    [TestFixture]
    public class TestItem
    {
        [Test]
        public void TestCreateItem()
        {
            var item = new Item(42,57);
            var actual = item.MissionID == 42 && item.ObjectID == 57;
            Assert.AreEqual(true, actual);
        }
    }
}