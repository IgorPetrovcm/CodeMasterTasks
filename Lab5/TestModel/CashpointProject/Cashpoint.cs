namespace CashpointProject.Models;


public sealed class Cashpoint
{
    private readonly List<uint> banknotes = new List<uint>();

    private uint total;

    public uint Total { get { return total; }}

    public void AddBanknote(uint value)
    {
        banknotes.Add(value);

        total += value;
    }

    public void RemoveBanknote(uint value)
    {
        if (banknotes.Remove(value))
        {
            total -= value;
        }
    }
}