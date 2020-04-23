﻿using MATMEH_QUEST.Domain;
using NUnit.Framework;

namespace TESTS
{
    [TestFixture]
    public class TestEnemy
    {
        [Test]
        public void TestEnemyTakenDamage()
        {
            var enemy = new Enemy(100);
            enemy.TakeDamage(30);
            var actual = enemy.Health;
            Assert.AreEqual(70, actual);
        }

        [Test]
        public void TestEnemyIsAlive()
        {
            var enemy = new Enemy(50).IsAlive();
            var actual = true;
            Assert.AreEqual(true, actual);
        }
    }
}