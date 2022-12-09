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

        var expectedResponse = "Invalid payment: Cash must be a positive amount";
        Assert.Equal(expectedResponse, res_fs);
    }
        Assert.Equal(expectedResponse, res_fs);
    }
}