using Chainblock.Enum;
using Chainblock.Models;
using Chainblock.Models.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Tests;

[TestFixture]
public class TransactionTests
{

    [Test]
    public void CtorShouldInitializeTransProperly()
    {
        ITransaction tr = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", 100);

        Assert.IsNotNull(tr);

    }

    [TestCase(1)]
    [TestCase(5)]
    [TestCase(1001)]
    public void ConstructorShouldInitializeProperId(int id)
    {
        int exId = id;

        ITransaction tr = new Transaction(exId, TransactionStatus.Successfull, "Gosho", "Pesho", 100);

        Assert.AreEqual(exId, tr.Id);
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-100)]
    public void IdSetterShouldThrowWithIdZeroOrNegative(int id)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ITransaction tr = new Transaction(id, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
        }, "Id can't be zero or negative number");

    }

    [TestCase(TransactionStatus.Successfull)]
    [TestCase(TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised)]
    public void ConstructorShouldInitializeproperStatus(TransactionStatus status)
    {
        var exStatus = status;

        ITransaction tr = new Transaction(1, status, "Gosho", "Pesho", 100);

        Assert.That(exStatus, Is.EqualTo(tr.Status));
    }

    [TestCase("Gosho")]
    [TestCase("G")]
    [TestCase("G g g g osho")]
    public void ConstructorShouldInitializeProperSender(string sender)
    {
        string exSender = sender;

        ITransaction tr = new Transaction(1, TransactionStatus.Successfull, sender, "Pesho", 100);

        Assert.That(exSender, Is.EqualTo(tr.From));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("      ")]
    public void SetterShouldThrowWhenSenderIsNullOrWhitespace(string sender)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ITransaction tr = new Transaction(1, TransactionStatus.Successfull, sender, "Pesho", 100);

        }, "Name cannot be null or whitespace!");
        
    }

    [TestCase("Gosho")]
    [TestCase("G")]
    [TestCase("G g g g osho")]
    public void ConstructorShouldInitializeProperReceiver(string receiver)
    {
        string exSender = receiver;

        ITransaction tr = new Transaction(1, TransactionStatus.Successfull, "Pesho", receiver, 100);

        Assert.That(exSender, Is.EqualTo(tr.To));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("      ")]
    public void SetterShouldThrowWhenReceiverIsNullOrWhitespace(string receiver)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ITransaction tr = new Transaction(1, TransactionStatus.Successfull, "Pesho", receiver, 100);

        }, "Name cannot be null or whitespace!");

    }

    [TestCase(1)]
    [TestCase(100)]
    [TestCase(10000)]
    public void ConstructorShouldInitializeProperAmount(decimal amount)
    {
        decimal exAmount = amount;

        ITransaction tr = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", amount);

        Assert.AreEqual(exAmount, tr.Amount);

    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-1000)]
    public void SetterShouldThrowWhenAmountIsZeroOrNegative(decimal amount)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            ITransaction tr = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", amount);

        }, "Amount can't be 0 or negative!");
    }

}
