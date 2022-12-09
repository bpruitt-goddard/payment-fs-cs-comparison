using Payment_CS;
using Payment_FS;

namespace PaymentService.Tests;

public class UnitTest1
{
    [Fact]
    public void InvalidCashReturnsError()
    {
        var invalidAmount = -4;

        var res_fs = PaymentService_FS.processPaymentCash(invalidAmount);
        var res_cs = PaymentService_CS.ProcessPaymentCash(invalidAmount);

        var expectedResponse = "Invalid payment: Cash must be a positive amount";
        Assert.Equal(expectedResponse, res_fs);
        Assert.Equal(res_fs, res_cs);
    }

    [Fact]
    public void ValidCashReturnsSuccess()
    {
        var validAmount = 35;

        var res_fs = PaymentService_FS.processPaymentCash(validAmount);
        var res_cs = PaymentService_CS.ProcessPaymentCash(validAmount);


        var expectedResponse = $"Payment processed: Cash payment of {validAmount} received";
        Assert.Equal(expectedResponse, res_fs);
        Assert.Equal(res_fs, res_cs);
    }

    [Fact]
    public void InvalidCreditCardReturnsError()
    {
        var invalidCreditCard = "1234";
        var amount = 17;

        var res_fs = PaymentService_FS.processPaymentCreditCard(invalidCreditCard, amount);
        var res_cs = PaymentService_CS.ProcessPaymentCreditCard(invalidCreditCard, amount);

        var expectedResponse = $"Invalid payment: Invalid credit card number: {invalidCreditCard}";
        Assert.Equal(expectedResponse, res_fs);
        Assert.Equal(res_fs, res_cs);
    }

    [Fact]
    public void ValidCreditCardReturnsSuccess()
    {
        var validCreditCard = "1234-5678-9012-3456";
        var amount = 17;

        var res_fs = PaymentService_FS.processPaymentCreditCard(validCreditCard, amount);
        var res_cs = PaymentService_CS.ProcessPaymentCreditCard(validCreditCard, amount);

        var expectedResponse = $"Payment processed: Credit card payment of {amount} received via credit card {validCreditCard}";
        Assert.Equal(expectedResponse, res_fs);
        Assert.Equal(res_fs, res_cs);
    }
}