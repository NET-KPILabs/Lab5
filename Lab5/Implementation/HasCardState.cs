using Lab5.Abstract;

namespace Lab5.Implementation;

public class HasCardState : IAtmState
{
    private readonly Atm _atm;

    public HasCardState(Atm atm)
    {
        _atm = atm;
    }

    public void InsertCard(Card card)
    {
        throw new InvalidOperationException("You can only insert one card at a time");
    }

    public void InsertPin(Pin pinCode)
    {
        if (!_atm.CurrentCard.PinCode.Equals(pinCode))
            throw new InvalidOperationException("You entered the wrong PIN");
        _atm.AtmState = new HasPinState(_atm);
    }

    public decimal ViewBalance()
    {
        throw new InvalidOperationException("You have not entered your PIN");
    }

    public void WithdrawMoney(decimal amount)
    {
        throw new InvalidOperationException("You have not entered your PIN");
    }

    public void TopUpMoney(decimal amount)
    {
        throw new InvalidOperationException("You have not entered your PIN");
    }

    public void EjectCard()
    {
        _atm.AtmState = new NoCardState(_atm);
    }
}