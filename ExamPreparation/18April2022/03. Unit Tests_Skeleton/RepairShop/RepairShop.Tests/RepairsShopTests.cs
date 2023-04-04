using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]
            public void GarageCtorShouldWork()
            {
                Garage garage = new Garage("Gosho", 4);

                Assert.AreEqual("Gosho", garage.Name);
                Assert.AreEqual(4, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [TestCase(null)]
            [TestCase("")]
            public void GarageNameShouldThrow(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 4);

                }, "Invalid garage name.");
            }

            [TestCase(0)]
            [TestCase(-10)]
            public void GarageNameShouldThrow(int num)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("Ggsgsg", num);

                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void CounterOfCarsShouldWork()
            {
                Garage garage = new Garage("Gosho", 4);
                Car car1 = new Car("Skoda", 2);
                Car car2 = new Car("Dacia", 1);
                garage.AddCar(car1);
                garage.AddCar(car2);

                int expCount = 2;
                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void AddCarShouldThrow()
            {
                Garage garage = new Garage("Gosho", 1);
                Car car1 = new Car("Skoda", 2);
                Car car2 = new Car("Dacia", 1);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car2);

                }, "No mechanic available.");
            }

            [Test]
            public void CarFixShouldWork()
            {
                Garage garage = new Garage("Gosho", 4);
                Car car1 = new Car("Skoda", 2);
                Car car2 = new Car("Dacia", 1);
                garage.AddCar(car1);

                garage.FixCar("Skoda");
                Assert.AreEqual(0, car1.NumberOfIssues);
            }

            [Test]
            public void CarFixShouldThrow()
            {
                Garage garage = new Garage("Gosho", 4);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Lada");
                }, $"The car Lada doesn't exist.");
            }

            [Test]
            public void RemoveFixedCArShouldWork()
            {
                Garage garage = new Garage("Gosho", 4);
                Car car1 = new Car("Skoda", 0);
                Car car2 = new Car("Dacia", 0);
                garage.AddCar(car1);
                garage.AddCar(car2);

                garage.RemoveFixedCar();

                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void RemoveFixedCArShouldThrow()
            {
                Garage garage = new Garage("Gosho", 4);
                Car car1 = new Car("Skoda", 2);
                Car car2 = new Car("Dacia", 5);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();

                }, "No fixed cars available.");
            }

            [Test]
            public void ReportShouldWork()
            {
                Garage garage = new Garage("Gosho", 4);
                Car car1 = new Car("Skoda", 2);
                Car car2 = new Car("Dacia", 5);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.AreEqual("There are 2 which are not fixed: Skoda, Dacia.", garage.Report());
            }



        }
    }
}