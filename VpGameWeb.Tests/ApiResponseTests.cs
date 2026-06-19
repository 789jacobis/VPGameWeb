using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Tests;

public class ApiResponseTests
{
    [Test]
    public void Ok_WrapsDataWithSuccessfulResponse()
    {
        var response = ApiResponse<string>.Ok("ready");

        Assert.Multiple(() =>
        {
            Assert.That(response.Success, Is.True);
            Assert.That(response.Message, Is.Null);
            Assert.That(response.Data, Is.EqualTo("ready"));
        });
    }

    [Test]
    public void Fail_ReturnsMessageAndNullData()
    {
        var response = ApiResponse<string>.Fail("not found");

        Assert.Multiple(() =>
        {
            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo("not found"));
            Assert.That(response.Data, Is.Null);
        });
    }
}
