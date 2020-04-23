using MATMEH_QUEST.Domain;
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
            Assert.AreEqual(true, enemy);
        }

        [Test]
        public void TestEnemyWasAliveButNowDead()
        {
            var enemy = new Enemy(30);
            enemy.TakeDamage(75);
            Assert.AreEqual(false, enemy.IsAlive());
        }
    }
}