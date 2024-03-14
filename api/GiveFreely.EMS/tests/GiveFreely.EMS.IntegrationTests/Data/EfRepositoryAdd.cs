using GiveFreely.EMS.Core.EmployeeAggregate;
using Xunit;

namespace GiveFreely.EMS.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{

  private readonly string _testFirstName = "John";
  private readonly string _testLastName = "Doe";
  private readonly string _testEmail = "jdoe@mail.com";
  private readonly string _testJobTitle = "Analyst";

  private readonly DateTime _testDateOfJoining = DateTime.Now.AddYears(-2);

  [Fact]
  public async Task AddsEmployeeAndSetsId()
  {
    var repository = GetRepository();
    var Employee = new Employee(_testFirstName, _testLastName, _testEmail, _testJobTitle, _testDateOfJoining);

    await repository.AddAsync(Employee);

    var newEmployee = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(_testFirstName, newEmployee?.FirstName);
    Assert.Equal(_testLastName, newEmployee?.LastName);
    Assert.Equal(_testEmail, newEmployee?.Email);
    Assert.Equal(_testJobTitle, newEmployee?.JobTitle);
    Assert.Equal(_testDateOfJoining, newEmployee?.DateOfJoining);
    Assert.True(newEmployee?.Id > 0);
  }
}
