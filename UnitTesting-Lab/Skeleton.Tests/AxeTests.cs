using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attack;
        private int durability;
        private int health;
        private int experiance;

        [SetUp]
        public void Setup()
        {
            attack = 10;
            durability = 10;
            health = 10;
            experiance = 10;
            axe = new(attack, durability);
            dummy = new(health, experiance);

        }
        [Test]
        public void AxeGettersTest()
        {

            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(10, axe.DurabilityPoints);
        }
        [Test]
        public void AxeLoseingDurabilityTest()
        {

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints);

        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            Axe axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
                
        }
    }
}