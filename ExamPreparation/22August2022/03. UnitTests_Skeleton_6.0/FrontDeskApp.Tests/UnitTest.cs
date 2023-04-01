using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Azalia", 4);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void ConstructorShouldWork()
        {
            Hotel hotel = new Hotel("Azalia", 4);

            Assert.That(hotel.FullName, Is.EqualTo("Azalia"));
            Assert.That(hotel.Category, Is.EqualTo(4));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public void HotelWithWrongNameSholdThrow(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(name, 4);
            });
        }

        [TestCase(0)]
        [TestCase(6)]
        [TestCase(-2)]
        public void HotelWithWrongCatShouldThrow(int cat)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Azalia", cat);
            });
        }

        [Test]
        public void AddRoomMethodShouldWork()
        {
            Room room = new Room(2, 100);

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void TurnoverCheck()
        {
            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomShouldThrowWhenAdultsAreLessThan1()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(0, 2, 2, 1001);
            });
        }
        [Test]
        public void BookRoomShouldThrowWhenChiledrenAreLessThan0()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, -1, 2, 1001);
            });
        }

        [Test]
        public void BookRoomShouldThrowWhenDurationIsLessThan1()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, 1, 0, 1001);
            });
        }

        [Test]
        public void BookRoomNoTurnoverWhenNotEnoughBeds()
        {
            Room room = new Room(3, 100);

            hotel.AddRoom(room);
            hotel.BookRoom(4, 1, 2, 200);

            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomNoBookingWhenBudgetTooLow()
        {
            Room room = new(5, 70);
            hotel.AddRoom(room);

            hotel.BookRoom(4, 1, 2, 100);

            double expectedTurnover = 0;

            Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void BookRoomBooksRoomProperly()
        {
            Room room = new(5, 70);

            hotel.AddRoom(room);
            hotel.BookRoom(4, 1, 2, 150);

            double expectedTurnover = 140;

            Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }


    }
}