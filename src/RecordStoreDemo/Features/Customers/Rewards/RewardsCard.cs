﻿namespace RecordStoreDemo.Features.Customers.Rewards;
public class RewardsCard : BaseEntity
{
    public RewardsCard()
    {
        Number = string.Empty;
    }
    public RewardsCard(string number) 
    {
        Number = number;
        Points = 0;
    }
    public string Number { get; private set; }
    public int Points { get; private set; }

    private readonly List<RewardsTransaction> _transactions = [];
    public virtual ICollection<RewardsTransaction> Transactions => _transactions.AsReadOnly();

    /// <summary>
    /// Sets the Number of the Rewards Card.
    /// </summary>
    public void SetCardNumber(string number)
    {
        Number = Guard.Against.InvalidCardNumber(number, nameof(Number));
    }

    /// <summary>
    /// Records a positive or negative change in Rewards Points.
    /// </summary>
    public RewardsTransaction AddTransaction(string cardNumber, int pointsChange)
    {
        if (cardNumber != Number)
        {
            throw new InvalidOperationException("Card Numbers do not match.");
        }

        var transaction = new RewardsTransaction(pointsChange);
        _transactions.Add(transaction);
        Points += pointsChange;

        return transaction;
    }
}