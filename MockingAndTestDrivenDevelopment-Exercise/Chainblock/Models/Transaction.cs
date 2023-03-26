using Chainblock.Enum;
using Chainblock.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Models;

public class Transaction : ITransaction
{
    private int id;
    private string from;
    private string to;
    private decimal amount;

    public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
    {
        Id = id;
        Status = status;
        From = from;
        To = to;
        Amount = amount;
    }

    public int Id
    {
        get => id;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Id can't be zero or negative number");
            }
            id = value;
        }
    }
    public TransactionStatus Status { get; set; }
    public string From
    {
        get => from;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            from = value;
        }
    }
    public string To
    {
        get => to;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            to = value;
        }
    }
    public decimal Amount
    {
        get => amount;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Amount can't be 0 or negative!");
            }

            amount = value;
        }
    }
}
