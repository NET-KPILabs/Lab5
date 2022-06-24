using Lab5.Abstract;

namespace Lab5.Implementation;

public class HasPinState : IAtmState
{
    private readonly Atm _atm;

    public HasPinState(Atm atm)
    {
        _atm = atm;
    }

    public void InsertCard(Card card)
    {
        throw new InvalidOperationException("You already entered a card");
    }

    public void InsertPin(Pin pinCode)
    {
        throw new InvalidOperationException("You already entered a PIN");
    }

    public decimal ViewBalance()
    {
        return _atm.CurrentCard.Balance;
    }

    public void WithdrawMoney(decimal amount)
    {
        if (amount > _atm.Balance)
            throw new InvalidOperationException("There is not enough money in the ATM");
        else if (amount > _atm.CurrentCard.Limit)
            throw new InvalidOperationException("Withdrawal limit exceeded");

        _atm.Balance -= amount;
        _atm.CurrentCard.Balance -= amount;
        _atm.CurrentCard.Limit -= amount;
        if (_atm.Balance <= 0)
            _atm.AtmState = new NoCashInAtmState(_atm);
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