namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUP()
        {
            database = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldInitialazeWithCorrctCount(int[] data)
        {
            Database db = new(data);

            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void ConstructorShoudThrowWhenInputDataIsMoreThan16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database (data);

            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddElementsToTheFiled(int[] data)
        {
            Database db = new Database(data);

            int[] expextedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expextedData, actualData);

        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldReturnCorrectCount(int[] data)
        {
            Database db = new(data);

            int expectedCount = data.Length;
            int actrualCont = db.Count;

            Assert.AreEqual(expectedCount, actrualCont);
        }

        [Test]
        public void AddElementShouldIncreaseCont()
        {
            int expectedCount = 3;

            for (int i = 1; i <= expectedCount; i++)
            {
                this.database.Add(i);
            }

            int actrualCount = database.Count;

            Assert.AreEqual(expectedCount , actrualCount);
        }

        [Test]
        public void AddElementShouldBeAddedToTheCollection()
        {
            int[] expectetData = new int[5];

            for (int i = 1; i <= 5; i++)
            {
                database.Add(i);
                expectetData[i - 1] = i;
            }

            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectetData, actualData);
        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowEx()
        {
            for (int i = 1; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemoveingElementFromEmptyCollectionShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveingElementFromTheCollectionShouldDecreaseItsCount(int[] data)
        {
            database = new Database(data);
            database.Remove();

            Assert.AreEqual(data.Length - 1, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveingElementsFromTheCollectionsShouldRemoveItFromTheDatabaseCollection(int[] data)
        {
            database = new Database(data);

            for (int i = 0; i < 2; i++)
            {
                database.Remove();
            }

            int[] actualData = database.Fetch();
            int[] expectedData = new int[] { 1, 2, 3 };

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCollectionWithElementsInTheDatabase(int[] data)
        {
            database = new Database(data);

            int[] expectedData = data;
            int[] actualData = database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }






    }
}
