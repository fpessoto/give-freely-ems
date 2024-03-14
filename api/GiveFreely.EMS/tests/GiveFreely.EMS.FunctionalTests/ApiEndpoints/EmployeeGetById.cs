using Ardalis.HttpClientTestExtensions;
using GiveFreely.EMS.Infrastructure.Data;
using GiveFreely.EMS.Web.Employees;
using Xunit;

namespace GiveFreely.EMS.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class EmployeeGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedEmployeeGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<EmployeeRecord>(GetEmployeeByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.Employee1.FirstName, result.FirstName);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = GetEmployeeByIdRequest.BuildRoute(1000);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
