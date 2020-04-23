using System;
using System.Collections.Generic;
using System.Linq;
using MATMEH_QUEST;
using MATMEH_QUEST.Domain;
using NUnit.Framework;

namespace TESTS
{
    [TestFixture]
    public class TestInventory
    {
        public Inventory innventory;
        public Item item;
        [SetUp]
        public void SetUp()
        {
            innventory
        }

        [Test]
        public void TestItemsIsClear()
        {
            Assert.AreEqual(0,new Inventory().items.Count);
        }
        
        [Test]
        public void TestPutItem()
        {
            var item = new Item(1,1);
            var inventory = new Inventory();
            inventory.PutItem(item);
            var actual = inventory.items.ContainsKey(item);
            Assert.AreEqual(true, actual);
        }
        
        [Test]
        public void TestPutItemWhenInventoryHaveThisItem()
        {
            var item = new Item(1,1);
            var inventory = new Inventory();
            inventory.PutItem(item);
            inventory.PutItem(item);
            var actual = inventory.items.Count;
            Assert.AreEqual(1, actual);
        }
        
        [Test]
        public void TestInInventoryWhenItemInInventory()
        {
            var item = new Item(1,1); 
            var inventory = new Inventory(); 
            inventory.PutItem(item);
            var actual = inventory.InInventory(item);
            Assert.AreEqual(true, actual);
        }
        
        [Test]
        public void TestInInventoryWhenItemNotInInventory()
        {
            var item = new Item(1,1); 
            var inventory = new Inventory(); 
            var actual = inventory.InInventory(item);
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void TestCountInInventory()
        {
            var item = new Item(1,1);
            var inventory = new Inventory(); 
            inventory.PutItem(item);
            inventory.PutItem(item);
            var actual = inventory.items[item];
            Assert.AreEqual(2, actual);
        }
        
        [Test]
        public void TestGetItemCount()
        {
            var item = new Item(1,1);
            var inventory = new Inventory(); 
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
            var item = new Item(1,1);
            var inventory = new Inventory(); 
            inventory.PutItem(item);
            inventory.TakeItem(item);
            var actual = inventory.InInventory(item);
            Assert.AreEqual(false, actual);
        }
    }
}