namespace CashpointProject.Tests
{
	using CashpointProject.Models;

	[TestFixture]
	public class CashpointTests
	{
		[Test]
		public void AddBanknote_SingleBanknote_ShouldIncrementTotal()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.AddBanknote(5);

			Assert.That(
				cashpoint.Total,
				Is.EqualTo(5),
				"Добавление единственной банкноты не было произведено");
		}

		[Test]
		public void AddBanknote_MultiplyBanknote_ShoultIncrementTotal()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.AddBanknote(5);
			cashpoint.AddBanknote(10);

			Assert.That(
				cashpoint.Total,
				Is.EqualTo(15),
				"Добаыление второй банкноты не было произведено");
		}

		[Test]
		public void RemoveBanknote_CashpointIsEmpty_ShouldPreserveTotal()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.RemoveBanknote(5);

			Assert.That(
				cashpoint.Total,
				Is.EqualTo(0),
				"Извлечена купюра из пустого банкомата");
		}

		[Test]
		public void RemoveBanknote_UnknownBanknote_ShouldPreserveTotal()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.AddBanknote(7);
			cashpoint.RemoveBanknote(5);

			Assert.That(
				cashpoint.Total,
				Is.EqualTo(7),
				"Извлечена несуществующая купюра");
		}

		[Test]
		public void RemoveBanknote_ExistingBanknote_ShouldReduceTotal()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.AddBanknote(5);
			cashpoint.AddBanknote(10);
			cashpoint.RemoveBanknote(5);

			Assert.That(
				cashpoint.Total,
				Is.EqualTo(10),
				"Купюра извлечена некорректно");
		}

		[Test]
		public void CanGrand_SumIsZero_ShouldGrant()
		{
			Cashpoint cashpoint = new Cashpoint();

			Assert.That(
				cashpoint.CanGrant(0),
				"Банкомат не смог выдать 0");

			cashpoint.AddBanknote(5);

			Assert.That(
				cashpoint.CanGrant(0),
				"Банкомат не смог выдать 0 после добавления купюры");
		}

		[Test]
		public void CanGrant_SumEqualsToSingleBanknote_ShouldGrant()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.AddBanknote(5);

			Assert.That(
				cashpoint.CanGrant(5),
				"Банкомат не смог выдать единственную банкноту");
		}

		[Test]
		public void CanGrant_SumNotEqualsToSingleBanknote_ShouldNotGrant()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.AddBanknote(5);

			Assert.That(
				cashpoint.CanGrant(4),
				Is.False,
				"Банкомат выдал банкноту, которой нет в нем");
		}

		[Test]
		public void CanGrant_SumEqualsToMultiplyBanknotes_ShouldGrant()
		{
			Cashpoint cashpoint = new Cashpoint();
			 
			cashpoint.AddBanknote(6);
			cashpoint.AddBanknote(4);

			Assert.That(
				cashpoint.CanGrant(10),
				"Банкомат не выдал две банкноты, которые есть в нем");
		}

		[Test]
		public void CanGrant_SumNotEqualsToMultiplyBanknotes_ShoultNotGrant()
		{
			Cashpoint cashpoint = new Cashpoint();

			cashpoint.AddBanknote(6);
			cashpoint.AddBanknote(2);

			Assert.That(
				!cashpoint.CanGrant(7),
				"Банкомат выдал сумму, которую нет в совокупности купюр");
		}

		[Test]
		[Timeout(20000)]
		[Ignore("Результат решения зависит от мощности машины")]
		public void CanGrant_PerformanceTest()
		{
			Cashpoint cashpoint = new Cashpoint();

			for (int i = 0; i < 2; i++)
			{
				cashpoint.AddBanknote(10);
				cashpoint.AddBanknote(50);
				cashpoint.AddBanknote(100);
				cashpoint.AddBanknote(200);
				cashpoint.AddBanknote(500);
				cashpoint.AddBanknote(1000);
				cashpoint.AddBanknote(2000);
				cashpoint.AddBanknote(5000);
			}

			Assert.That(cashpoint.CanGrant(3350));
			Assert.That(cashpoint.CanGrant(3980), Is.False);
		}
	}
}
