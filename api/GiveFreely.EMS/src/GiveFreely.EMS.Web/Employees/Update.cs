using Ardalis.Result;
using GiveFreely.EMS.UseCases.Employees.Get;
using GiveFreely.EMS.UseCases.Employees.Update;
using FastEndpoints;
using MediatR;

namespace GiveFreely.EMS.Web.Employees;

/// <summary>
/// Update an existing Employee.
/// </summary>
/// <remarks>
/// Update an existing Employee by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateEmployeeRequest, UpdateEmployeeResponse>
{
  public override void Configure()
  {
    Put(UpdateEmployeeRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateEmployeeRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateEmployeeCommand(request.Id,
                                                                request.FirstName!,
                                                                request.LastName!,
                                                                request.Email!,
                                                                request.JobTitle!,
                                                                request.DateOfJoining!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetEmployeeQuery(request.EmployeeId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateEmployeeResponse(Mapper.Map(dto));
      return;
    }
  }
}
