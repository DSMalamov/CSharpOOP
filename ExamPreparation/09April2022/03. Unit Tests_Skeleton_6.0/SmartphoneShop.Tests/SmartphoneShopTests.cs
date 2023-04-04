using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;
        private Smartphone phone;

        [SetUp]
        public void SetUp()
        {
            this.shop = new Shop(2);
            this.phone = new Smartphone("Xiaomi", 4000);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Shop shop = new Shop(10);
            Assert.IsNotNull(shop);
            Assert.AreEqual(10, shop.Capacity);

        }

        [Test]
        public void CtorShouldThrow()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-1);
            }, "Invalid capacity.");
        }

        [Test]
        public void CountShouldReturnProperValue()
        {
            shop.Add(phone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddShouldThrowWhenThePhoneAlreadyExists()
        {
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone);
            }, $"The phone model {phone.ModelName} already exist.");
        }

        [Test]
        public void AddShouldThrowWhenShopFull()
        {
            shop.Add(phone);
            Smartphone phone2 = new Smartphone("A2", 1000);
            Smartphone phone3 = new Smartphone("A3", 3000);

            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone3);
            }, "The shop is full.");

        }

        [Test]
        public void RemoveShouldWork()
        {
            shop.Add(phone);

            shop.Remove("Xiaomi");

            Assert.AreEqual(0, shop.Count); 
        }

        [Test]
        public void RemoveShouldThrow()
        {
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Gosho");
            }, $"The phone model Gosho doesn't exist.");
           
        }

        [Test]
        public void TestPhoneSholdWork()
        {
            shop.Add(phone);
            shop.TestPhone("Xiaomi", 4000);

            Assert.AreEqual(0, phone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneShouldthrowWhenThereIsNoPhone()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Gosho", 100);
            }, "The phone model Gosho doesn't exist.");
        }

        [Test]
        public void TestPhoneShouldthrowWhenNoBattery()
        {
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Xiaomi",50000);
            }, "The phone model Xiaomi is low on batery.");
        }

        [Test]
        public void ChargePhoneShouldWork()
        {
            shop.Add(phone);
            shop.TestPhone("Xiaomi",2000);
            shop.ChargePhone("Xiaomi");

            Assert.AreEqual(4000, phone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneShouldthrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(phone.ModelName);
            }, $"The phone model {phone.ModelName} doesn't exist.");
        }

    }
}