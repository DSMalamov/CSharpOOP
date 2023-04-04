using NUnit.Framework;
using System;
using PlanetWars;
using System.Linq;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                weapon = new Weapon("me4", 10.20, 5);
                planet = new Planet("Yambol", 100);
            }

            [Test]
            public void WeaponConstructorShouldWork()
            {
                Assert.IsNotNull(weapon);
                Assert.AreEqual("me4", weapon.Name);
                Assert.AreEqual(10.20, weapon.Price);
                Assert.AreEqual(5, weapon.DestructionLevel);
            }


            [Test]
            public void WeaponCtorShouldThrowWhenPriceIsNegative()
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weap = new Weapon("LoshMech", -1, 5);

                }, "Price cannot be negative.");
            }

            [Test]
            public void WeaponIsNuclear()
            {
                Weapon weapon = new Weapon("me4", 10.20, 11);

                Assert.IsTrue(weapon.IsNuclear);
            }

            [Test]
            public void WeaponShouldIncrDetrsLevel()
            {
                weapon.IncreaseDestructionLevel();
                int expectedValue = 6;

                Assert.That(expectedValue, Is.EqualTo(weapon.DestructionLevel));
                
            }

            [Test]
            public void PlanetCtorShouldWorn()
            {
                Assert.That(planet.Name, Is.EqualTo("Yambol"));
                Assert.That(planet.Budget, Is.EqualTo(100));
                Assert.IsNotNull(planet.Weapons);
            }

            [TestCase(null)]
            [TestCase("")]
            public void PlanetNameShouldThrowWhenNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(name, 100);

                }, "Invalid planet Name");
            }

            [TestCase(-1)]
            [TestCase(-10)]
            public void PlanetBudgetShouldThrowWhenNegative(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("kkkk", budget);

                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void MilitaryPowerRatioShouldWork()
            {
                Weapon newWeap = new Weapon("golqmMe4", 10, 9);
                planet.AddWeapon(weapon);
                planet.AddWeapon(newWeap);

                int expectedPowerRatio = newWeap.DestructionLevel + weapon.DestructionLevel;

                Assert.AreEqual(expectedPowerRatio, planet.MilitaryPowerRatio);
            }

            [Test]
            public void PlanetBudgetShouldIncrease()
            {
                double expectedBudget = planet.Budget + 100;

                planet.Profit(100);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [Test]
            public void SpendShouldWork()
            {
                planet.SpendFunds(10);

                Assert.AreEqual(90, planet.Budget);
            }

            [Test]
            public void SpendShouldThrow()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(1000);

                }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void AddWeaponShouldWork()
            {
                Weapon newWeap = new Weapon("golqmMe4", 10, 9);
                planet.AddWeapon(weapon);
                planet.AddWeapon(newWeap);

                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void AddWeaponShouldThrow()
            {
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);

                }, $"There is already a {weapon.Name} weapon.");
            }

            [Test]
            public void RemoveWeaponShouldWork()
            {
                Weapon newWeap = new Weapon("golqmMe4", 10, 9);
                planet.AddWeapon(weapon);
                planet.AddWeapon(newWeap);

                planet.RemoveWeapon("golqmMe4");

                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.IsTrue(planet.Weapons.Any(w => w.Name == "me4"));
            }

            [Test]
            public void UpgradeWeaponShouldWork()
            {
                planet.AddWeapon(weapon);
                int expectetValue = weapon.DestructionLevel + 1;
                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(expectetValue, weapon.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponShouldThrow()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weapon.Name);

                }, $"{weapon.Name} does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void DestructOponentShouldWork()
            {
                planet.AddWeapon(weapon);
                Planet opponent = new Planet("Pernik", 100);

                Assert.AreEqual($"{opponent.Name} is destructed!", planet.DestructOpponent(opponent));
            }

            [Test]
            public void DestructOponentShouldThrow()
            {
                Planet opponent = new Planet("Pernik", 100);
                opponent.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponent);

                }, $"{opponent.Name} is too strong to declare war to!");
            }

        }
    }
}
