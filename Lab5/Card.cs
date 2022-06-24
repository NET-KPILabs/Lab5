namespace Lab5;

public class Card
{
    public Pin PinCode { get; set; }

    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be less than 0");
            _balance = value;
        }
    }

    public decimal Limit
    {
        get => _limit;
        set
        {
            if (value < 0)
                throw new ArgumentException("Limit cannot be less than 0");
            _limit = value;
        }
    }

    private decimal _balance;
    private decimal _limit;
}