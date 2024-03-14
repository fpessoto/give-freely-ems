using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.EmployeeAggregate;
using GiveFreely.EMS.UseCases.Employees.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace GiveFreely.EMS.UnitTests.UseCases.Employees;

public class CreateEmployeeHandlerHandle
{
  private readonly string _testFirstName = "John";
  private readonly string _testLastName = "Doe";
  private readonly string _testEmail = "jdoe@mail.com";
  private readonly string _testJobTitle = "Analyst";

  private readonly DateTime _testDateOfJoining = new DateTime(2024, 1, 1);

  private readonly IRepository<Employee> _repository = Substitute.For<IRepository<Employee>>();
  private CreateEmployeeHandler _handler;

  public CreateEmployeeHandlerHandle()
  {
    _handler = new CreateEmployeeHandler(_repository);
  }

  private Employee CreateEmployee()
  {
    return new Employee(_testFirstName, _testLastName, _testEmail, _testJobTitle, _testDateOfJoining);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidData()
  {
    _repository.AddAsync(Arg.Any<Employee>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateEmployee()));
    var result = await _handler.Handle(new CreateEmployeeCommand(_testFirstName, _testLastName, _testEmail, _testJobTitle, _testDateOfJoining), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();
  }
}
