namespace Lab5;

public class Pin
{
    public string Value { get; } 
    
    public Pin(string value)
    {
        if (!IsValid(value))
            throw new ArgumentException("The pin value is invalid");
        Value = value;
    }

    public static bool IsValid(string pin)
    {
        return !string.IsNullOrEmpty(pin) && 
               pin.Length == 4 &&
               IsContainOnlyDigits(pin);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Pin other)
            return false;
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }

    private static bool IsContainOnlyDigits(string pin)
    {
        return pin.All(char.IsDigit);
    }
}