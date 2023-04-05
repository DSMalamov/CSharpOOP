using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void CtorShouldWork()
        {
            Gym gym = new Gym("Gosho", 10);

            Assert.AreEqual("Gosho", gym.Name);
            Assert.AreEqual(10, gym.Capacity);
            Assert.AreEqual(0, gym.Count);

        }

        [TestCase(null)]
        [TestCase("")]
        public void CtorShouldThrowInvalidName(string name)
        {
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 10);
            }, $"{name}, Invalid gym name.");
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void CtorShouldThrowInvalidCapacity(int cap)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Gosho", cap);
            }, "Invalid gym capacity.");
        }

        [Test]
        public void AddAthleteShouldThrow()
        {
            Gym gym = new Gym("Gosho", 0);
            Athlete ath = new Athlete("Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(ath);
            }, "The gym is full.");
        }

        [Test]
        public void AddAthleteShouldWork()
        {
            Gym gym = new Gym("Gosho", 10);
            Athlete ath = new Athlete("Gosho");
            gym.AddAthlete(ath);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void RemoveAthleteShouldThrow()
        {
            Gym gym = new Gym("Gosho", 10);
            Athlete ath = new Athlete("Gosho");
            gym.AddAthlete(ath);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Misho");
            }, $"The athlete Misho doesn't exist.");
        }

        [Test]
        public void RemoveAthleteShouldWork()
        {
            Gym gym = new Gym("Gosho", 10);
            Athlete ath = new Athlete("Gosho");
            gym.AddAthlete(ath);
            gym.RemoveAthlete("Gosho");

            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void InjureAthleteShouldThrow()
        {
            Gym gym = new Gym("Gosho", 10);
            Athlete ath = new Athlete("Gosho");
            gym.AddAthlete(ath);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Misho");
            }, $"The athlete Misho doesn't exist.");
        }

        [Test]
        public void InjureAthleteShouldWork()
        {
            Gym gym = new Gym("Gosho", 10);
            Athlete ath = new Athlete("Gosho");
            gym.AddAthlete(ath);

            Assert.AreEqual(ath, gym.InjureAthlete("Gosho"));
            Assert.IsTrue(ath.IsInjured);
        }

        [Test]
        public void ReporShouldWork()
        {
            string expecteOutput = $"Active athletes at Gosho: Joro, Miro, Mitko";
            Gym gym = new Gym("Gosho", 10);
            Athlete ath1 = new Athlete("Joro");
            Athlete ath2 = new Athlete("Miro");
            Athlete ath3 = new Athlete("Mitko");
            gym.AddAthlete(ath1);
            gym.AddAthlete(ath2);
            gym.AddAthlete(ath3);

            Assert.AreEqual(expecteOutput, gym.Report());

        }
    }
}
