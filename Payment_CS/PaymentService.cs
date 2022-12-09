namespace Payment_CS;

public abstract class PaymentBase
{
	public decimal Amount { get; set; }
	public string Error { get; set; }
	public abstract bool IsValid();
	public abstract string GetPaymentSummary();
}
public class CashPayment : PaymentBase
{
	public CashPayment(decimal amount)
	{
		Amount = amount;
	}

	public override bool IsValid()
	{
		if (Amount >= 0)
			return true;

		Error = "Cash must be a positive amount";
		return false;
	}

	public override string GetPaymentSummary() =>
		$"Cash payment of {Amount} received.";
}

public static class PaymentService_CS
{
	public static string ProcessPayment(PaymentBase payment)
	{
		if (payment is null)
		{
			return "Invalid payment";
		}

		if (payment.IsValid())
		{
			return payment.GetPaymentSummary();
		}

		return $"Invalid payment: {payment.Error}";
	}

	public static string ProcessPaymentCash(decimal amount) =>
		ProcessPayment(new CashPayment(amount));
}