namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ConstructorShouldInitializeWarriorWithGivenName()
        {
            string expectedName = "Drago";

            Warrior warrior = new(expectedName, 50, 100);

            Assert.AreEqual(expectedName, warrior.Name);
        }

        [Test]
        public void ConstructorShouldInitializeWarriorWithGivenHP()
        {
            int expectedHP = 100;

            Warrior warrior = new("Drago", 50, expectedHP);

            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [Test]
        public void ConstructorShouldInitializeWarriorWihtGivenDmg()
        {
            int expectedDmg = 50;

            Warrior warrior = new Warrior("Drago", expectedDmg, 100);

            Assert.AreEqual(expectedDmg, warrior.Damage);
        }

        [TestCase("Drago")]
        [TestCase("D")]
        [TestCase("D D D D Drago")]
        public void SetterShouldSetValidName(string name)
        {
            Warrior warrior = new(name, 50, 100);

            string expectedName = name;
            string actualName = warrior.Name;
            
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase ("")]
        [TestCase (null)]
        [TestCase("    ")]
        public void SetterShouldThrowIfTheNameIsNotValid(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new(name, 50, 100);

            }, "Name should not be empty or whitespace!");
        }

        [TestCase (1)]
        [TestCase (50)]
        [TestCase (1000000)]
        public void SetterShouldSetValidDamage(int damage)
        {
            Warrior warrior = new("Drago", damage, 100);

            int expectedDmg = damage;
            int actualDmg = warrior.Damage;

            Assert.AreEqual(expectedDmg, actualDmg);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void SetterShouldThrowWhenDmgIsZeroOrNegativeNumber(int dmg)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new("Drago", dmg, 100);

            }, "Damage value should be positive!");
        }

        [TestCase(0)]
        [TestCase(50)]
        [TestCase(1000000)]
        public void SetterShouldSetValidHP(int hp)
        {
            Warrior warrior = new("Drago", 50, hp);

            int expectedDmg = hp;
            int actualDmg = warrior.HP;

            Assert.AreEqual(expectedDmg, actualDmg);
        }

        [TestCase(-1)]
        [TestCase(-50)]
        public void SetterShouldThrowWhenHPIsNegativeNumber(int hp)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new("Drago", 50, hp);

            }, "Damage value should be positive!");
        }

        [TestCase(30)]
        [TestCase(15)]
        [TestCase(1)]
        public void AttackShouldThrowWhenAttackerHpIsBelow30(int hp)
        {
            Warrior warrior1 = new Warrior("Drago", 50, hp);
            Warrior warrior2 = new Warrior("Gosho", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)]
        [TestCase(15)]
        [TestCase(1)]
        public void AttackShouldThrowWhenDefenderHpIsBelow30(int hp)
        {
            Warrior warrior1 = new Warrior("Drago", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 50, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);

            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(49)]
        [TestCase(10)]
        public void AttackShouldThrowWhenDefenderHasMoreDmgThanYourHP(int hp)
        {
            Warrior warrior1 = new Warrior("Drago", 50, hp);
            Warrior warrior2 = new Warrior("Gosho", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);

            }, "You are trying to attack too strong enemy");
        }

        [Test]
        public void SuccesfulAttackWithKill()
        {
            Warrior w1 = new("Drago", 50, 100);
            Warrior w2 = new("Gosho", 50, 49);

            w1.Attack(w2);

            Assert.AreEqual(50, w1.HP);
            Assert.AreEqual(0, w2.HP);

        }

        [Test]
        public void SuccesfulAttackNoKill()
        {
            Warrior w1 = new("Drago", 55, 100);
            Warrior w2 = new("Gosho", 50, 100);

            w1.Attack(w2);

            Assert.AreEqual(50, w1.HP);
            Assert.AreEqual(45, w2.HP);

        }

        




    }
}