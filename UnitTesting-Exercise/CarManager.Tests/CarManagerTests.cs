namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Security.Cryptography.X509Certificates;

    [TestFixture]
    public class CarManagerTests
    {

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void CtorShouldSetProperMake()
        {
            string exMake = "Volvo";

            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            string actMake = car.Make;

            Assert.AreEqual(exMake, actMake);
        }

        [Test]
        public void CtorSholdSetProperModel()
        {
            string exModel = "xc60";

            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            string actModel = car.Model;

            Assert.AreEqual(exModel, actModel);
        }

        [Test]
        public void CtorSholdSetProperFuelConsulmption()
        {
            double exConsump = 8.0;

            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            double actConsump = car.FuelConsumption;

            Assert.AreEqual(exConsump, actConsump);
        }

        [Test]
        public void CtorShouldSetProperFuelCapacity()
        {
            double exCapacity = 70.0;

            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            double actCapacity = car.FuelCapacity;

            Assert.AreEqual(exCapacity, actCapacity);
        }

        [Test]
        public void CtorShouldInitializeProperFuelAmount()
        {
            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("Volvo")]
        [TestCase("V")]
        [TestCase("V V V V Volvo")]
        public void SetterShouldSetValidMake(string make)
        {
            Car car = new Car(make, "xc60", 8.0, 70.0);

            string exMake = make;

            Assert.AreEqual(exMake, car.Make);
        }

        [TestCase(null)]
        [TestCase("")]
        public void SetterShouldThrowWhenMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "xc60", 8.0, 70.0);

            }, "Make cannot be null or empty!");
        }

        [TestCase("xc60")]
        [TestCase("x")]
        [TestCase("x x x x x x xc60")]
        public void SetterShouldSetValidModel(string model)
        {
            Car car = new Car("Volvo", model, 8.0, 70.0);

            string exModel = model;

            Assert.AreEqual(exModel, car.Model);
        }

        [TestCase(null)]
        [TestCase("")]
        public void SetterShouldThrowWhenModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Volvo", model, 8.0, 70.0);

            }, "Make cannot be null or empty!");
        }

        [TestCase(1)]
        [TestCase(10.0)]
        [TestCase(100.0)]
        public void SetterShouldSetValidFuelConsumption(double consumption)
        {
            Car car = new("Volvo", "xc60", consumption, 70.0);

            double exConsump = consumption;

            Assert.AreEqual(exConsump, car.FuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-1.0)]
        [TestCase(-100.0)]
        public void SetterShouldThrowWhenFuelConsumptionIs0orBelow(double consumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new("Volvo", "xc60", consumption, 70.0);

            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(1)]
        [TestCase(10.0)]
        [TestCase(100.0)]
        public void SetterShouldSetValidFuelCapacity(double capacity)
        {
            Car car = new("Volvo", "xc60", 8.0, capacity);

            double exCapacity = capacity;

            Assert.AreEqual(exCapacity, car.FuelCapacity);
        }

        [TestCase(-1.0)]
        [TestCase(-100.0)]
        public void SetterShouldThrowWhenFuelCapacityIsLessThanZero(double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new("Volvo", "xc60", 8.0, capacity);

            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase (1.0)]
        [TestCase (69.0)]
        [TestCase (70)]
        public void RefuelShouldAddAmountToTheTank(double amount)
        {
            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            double exAmount = amount;

            car.Refuel(amount);

            Assert.AreEqual(exAmount, car.FuelAmount);

        }

        [TestCase(71.0)]
        [TestCase(150)]
        public void RefuelShouldSetAmountToTheTankMaximumCapacityIfItsRefueltForMore(double amount)
        {
            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            double exAmout = 70.0;

            car.Refuel(amount);

            Assert.AreEqual(exAmout, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void RefuelShouldThrowIfTheAmountIs0orLEss(double amount)
        {
            Car car = new Car("Volvo", "xc60", 8.0, 70.0);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(amount);

            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void DriveShoudReduceFuelAmountIfItsCompleated()
        {
            Car car = new Car("Volvo", "xc60", 8.0, 80.0);

            car.Refuel(80.0);

            double exFuelCapacity = 72.0;

            car.Drive(100);

            Assert.AreEqual(exFuelCapacity, car.FuelAmount);

        }

        [TestCase (10)]
        [TestCase (80)]
        [TestCase (50)]
        public void DriveShouldThrowWhenFuelNeededIsMoreThenFuelAmount(double amount)
        {
            Car car = new Car("Volvo", "xc60", 8.0, 80.0);

            car.Refuel(amount);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(10000);
            }, "You don't have enough fuel to drive!");
        }







    }
}