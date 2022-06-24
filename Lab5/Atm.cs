using Lab5.Abstract;
using Lab5.Implementation;

namespace Lab5;

public class Atm
{
    public decimal Balance { get; set; }
    public IAtmState AtmState { get; set; }
    public Card CurrentCard { get; set; }
    public Atm()
    {
        AtmState = new NoCardState(this);
    }

    public void InsertCard(Card card)
    {
        if (card is null)
            throw new ArgumentNullException(nameof(card), "Card cannot be null");
        AtmState.InsertCard(card);
    }

    public void InsertPin(Pin pinCode)
    {
        if (pinCode is null)
            throw new ArgumentNullException(nameof(pinCode), "Pin cannot be null");
        AtmState.InsertPin(pinCode);
    }

    public decimal ViewBalance()
    {
        return AtmState.ViewBalance();
    }

    public void WithdrawMoney(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("The amount of money must be greater than zero");
        AtmState.WithdrawMoney(amount);
    }

    public void TopUpMoney(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("The amount of money must be greater than zero");
        AtmState.TopUpMoney(amount);
    }
    
    public void EjectCard()
    {
        AtmState.EjectCard();
        CurrentCard = null!;
    }
}