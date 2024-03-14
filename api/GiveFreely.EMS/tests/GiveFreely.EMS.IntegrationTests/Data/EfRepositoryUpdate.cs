using GiveFreely.EMS.Core.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GiveFreely.EMS.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{

  private readonly string _testLastName = "Doe";
  private readonly string _testEmail = "jdoe@mail.com";
  private readonly string _testJobTitle = "Analyst";

  private readonly DateTime _testDateOfJoining = DateTime.Now.AddYears(-2);

  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a Employee
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var Employee = new Employee(initialName, _testLastName, _testEmail, _testJobTitle, _testDateOfJoining);

    await repository.AddAsync(Employee);

    // detach the item so we get a different instance
    _dbContext.Entry(Employee).State = EntityState.Detached;

    // fetch the item and update its title
    var newEmployee = (await repository.ListAsync())
        .FirstOrDefault(Employee => Employee.FirstName == initialName);
    if (newEmployee == null)
    {
      Assert.NotNull(newEmployee);
      return;
    }
    Assert.NotSame(Employee, newEmployee);
    var newName = Guid.NewGuid().ToString();
    newEmployee.UpdateFirstName(newName);

    // Update the item
    await repository.UpdateAsync(newEmployee);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(Employee => Employee.FirstName == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(Employee.FirstName, updatedItem?.FirstName);
    Assert.Equal(Employee.LastName, updatedItem?.LastName);
    Assert.Equal(newEmployee.Id, updatedItem?.Id);
  }
}
