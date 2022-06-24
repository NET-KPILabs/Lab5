using Lab5;

try
{
    var card = new Card()
    {
        Balance = 10000,
        Limit = 5000,
        PinCode = new Pin("0451")
    };

    var atm = new Atm()
    {
        Balance = 7500
    };

    Console.WriteLine($"Existing card: balance - {card.Balance} limit - {card.Limit} pin - {card.PinCode}");
    UserInteraction.Print();
    UserInteraction.Menu(atm, card);
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}
