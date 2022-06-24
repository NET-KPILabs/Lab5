namespace Lab5.Abstract;

public interface IAtmState
{
    void InsertCard(Card card);
    void InsertPin(Pin pinCode);
    decimal ViewBalance();
    void WithdrawMoney(decimal amount);
    void TopUpMoney(decimal amount);
    void EjectCard();
}