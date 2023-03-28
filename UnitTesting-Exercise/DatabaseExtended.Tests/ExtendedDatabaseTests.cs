namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUP()
        {
            database = new Database();
        }

        [Test]
        public void AddMethodTest()
        {
            database.Add(new Person(1, "Pesho"));
            Person result = database.FindById(1);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, database.Count);
            Assert.AreEqual("Pesho", result.UserName);
        }
        
        [Test]
        public void AddShouldThrowIsMoreThanMaximumLength()
        {
            Person[] people = CrateFullArray();
            database = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "Pesho"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        private Person[] CrateFullArray()
        {
            Person[] result = new Person[16];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Person(i, i.ToString());

            }

            return result;
        }

        [Test]
        public void AddShouldThrowIfNotUniqueUsername()
        {
            database.Add(new Person(1, "Pesho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(2, "Pesho"));

            }, "There is already user with this username!");
        }

        [Test]
        public void AddShouldThrowIfNotUniqueId()
        {
            database.Add(new Person(1, "Pesho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1, "Gosho"));

            }, "There is already user with this Id!");
        }

        [Test]
        public void ConstructorShouldInitialazeWithCorrctCount()
        {
            database.Add(new Person(1, "Pesho"));
            database.Add(new Person(2, "Gosho"));

            //int expectedCount = data.Length;
            //int actualCount = database.Count;
            Person first = database.FindById(1);
            Person second = database.FindById(2);

            Assert.AreEqual("Pesho", first.UserName);
            Assert.AreEqual("Gosho", second.UserName);
            Assert.AreEqual(2, database.Count);
        }

        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        //public void ConstructorShoudThrowWhenInputDataIsMoreThan16(int[] data)
        //{
        //    Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        Database db = new Database(data);

        //    }, "Array's capacity must be exactly 16 integers!");
        //}

        //[TestCase(new int[] { })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5 })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        //public void ConstructorShouldAddElementsToTheFiled(int[] data)
        //{
        //    Database db = new Database(data);

        //    int[] expextedData = data;
        //    int[] actualData = db.Fetch();

        //    CollectionAssert.AreEqual(expextedData, actualData);

        //}

        //[TestCase(new int[] { })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5 })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        //public void ConstructorShouldReturnCorrectCount(int[] data)
        //{
        //    Database db = new(data);

        //    int expectedCount = data.Length;
        //    int actrualCont = db.Count;

        //    Assert.AreEqual(expectedCount, actrualCont);
        //}

        //[Test]
        //public void AddElementShouldIncreaseCont()
        //{
        //    int expectedCount = 3;

        //    for (int i = 1; i <= expectedCount; i++)
        //    {
        //        this.database.Add(i);
        //    }

        //    int actrualCount = database.Count;

        //    Assert.AreEqual(expectedCount, actrualCount);
        //}

        //[Test]
        //public void AddElementShouldBeAddedToTheCollection()
        //{
        //    int[] expectetData = new int[5];

        //    for (int i = 1; i <= 5; i++)
        //    {
        //        database.Add(i);
        //        expectetData[i - 1] = i;
        //    }

        //    int[] actualData = this.database.Fetch();

        //    CollectionAssert.AreEqual(expectetData, actualData);
        //}

        //[Test]
        //public void AddingMoreThan16ElementsShouldThrowEx()
        //{
        //    for (int i = 1; i <= 16; i++)
        //    {
        //        database.Add(i);
        //    }

        //    Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        database.Add(17);
        //    }, "Array's capacity must be exactly 16 integers!");
        //}

        [Test]
        public void RemoveingElementFromEmptyCollectionShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();

            });
        }

        [Test]
        public void RemoveingElementsFromTheCollectionsShouldRemoveItFromTheDatabaseCollection()
        {
            database.Add(new Person(1, "Pesho"));
            database.Add(new Person(2, "Gosho"));
            Person first = database.FindById(1);
            database.Remove();

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual("Pesho", first.UserName);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Gosho");
            }, "No user is present by this username!");

        }

        [Test]
        public void FindByUsernameShouldThrowIfUsernameNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            }, "Username parameter is null!");

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(string.Empty);
            }, "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameShouldThrowIfUsernameDoesNotExsist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Gosho");
            }, "No user is present by this username!");
        }

        [Test]
        public void FindByUserNameReturnsCorrectUser()
        {
            database.Add(new Person(1, "Pesho"));
            database.Add(new Person(2, "Gosho"));
            Person person= database.FindByUsername("Pesho");

            Assert.AreEqual("Pesho", person.UserName);
            Assert.AreEqual(1, person.Id);
        }

        [Test]
        public void FindByIDShouldThrowIfIdDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(1);
            }, "No user is present by this ID!");

        }

        [Test]
        public void FindByIDShouldThrowIfIdIsLessThan0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            }, "Id should be a positive number!");
        }

        [Test]
        public void FindByIDReturnsCorrectUser()
        {
            database.Add(new Person(1, "Pesho"));
            database.Add(new Person(2, "Gosho"));
            Person person = database.FindById(1);

            Assert.AreEqual("Pesho", person.UserName);
            Assert.AreEqual(1, person.Id);
        }



    }
}