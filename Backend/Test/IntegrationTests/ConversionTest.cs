using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Units.Application.Features.Conversion.Query.GetConversion;

namespace IntegrationTests;

public class ConversionTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ConversionTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CanGet()
    {
        var client = _factory.CreateClient();
        var result = await client.GetAsync("/conversion");

        Assert.NotNull(result);

        Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);

        var contents = await result.Content.ReadAsStringAsync();

        Assert.NotEmpty(contents);
    }

    [Fact]
    public async Task CanConvertLength()
    {
        var client = _factory.CreateClient();
        var result = await client.GetAsync("/conversion/length/meter/foot?value=25");

        Assert.NotNull(result);

        var contents = await result.Content.ReadAsStringAsync();

        Assert.NotEmpty(contents);

        var response = JsonSerializer.Deserialize<ConversionResponse>(contents);

        Assert.NotNull(response);
        Assert.True(response.Success == true);

    }
}