namespace CashpointProject.Models
{
	public sealed class Cashpoint
	{
	    private readonly Dictionary <uint, byte> banknotes = new Dictionary <uint, byte>();

		private uint total;

		private List<uint> granted = new List<uint>();

		private uint count;

		public uint Count { get { return count; } }

	    public uint Total { get { return total; }}


	    public bool AddBanknote(uint value)
	    {
	        if (!banknotes.ContainsKey(value))
			{
				banknotes.Add(value, 1);
			}
			else
			{
				banknotes[value]++;
			}

	        total += value;

			count++;

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
			if (!banknotes.ContainsKey(value))
			{
				return false;
			}
			else
			{
				banknotes[value]--;

				total -= value;

				count--;
			}

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

			if (granted.Count != count)
			{
				granted = new List<uint>();

				Dictionary<uint, byte> sortedBanknotes = banknotes.OrderByDescending(x => x.Key).ToDictionary();

				foreach (uint key in sortedBanknotes.Keys)
				{
					for (byte i = 0; i < sortedBanknotes[key]; i++)
					{
						granted.Add(key);
					}
				}
			}

			for (int i = 0; i <  granted.Count; i++)
			{
				if (granted[i] <= value)
				{
					value -= granted[i];

					if (value == 0)
						return true;
				}
			}

			if (value == 0)
				return true;

			return false;
		}
	}
}