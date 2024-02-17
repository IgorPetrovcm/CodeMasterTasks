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

		SetGrant(value);
    }

    public void RemoveBanknote(uint value)
    {
        if (banknotes.Remove(value))
        {
            total -= value;

			CalculateGrants();
        }
    }

	public bool CanGrant(uint value)
	{
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

	private void SetGrant(uint banknote)
	{
		Array.Resize(ref granted,(int)total + 1);

		for (int i = (int)total; i >= 0; i--)
		{
			if (granted[i])
			{
				granted[i + banknote] = true;
			}
		}
	}
}