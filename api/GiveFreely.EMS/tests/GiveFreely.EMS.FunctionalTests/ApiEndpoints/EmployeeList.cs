using Ardalis.HttpClientTestExtensions;
using GiveFreely.EMS.Infrastructure.Data;
using GiveFreely.EMS.Web.Employees;
using Xunit;

namespace GiveFreely.EMS.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class EmployeeList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsTwoEmployees()
  {
    var result = await _client.GetAndDeserializeAsync<EmployeeListResponse>("/Employees");

    Assert.Equal(3, result.Employees.Count);
    Assert.Contains(result.Employees, i => i.FirstName == SeedData.Employee1.FirstName);
    Assert.Contains(result.Employees, i => i.FirstName == SeedData.Employee2.FirstName);
    Assert.Contains(result.Employees, i => i.FirstName == SeedData.Employee3.FirstName);
  }
}
