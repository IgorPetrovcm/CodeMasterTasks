namespace CashpointProject.Models;


public sealed class Cashpoint
{
    private readonly List<uint> banknotes = new List<uint>();

    private uint total;

	private bool[] granted = { true };

	private uint count;

	public uint Count { get { return count; } }

    public uint Total { get { return total; }}


    public bool AddBanknote(uint value)
    {
        banknotes.Add(value);

        total += value;

		count++;

		SetGrant(value);

		return true;
    }

	public bool AddBanknote(uint countAddedBanknotes, uint value)
	{
		for (int i = 0; i < countAddedBanknotes; i++)
		{
			AddBanknote(value);
		}

		return true;
	}

    public bool RemoveBanknote(uint value)
    {
		if (banknotes.Remove(value))
		{
			total -= value;

			count--;

			CalculateGrants();
		}
		else
			return false;

		return true;
    }
	public bool RemoveBanknote(uint countRemovedBanknotes,uint value)
	{
		for (int i = 0; i < countRemovedBanknotes; i++)
		{
			if (!RemoveBanknote(value))
				return false;
		}
		return true;
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