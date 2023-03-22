namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitArena()
        {
            arena = new Arena();

            Assert.IsNotNull(arena);

        }

        [Test]
        public void EnrollingNonExistingElement()
        {
            Warrior w1 = new("Drago", 50, 100);

            arena.Enroll(w1);

            bool isAdded = arena
                .Warriors
                .Contains(w1);

            Assert.IsTrue(isAdded);
        }

        [Test]
        public void EnrollingExistingElementShouldThrow()
        {
            Warrior w1 = new("Drago", 50, 100);
            arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(w1);

            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollingElementWithSameShouldThrow()
        {
            Warrior w1 = new("Drago", 50, 100);
            Warrior w2 = new("Drago", 60, 100);
            arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(w2);

            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollingShouldIncreaseCount()
        {
            Warrior w1 = new("Drago", 50, 100);
            Warrior w2 = new("Gosho", 60, 100);

            arena.Enroll(w1);
            arena.Enroll(w2);

            int expectedCount = 2;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void CountShoudReturnZeroIfTheCollectionIsEmpty()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void FightShouldThrowWithNonExistingAttacker()
        {
            Warrior w1 = new("Drago", 55, 100);
            Warrior w2 = new("Gosho", 50, 100);

            arena.Enroll(w2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(w1.Name, w2.Name);

            }, $"There is no fighter with name {w1.Name} enrolled for the fights!");

        }

        [Test]
        public void FightShouldThrowWithNonExistingDefender()
        {
            Warrior w1 = new("Drago", 55, 100);
            Warrior w2 = new("Gosho", 50, 100);

            arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(w1.Name, w2.Name);

            }, $"There is no fighter with name {w2.Name} enrolled for the fights!");

        }

        [Test]
        public void FightShouldBeCompleted()
        {
            Warrior w1 = new("Drago", 55, 100);
            Warrior w2 = new("Gosho", 50, 100);

            int expectedHpW1 = w1.HP - w2.Damage;
            int expectedHpW2 = w2.HP - w1.Damage;

            this.arena.Enroll(w1);
            this.arena.Enroll(w2);

            arena.Fight(w1.Name, w2.Name);

            int actualHpW1 = w1.HP;
            int actualHpW2 = w2.HP;

            Assert.AreEqual(expectedHpW2,actualHpW2);
            Assert.AreEqual(expectedHpW1,actualHpW1);

        }


    }
}
