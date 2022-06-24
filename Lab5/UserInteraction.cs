namespace Lab5;

public static class UserInteraction
{
    public static void Print()
    {
        Console.WriteLine
        (
            "1. Insert card\n" +
            "2. Insert pin\n" +
            "3. View balance\n" +
            "4. Withdraw money\n" +
            "5. Top up money\n" +
            "6. Eject card\n" +
            "7. Exit"
        );
    }

    public static void Menu(Atm atm, Card card)
    {
        try
        {
            int choice;
            Console.Write("Enter your choice: ");
            while (true)
            {
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        atm.InsertCard(card);
                        Console.WriteLine("Card is successfully inserted");
                        break;
                    case 2:
                        Console.Write("Enter pin to the existing card: ");
                        var pin = Console.ReadLine();
                        while (!Pin.IsValid(pin))
                        {
                            Console.Write("Enter pin in correct format: ");
                            pin = Console.ReadLine();
                        }
                        atm.InsertPin(new Pin(pin));
                        Console.WriteLine("Pin is successfully inserted");
                        break;
                    case 3:
                        Console.WriteLine($"Balance: {atm.ViewBalance()}");
                        break;
                    case 4:
                        Console.Write("Enter amount of money to withdraw: ");
                        decimal withdrawAmount;
                        while (!decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            Console.Write("\nEnter correct value: ");
                        }
                        atm.WithdrawMoney(withdrawAmount);
                        Console.WriteLine($"Balance after withdrawing: {atm.CurrentCard.Balance}");
                        break;
                    case 5:
                        Console.Write("Enter amount of money to top up: ");
                        decimal topUpAmount;
                        while (!decimal.TryParse(Console.ReadLine(), out topUpAmount))
                        {
                            Console.Write("\nEnter correct value: ");
                        }
                        atm.TopUpMoney(topUpAmount);
                        Console.WriteLine($"Balance after top upping: {atm.CurrentCard.Balance}");
                        break;
                    case 6:
                        atm.EjectCard();
                        Console.WriteLine("Card is ejected");
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
                Console.Write("\nEnter your choice: ");
            }       
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Menu(atm, card);
        }
    }
}