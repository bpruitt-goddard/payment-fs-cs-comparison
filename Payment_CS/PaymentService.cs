using System.Text.RegularExpressions;

namespace Payment_CS;

public abstract record PaymentBase(decimal Amount)
{
	public string? Error { get; set; }
	public abstract bool IsValid();
	public abstract string GetPaymentSummary();
}
public record CashPayment(decimal Amount) : PaymentBase(Amount)
{
	public override bool IsValid()
	{
		if (Amount >= 0)
			return true;

		Error = "Cash must be a positive amount";
		return false;
	}

	public override string GetPaymentSummary() =>
		$"Cash payment of {Amount} received";
}

public record CreditCardPayment(string CreditCardNumber, decimal Amount) : PaymentBase(Amount)
{
	public const string ccRegex = @"\d\d\d\d-\d\d\d\d-\d\d\d\d-\d\d\d\d";

	public override bool IsValid()
	{
		if (Regex.IsMatch(CreditCardNumber, ccRegex))
			return true;
		
		Error = $"Invalid credit card number: {CreditCardNumber}";
		return false;
	}

	public override string GetPaymentSummary() =>
		$"Credit card payment of {Amount} received via credit card {CreditCardNumber}";
}

public static class PaymentService_CS
{
	public static string ProcessPayment(PaymentBase payment) =>
		payment switch
		{
			_ when payment is null => "Invalid payment",
			_ when payment.IsValid() => $"Payment processed: {payment.GetPaymentSummary()}",
			_ => $"Invalid payment: {payment.Error}",
		};

	public static string ProcessPaymentCash(decimal amount) =>
		ProcessPayment(new CashPayment(amount));

	public static string ProcessPaymentCreditCard(string ccNum, decimal amount) =>
		ProcessPayment(new CreditCardPayment(ccNum, amount));
}