using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private int healt;
        private int experiance;

        [SetUp]
        public void Setup()
        {
            healt= 10;
            experiance= 10;
            dummy = new Dummy(healt, experiance);
            deadDummy = new Dummy(0, experiance);

        }

        [Test]
        public void DummyLosesHpAfterAttack()
        {

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void TryToAttackDeadDummy()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(1);
            });
        }

        [Test]
        public void DeadDummyGivesXP() 
        {
            var dummyXp = deadDummy.GiveExperience();

            Assert.AreEqual(10 , dummyXp);
        }

        [Test]
        public void AliveDummyDoesntReturnExp()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}