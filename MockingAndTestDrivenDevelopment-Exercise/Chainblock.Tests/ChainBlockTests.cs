using Chainblock.Enum;
using Chainblock.Models;
using Chainblock.Models.Interface;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chainblock.Tests;

public class ChainBlockTests
{
    private IChainblock cb;
    private ITransaction tx;

    [SetUp]
    public void Setup()
    {
        cb = new ChainBlock();
        tx = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
    }

    [Test]
    public void ConstructorShouldInitializeProperlyChainblock()
    {
        Type chainblockType = cb.GetType();

        FieldInfo transactionField = chainblockType
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(t => t.Name == "transactions");

        IDictionary<int, ITransaction> value = transactionField.GetValue(cb) as Dictionary<int, ITransaction>;

        Assert.IsNotNull(value);
    }

    [Test]
    public void AddShouldAppendTransactionToCollectionData()
    {
        cb.Add(tx);

        bool iSTransactionAdded = cb.Contains(tx.Id);

        Assert.IsTrue(iSTransactionAdded);
    }

    [Test]
    public void AddShouldIncreaseCount()
    {
        int exCount = 1;
        cb.Add(tx);

        Assert.That(cb.Count, Is.EqualTo(exCount));
    }

    [Test]
    public void AddShouldThrowExceptionWhenSameTransactionIsAdded()
    {
        cb.Add(tx);

        Assert.Throws<InvalidOperationException>(() => cb.Add(tx), "Cannot add same transaction!");
    }

    [Test]
    public void AddShouldThrowExceptionWhenTransactionWithSameIdIsAdded()
    {
        cb.Add(tx);

        ITransaction tx2 = new Transaction(1, TransactionStatus.Aborted, "lllll", "mmmm", 1001);

        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.Add(tx2);

        }, "Cannot add same transaction!");

    }

    [Test]
    public void ContainsShouldReturnTrueIfTransactionIdExists()
    {
        cb.Add(tx);

        bool transactionExists = cb.Contains(tx.Id);

        Assert.IsTrue(transactionExists);
    }

    [Test]
    public void ContainsShouldReturnFalseIfTransactionIdDoesntExists()
    {

        bool transactionExists = cb.Contains(tx.Id);

        Assert.IsFalse(transactionExists);
    }

    [Test]
    public void ContainsShouldReturnTrueIfTransactionExists()
    {
        cb.Add(tx);

        bool transactionExists = cb.Contains(tx);

        Assert.IsTrue(transactionExists);
    }

    [Test]
    public void ContainsShouldReturnFalseIfTransactionDoesntExists()
    {

        bool transactionExists = cb.Contains(tx);

        Assert.IsFalse(transactionExists);
    }

    [Test]
    public void CountShouldReturnCorrectTransactionsCount()
    {
        int exCount = 2;

        cb.Add(tx);
        cb.Add(new Transaction(2, TransactionStatus.Aborted, "lllll", "mmmm", 1001));

        Assert.AreEqual(exCount, cb.Count);
    }

    [Test]
    public void CountShouldReturnZeroIfTheCollectionIsEmpty()
    {
        int exCount = 0;

        Assert.AreEqual(0, cb.Count);
    }

    [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Successfull, TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Successfull, TransactionStatus.Unauthorised)]
    public void TransactionStatusShouldBeChangedWhenExist(TransactionStatus from, TransactionStatus to)
    {
        cb.Add(tx);

        cb.ChangeTransactionStatus(tx.Id, to);

        Assert.AreEqual(to, tx.Status);
    }

    [Test]
    public void TransactionStatusChangeShouldThrowIfTheIdDoesntExist()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            cb.ChangeTransactionStatus(tx.Id, TransactionStatus.Aborted);
        }, "Non existing Id!");
    }

    [Test]
    public void TransactionShouldBeRemovedIfIdExists()
    {
        cb.Add(tx);

        cb.RemoveTransactionById(tx.Id);

        bool isRemoved = cb.Contains(tx);

        Assert.IsFalse(isRemoved);
    }

    [Test]
    public void RemovedTransactionShouldReturnProperCount()
    {
        int exCount = 1;
        ITransaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Goshoo", "Peshoo", 10000);
        cb.Add(tx);
        cb.Add(tx2);

        cb.RemoveTransactionById(tx.Id);

        int actCount = cb.Count;

        Assert.AreEqual(exCount, actCount);
    }

    [Test]
    public void RemoveingTransactionShouldThrowIfIdDoesntExist()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.RemoveTransactionById(tx.Id);
        }, "Id doesn't exist!");
    }

    [Test]
    public void ReturnTransactionWithGivvenId()
    {
        cb.Add(tx);

        ITransaction newTx = cb.GetById(tx.Id);

        Assert.AreEqual(tx,newTx);
    }

    [Test]
    public void GetByIdShouldThrowWhenTxDoesntExsits()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.GetById(tx.Id);

        }, "Transaction doesn't exist!");
    }

    [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Failed, TransactionStatus.Unauthorised)]
    public void GetByTransactionStatusShouldReturnOrderedCollection(TransactionStatus status1, TransactionStatus status2)
    {
        IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>() 
        {
         new Transaction(1, status1, "Gosho", "Pesho", 100),
         new Transaction(2, status1, "sss", "dddd", 1000),
         new Transaction(3, status2, "ggg", "eee", 10000)
        };

        foreach (var transaction in transactionsToAppend)
        {
            cb.Add(transaction);
        }

        IEnumerable<ITransaction> expectedTrans = transactionsToAppend
            .Where(tx => tx.Status == status1)
            .OrderByDescending(tx => tx.Amount);

        IEnumerable<ITransaction> actualTransactions = cb
            .GetByTransactionStatus(status1);

        CollectionAssert.AreEqual(expectedTrans, actualTransactions);
    }

    [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Failed, TransactionStatus.Unauthorised)]
    public void GetByTransactionStatusShouldThrowIfThereIsNoTransactionWithGivenStatus(TransactionStatus status1, TransactionStatus status2)
    {
        cb.Add(tx);

        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.GetByTransactionStatus(status2);

        }, "There is not any transaction with given status!");
    }

    [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Failed, TransactionStatus.Unauthorised)]
    public void GetAllSendersByTransactionStatusShouldWork(TransactionStatus status1, TransactionStatus status2)
    {
        IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
        {
         new Transaction(1, status1, "Gosho", "Pesho", 100),
         new Transaction(2, status1, "Gosho", "dddd", 1000),
         new Transaction(3, status2, "ggg", "eee", 10000)
        };

        foreach (var transaction in transactionsToAppend)
        {
            cb.Add(transaction);
        }

        IEnumerable<string> expectedOutput = transactionsToAppend
           .Where(tx => tx.Status == status1)
           .OrderBy(tx => tx.Amount)
           .Select(tx => tx.From)
           .ToArray();

        IEnumerable<string> actualOutput = cb
            .GetAllSendersWithTransactionStatus(status1);

        CollectionAssert.AreEqual(expectedOutput, actualOutput);

    }

    [Test]
    public void GetAllSendersByTransactionStatusShouldThrowWhenTransactionDoesntExist()
    {
        cb.Add(tx);

        Assert.Throws<InvalidOperationException>(() =>
        {
            cb.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted);
        }, "There is not any transaction with given status!");
    }
}