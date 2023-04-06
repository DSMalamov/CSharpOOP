using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository hr;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Gosho", 50);
        hr = new HeroRepository();
    }

    [Test]
    public void HeroCtorShouldWork()
    {

        Assert.AreEqual("Gosho", hero.Name);
        Assert.AreEqual(50, hero.Level);
    }

    [Test]
    public void HRCtorShouldWorkProperly()
    {
        Assert.AreEqual(0, hr.Heroes.Count);
        Assert.IsNotNull(hr.Heroes);
    }

    [Test]
    public void CreateHeroShouldWork()
    {
        string expected = $"Successfully added hero Gosho with level 50";
        Assert.AreEqual(expected, hr.Create(hero));
        Assert.AreEqual(1, hr.Heroes.Count);
    }

    [Test]
    public void CreateHeroShouldThrowNull()
    {
        Hero hero1 = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            hr.Create(hero1);
        }, nameof(hero), "Hero is null");
    }

    [Test]
    public void CreateHeroShouldThrow()
    {
        hr.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            hr.Create(hero);
        }, $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void RemoveShouldWork()
    {
        hr.Create(hero);

        Assert.IsTrue(hr.Remove("Gosho"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("     ")]
    public void RemoveShouldThrow(string name)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            hr.Remove(name);
        }, nameof(name), "Name cannot be null");
    }

    [Test]
    public void GetHeroWithHightestLVLShouldWork()
    {
        hr.Create(hero);
        Hero hero1 = new Hero("Misho", 80);
        hr.Create(hero1);
        Hero result = hr.GetHeroWithHighestLevel();
        
        Assert.AreEqual(result.Name, hero1.Name);
    }

    [Test]
    public void GetHeroShouldWork()
    {
        hr.Create(hero);
        Hero hero1 = new Hero("Misho", 80);
        hr.Create(hero1);

        Assert.AreEqual(hero, hr.GetHero("Gosho"));
    }


}