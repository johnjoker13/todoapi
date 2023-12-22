using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Domain.Entites;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests;

public class AuthControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly TestingWebAppFactory<Program> _factory;

    public AuthControllerIntegrationTests(TestingWebAppFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GivenUserInfo_IfValid_ReturnsCreatedUser()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<TodoDbContext>();
            Utilities.ReinitializeDbForTests(db);
        }

        var user = User.Create(
            "Jane",
            "Doe",
            "jane.doe@email.com",
            "Pass@01234"
        );

        var payload = JsonConvert.SerializeObject(user);
        var contentString = new StringContent(payload, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/v1/auth/register", contentString);

        response.EnsureSuccessStatusCode();

        CommonUserResponse? responseJson = await response.Content.ReadFromJsonAsync<CommonUserResponse>();

        Assert.Contains("Jane", responseJson!.FirstName);
        Assert.Contains("Doe", responseJson.LastName);
        Assert.Contains("jane.doe@email.com", responseJson.Email);
    }
}