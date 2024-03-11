using Ardalis.Result;
using GiveFreely.EMS.UseCases.Employees.Get;
using FastEndpoints;
using MediatR;

namespace GiveFreely.EMS.Web.Employees;

/// <summary>
/// Get a Employee by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Employee record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetEmployeeByIdRequest, EmployeeRecord>
{
  public override void Configure()
  {
    Get(GetEmployeeByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetEmployeeByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetEmployeeQuery(request.EmployeeId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new EmployeeRecord(result.Value.Id, result.Value.Name, result.Value.PhoneNumber);
    }
  }
}
