using Ardalis.Result;
using GiveFreely.EMS.UseCases.Employees.Delete;
using FastEndpoints;
using MediatR;

namespace GiveFreely.EMS.Web.Employees;

/// <summary>
/// Delete a Employee.
/// </summary>
/// <remarks>
/// Delete a Employee by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteEmployeeRequest>
{
  public override void Configure()
  {
    Delete(DeleteEmployeeRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteEmployeeRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteEmployeeCommand(request.EmployeeId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}
