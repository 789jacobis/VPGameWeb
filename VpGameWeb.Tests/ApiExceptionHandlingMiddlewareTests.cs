using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using VpGameWeb.Middleware;

namespace VpGameWeb.Tests;

public class ApiExceptionHandlingMiddlewareTests
{
    [Test]
    public async Task InvokeAsync_ReturnsStandardApiResponseForUnhandledException()
    {
        var context = new DefaultHttpContext();
        context.Request.Method = "GET";
        context.Request.Path = "/api/characters";
        context.Response.Body = new MemoryStream();

        var middleware = new ApiExceptionHandlingMiddleware(
            _ => throw new InvalidOperationException("boom"),
            NullLogger<ApiExceptionHandlingMiddleware>.Instance);

        await middleware.InvokeAsync(context);

        context.Response.Body.Position = 0;
        using var document = await JsonDocument.ParseAsync(context.Response.Body);
        JsonElement root = document.RootElement;

        Assert.Multiple(() =>
        {
            Assert.That(context.Response.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
            Assert.That(context.Response.ContentType, Is.EqualTo("application/json"));
            Assert.That(root.GetProperty("success").GetBoolean(), Is.False);
            Assert.That(root.GetProperty("message").GetString(), Is.EqualTo("An unexpected error occurred."));
            Assert.That(root.GetProperty("data").ValueKind, Is.EqualTo(JsonValueKind.Null));
        });
    }
}
