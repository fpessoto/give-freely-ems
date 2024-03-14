using GiveFreely.EMS.Core.EmployeeAggregate;
using Xunit;

namespace GiveFreely.EMS.UnitTests.Core.EmployeeAggregate;

public class EmployeeConstructor
{
  private readonly string _testFirstName = "John";
  private readonly string _testLastName = "Doe";
  private readonly string _testEmail = "jdoe@mail.com";
  private readonly string _testJobTitle = "Analyst";

  private readonly DateTime _testDateOfJoining = DateTime.Now.AddYears(-2);
  private Employee? _testEmployee;

  private Employee CreateEmployee()
  {
    return new Employee(_testFirstName, _testLastName, _testEmail, _testJobTitle, _testDateOfJoining);
  }

  [Fact]
  public void InitializesWithValidaData()
  {
    _testEmployee = CreateEmployee();

    Assert.Equal(_testFirstName, _testEmployee.FirstName);
    Assert.Equal(_testLastName, _testEmployee.LastName);
    Assert.Equal(_testEmail, _testEmployee.Email);
    Assert.Equal(_testJobTitle, _testEmployee.JobTitle);
    Assert.Equal(_testDateOfJoining, _testEmployee.DateOfJoining);
  }

  [Fact]
  public void GetsTotalYearsOfService()
  {
    _testEmployee = CreateEmployee();


    Assert.Equal(2, _testEmployee.TotalYearsOfService);
  }

  [Fact]
  public void InitializesWithInvalidData_ExceptionThrown()
  {
    // Act & Assert
    Assert.Throws<ArgumentException>(() => new Employee("", _testLastName, _testEmail, _testJobTitle, _testDateOfJoining));
    Assert.Throws<ArgumentException>(() => new Employee(_testFirstName, "", _testEmail, _testJobTitle, _testDateOfJoining));
    Assert.Throws<ArgumentException>(() => new Employee(_testFirstName, _testLastName, "", _testJobTitle, _testDateOfJoining));
    Assert.Throws<ArgumentException>(() => new Employee(_testFirstName, _testLastName, "invalid_email", _testJobTitle, _testDateOfJoining));
    Assert.Throws<ArgumentException>(() => new Employee(_testFirstName, _testLastName, _testEmail, "", _testDateOfJoining));
  }

}
