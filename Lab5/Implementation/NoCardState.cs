using Lab5.Abstract;

namespace Lab5.Implementation;

public class NoCardState : IAtmState
{
    private readonly Atm _atm;

    public NoCardState(Atm atm)
    {
        _atm = atm;
    }

    public void InsertCard(Card card)
    {
        _atm.CurrentCard = card;
        _atm.AtmState = new HasCardState(_atm);
    }

    public void InsertPin(Pin pinCode)
    {
        throw new InvalidOperationException("You have not entered your card");
    }

    public decimal ViewBalance()
    {
        throw new InvalidOperationException("You have not entered your card");
    }

    public void WithdrawMoney(decimal amount)
    {
        throw new InvalidOperationException("You have not entered your card");
    }

    public void TopUpMoney(decimal amount)
    {
        throw new InvalidOperationException("You have not entered your card");
    }

    public void EjectCard()
    {
        throw new InvalidOperationException("You didn't enter a card");
    }
}