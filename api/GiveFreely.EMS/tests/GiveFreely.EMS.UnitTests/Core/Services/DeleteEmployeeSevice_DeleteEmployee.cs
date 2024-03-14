using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.EmployeeAggregate;
using GiveFreely.EMS.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace GiveFreely.EMS.UnitTests.Core.Services;

public class DeleteEmployeeService_DeleteEmployee
{
  private readonly IRepository<Employee> _repository = Substitute.For<IRepository<Employee>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeleteEmployeeService> _logger = Substitute.For<ILogger<DeleteEmployeeService>>();

  private readonly DeleteEmployeeService _service;

  public DeleteEmployeeService_DeleteEmployee()
  {
    _service = new DeleteEmployeeService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindEmployee()
  {
    var result = await _service.DeleteEmployee(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
