using GiveFreely.EMS.Core.EmployeeAggregate;
using Xunit;

namespace GiveFreely.EMS.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  private readonly string _testLastName = "Doe";
  private readonly string _testEmail = "jdoe@mail.com";
  private readonly string _testJobTitle = "Analyst";
  private readonly DateTime _testDateOfJoining = DateTime.Now.AddYears(-2);

  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Employee
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var Employee = new Employee(initialName, _testLastName, _testEmail, _testJobTitle, _testDateOfJoining);
    await repository.AddAsync(Employee);

    // delete the item
    await repository.DeleteAsync(Employee);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        Employee => Employee.FirstName == initialName);
  }
}
