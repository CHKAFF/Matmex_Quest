﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MATMEH_QUEST.Domain;
using NUnit.Framework;

namespace TESTS
{
    [TestFixture]
    public class TestHuman
    {
        private Human human;

        [SetUp]
        public void SetUp()
        {
            human = new Human(Human.HumanState.Ready,0, new Point(1,1), new List<Item>());
        }

        [Test]
        public void TestHumanIsReady()
        {
            
            Assert.AreEqual(true, human.IsReady());
        }

        [Test]
        public void TestMakeHumanReady()
        {
            human.MakeAwaiting();
            human.MakeReady();
            Assert.AreEqual(true, human.IsReady());
        }

        [Test]
        public void TestMakeAwaiting()
        {
            human.MakeAwaiting();
            var actual = human.State == Human.HumanState.Awaiting;
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void TestMakeNotReady()
        {
            human.MakeNotReady();
            var actual = human.State == Human.HumanState.NotReady;
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void TestCorrectItem()
        {
            human.MakeAwaiting();
            var item1 = new Item(0, 2, new Point(1, 1));
            var item2 = new Item(0, 1, new Point(1, 1));
            human.expectedItems.Add(item1);
            human.expectedItems.Add(item2);
            var actual1 = human.IsCorrectItem(item1);
            var actual2 = human.IsCorrectItem(new Item(1,3, new Point(1, 1)));
            Assert.AreEqual(true, actual1);
            Assert.AreEqual(false, actual2);
        }

        [Test]
        public void TestRemoveBoughtItem()
        {
            human.MakeAwaiting();
            var item1 = new Item(0, 2, new Point(1, 1));
            var item2 = new Item(0, 1, new Point(1, 1));
            human.expectedItems.Add(item1);
            human.expectedItems.Add(item2);
            human.RemoveBroughtItem(item1);
            var actual = human.expectedItems.Count;
            Assert.AreEqual(1, actual);
        }
    }
}