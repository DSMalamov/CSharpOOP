using Chainblock.Enum;
using Chainblock.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Models;
public class ChainBlock : IChainblock
{
    private Dictionary<int, ITransaction> transactions;

    public ChainBlock()
    {
        transactions= new Dictionary<int, ITransaction>();
    }
    public int Count 
        => transactions.Count;

    public void Add(ITransaction tx)
    {
        if (Contains(tx.Id))
        {
            throw new InvalidOperationException("Cannot add same transaction!");
        }
        transactions.Add(tx.Id, tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new ArgumentException("Non existing Id!");
        }

        transactions[id].Status = newStatus;
    }

    public bool Contains(ITransaction tx)
        => Contains(tx.Id);

    public bool Contains(int id)
        => transactions.ContainsKey(id);

    public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {

        if (!transactions.Any(t => t.Value.Status == status))
        {
            throw new InvalidOperationException("There is not any transaction with given status!");
        }

        IEnumerable<string> senders = transactions
            .Values
            .Where(tx => tx.Status == status)
            .OrderBy(tx => tx.Amount)
            .Select(tx => tx.From);

        return senders;
    }

    public ITransaction GetById(int id)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new InvalidOperationException("Transaction doesn't exist!");
        }
        return transactions[id];
    }

    public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!transactions.Any(t => t.Value.Status == status))
        {
            throw new InvalidOperationException("There is not any transaction with given status!");
        }

        IEnumerable<ITransaction> result = transactions.Values
            .Where(tx => tx.Status == status)
            .OrderByDescending(t => t.Amount);
        

        return result;
    }

    public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        throw new NotImplementedException();
    }

    public void RemoveTransactionById(int id)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new InvalidOperationException("Id doesn't exist!");
        }

        transactions.Remove(id);
    }
}

