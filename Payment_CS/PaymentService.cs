using System.Text.RegularExpressions;

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
		$"Cash payment of {Amount} received";
}

public class CreditCardPayment : PaymentBase
{
	public const string ccRegex = @"\d\d\d\d-\d\d\d\d-\d\d\d\d-\d\d\d\d";
	public string CreditCardNumber { get; set; }
	public CreditCardPayment(string ccNum, decimal amount)
	{
		CreditCardNumber = ccNum;
		Amount = amount;
	}

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
	public static string ProcessPayment(PaymentBase payment)
	{
		if (payment is null)
		{
			return "Invalid payment";
		}

		if (payment.IsValid())
		{
			return $"Payment processed: {payment.GetPaymentSummary()}";
		}

		return $"Invalid payment: {payment.Error}";
	}

	public static string ProcessPaymentCash(decimal amount) =>
		ProcessPayment(new CashPayment(amount));

	public static string ProcessPaymentCreditCard(string ccNum, decimal amount) =>
		ProcessPayment(new CreditCardPayment(ccNum, amount));
}