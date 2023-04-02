using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;
        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("Spartak", 16);

        }

        [Test]
        public void CtorShouldWork()
        {

            Assert.That(team.Name, Is.EqualTo("Spartak"));
            Assert.That(team.Capacity, Is.EqualTo(16));
            Assert.IsNotNull(team.Players);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowWhenISNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(name, 16);

            }, "Name cannot be null or empty!");
        }

        [TestCase(10)]
        [TestCase(14)]
        public void CapacityShouldThrowWhenIsLessThan15(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("Spartak", capacity);

            }, "Name cannot be null or empty!");
        }

        [Test]
        public void AddNewPlayerShoultWork()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 10, "Goalkeeper");
            FootballTeam team = new FootballTeam("Spartak", 16);
            team.Players.Add(player);

            Assert.AreEqual(1, team.Players.Count);

        }

        [Test]
        public void AddNewPlayerShouldThwoWhenWhenCountIsEqualOrBiggerThanCapacity()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 10, "Goalkeeper");
            FootballTeam team = new FootballTeam("Spartak", 16);

            for (int i = 0; i < 16; i++)
            {
                team.Players.Add(new FootballPlayer("Gosho", i + 2, "Goalkeeper"));
            }

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(player));

        }

        [Test]
        public void AddNewPlayerShouldWork()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 10, "Goalkeeper");

            for (int i = 0; i < 15; i++)
            {
                team.Players.Add(new FootballPlayer("Gosho", i + 2, "Goalkeeper"));
            }

            Assert.AreEqual("Added player Gosho in position Goalkeeper with number 10", team.AddNewPlayer(player));

        }

        [Test]
        public void PickupPlayerShouldWork()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 10, "Goalkeeper");
            FootballTeam team = new FootballTeam("Spartak", 16);
            team.AddNewPlayer(player);
            FootballPlayer player1 = team.PickPlayer("Gosho");

            Assert.That(player1, Is.EqualTo(player));
        }

        [Test]
        public void PickupPlayerShouldReturnNull()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 10, "Goalkeeper");
            FootballTeam team = new FootballTeam("Spartak", 16);
            team.AddNewPlayer(player);
            FootballPlayer player1 = team.PickPlayer("Pesho");

            Assert.AreEqual(player1, null);
        }

        [Test]
        public void PlayerScoreShouldWork()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 10, "Goalkeeper");
            player.Score();

            Assert.AreEqual(1, player.ScoredGoals);

        }

        [Test]
        public void PlayerScoreShoudReturnProperSting()
        {
            FootballPlayer player = new FootballPlayer("Gosho", 10, "Goalkeeper");
            team.AddNewPlayer(player);

            string actual = team.PlayerScore(10);

            Assert.AreEqual("Gosho scored and now has 1 for this season!", actual);
        }






    }
}