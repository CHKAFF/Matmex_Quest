using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MATMEH_QUEST;
using MATMEH_QUEST.Domain;
using NUnit.Framework;

namespace TESTS
{
    [TestFixture]
    public class TestInventory
    {
        private Inventory inventory;
        private Item item;
        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            item = new Item(1,1, new Point(1,2));
        }

        [Test]
        public void TestItemsIsClear()
        {
            Assert.AreEqual(0,new Inventory().items.Count);
        }
        
        [Test]
        public void TestPutItem()
        {
            SetUp();
            inventory.PutItem(item);
            var actual = inventory.items.ContainsKey(item);
            Assert.AreEqual(true, actual);
        }
        
        [Test]
        public void TestPutItemWhenInventoryHaveThisItem()
        {
            SetUp();
            inventory.PutItem(item);
            inventory.PutItem(item);
            var actual = inventory.items.Count;
            Assert.AreEqual(1, actual);
        }
        
        [Test]
        public void TestInInventoryWhenItemInInventory()
        {
            SetUp();
            inventory.PutItem(item);
            var actual = inventory.InInventory(item);
            Assert.AreEqual(true, actual);
        }
        
        [Test]
        public void TestInInventoryWhenItemNotInInventory()
        {
            SetUp();
            var actual = inventory.InInventory(item);
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void TestCountInInventory()
        {
            SetUp();
            inventory.PutItem(item);
            inventory.PutItem(item);
            var actual = inventory.items[item];
            Assert.AreEqual(2, actual);
        }
        
        [Test]
        public void TestGetItemCount()
        {
            SetUp();
            inventory.PutItem(item);
            inventory.PutItem(item);
            inventory.PutItem(item);
            inventory.PutItem(item);
            var actual = inventory.GetItemCount(item);
            Assert.AreEqual(4, actual);
        }
        
        [Test]
        public void TestTakeItem()
        {
            SetUp();
            inventory.PutItem(item);
            inventory.TakeItem(item);
            var actual = inventory.InInventory(item);
            Assert.AreEqual(false, actual);
        }
    }
}