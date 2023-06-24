using Shared;

namespace Iggy_Sample_Producer;

public static class MessageGenerator
{
	private static int OrderCreatedId = 0;
	private static int OrderConfirmedId = 0;
	private static int OrderRejectedId = 0;

	public static ISerializableMessage GenerateMessage()
	{
		return Random.Shared.Next(1, 3) switch
		{
			1 => GenerateOrderCreatedMessage(),
			2 => GenerateOrderConfirmedMessage(),
			_ => GenerateOrderRejectedMessage()
		};
	}
	private static ISerializableMessage GenerateOrderCreatedMessage()
	{
		return new OrderCreated
		{
			Id = OrderCreatedId++,
			CurrencyPair = Random.Shared.Next(1,3) switch
			{
				1 => "BTC/USDT",
				2 => "ETH/USDT",
				_ => "LTC/USDT"
			},
			Price = Random.Shared.Next(69,420),
			Quantity = Random.Shared.Next(69,420),
			Side = Random.Shared.Next(1,2) switch
			{
				1 => "Buy",
				_ => "Sell"
			},
			Timestamp = Random.Shared.Next(420,69420)
		};
		
	}	
	private static ISerializableMessage GenerateOrderConfirmedMessage()
	{
		return  new OrderConfirmed()
		{
			Id = OrderConfirmedId++,
			Price = Random.Shared.Next(69,420),
			Timestamp = Random.Shared.Next(420,69420)
		};
	}	
	
	private static ISerializableMessage GenerateOrderRejectedMessage()
	{
		return new OrderRejected()
		{
			Id = OrderRejectedId++,
			Timestamp = Random.Shared.Next(420,69420),
			Reason = Random.Shared.Next(1,3) switch
			{
				1 => "Cancelled by user",
				2 => "Insufficient funds",
				_ => "Other"
			}
		};
	}	
}

