namespace CashpointProject.Models;


public sealed class Cashpoint
{
    private readonly List<uint> banknotes = new List<uint>();

    private uint total;

	private bool[] granted = { true };

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

	public bool CanGrant(uint value)
	{
		CalculateGrants();

		if (value > total)
		{
			return false;
		}

		return granted[(int)value];
	}

	private void CalculateGrants()
	{
		granted = new bool[total + 1];
		granted[0] = true;

		foreach (uint b in banknotes)
		{
			for (int i = (int)total; i >= 0; i--)
			{
				if (granted[i])
				{
					granted[i + b] = true;
				}
			}
		}
	}
}