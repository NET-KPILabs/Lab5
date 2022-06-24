using Lab5.Abstract;

namespace Lab5.Implementation;

public class NoCashInAtmState : IAtmState
{
    private readonly Atm _atm;

    public NoCashInAtmState(Atm atm)
    {
        _atm = atm;
    }

    public void InsertCard(Card card)
    {
        throw new InvalidOperationException("The card is already inserted");
    }

    public void InsertPin(Pin pinCode)
    {
        throw new InvalidOperationException("The pin is already entered");
    }

    public decimal ViewBalance()
    {
        return _atm.CurrentCard.Balance;
    }

    public void WithdrawMoney(decimal amount)
    {
        throw new InvalidOperationException("There's no money in the ATM");
    }

    public void TopUpMoney(decimal amount)
    {
        _atm.Balance += amount;
        _atm.CurrentCard.Balance += amount;
    }

    public void EjectCard()
    {
        _atm.AtmState = new NoCardState(_atm);
    }
}