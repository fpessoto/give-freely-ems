using Ardalis.Result;
using GiveFreely.EMS.UseCases.Employees;
using GiveFreely.EMS.UseCases.Employees.List;
using FastEndpoints;
using MediatR;

namespace GiveFreely.EMS.Web.Employees;

/// <summary>
/// List all Employees
/// </summary>
/// <remarks>
/// List all Employees - returns a EmployeeListResponse containing the Employees.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<EmployeeListResponse>
{
  public override void Configure()
  {
    Get("/Employees");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<EmployeeDTO>> result = await _mediator.Send(new ListEmployeesQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new EmployeeListResponse
      {
        Employees = result.Value.Select(c => Mapper.Map(c)).ToList()
      };
    }
  }
}
