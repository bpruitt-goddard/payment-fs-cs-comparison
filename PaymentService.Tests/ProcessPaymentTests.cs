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

        var expectedResponse = $"Payment processed: Cash payment of {validAmount} received";
        Assert.Equal(expectedResponse, res_fs);
    }
}