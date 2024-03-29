﻿using GiveFreely.EMS.UseCases.Employees.Create;
using FastEndpoints;
using MediatR;

namespace GiveFreely.EMS.Web.Employee;

/// <summary>
/// Create a new Employee
/// </summary>
/// <remarks>
/// Creates a new Employee given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateEmployeeRequest, CreateEmployeeResponse>
{
  public override void Configure()
  {
    Post(CreateEmployeeRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Employee.";
      //s.Description = "Create a new Employee. A valid name is required.";
      s.ExampleRequest = new CreateEmployeeRequest
      {
        FirstName = "John",
        LastName = "Doe",
        Email = "jdoe@mail.com",
        JobTitle = "Analyst",
        DateOfJoining = DateTime.Now
      };
    });
  }

  public override async Task HandleAsync(
    CreateEmployeeRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateEmployeeCommand(request.FirstName!,
                                                                request.LastName!,
                                                                request.Email!,
                                                                request.JobTitle!,
                                                                request.DateOfJoining!), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateEmployeeResponse(result.Value, request.FirstName!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
