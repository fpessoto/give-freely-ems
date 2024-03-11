using FastEndpoints;
using FluentValidation;

namespace GiveFreely.EMS.Web.Employees;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetEmployeeValidator : Validator<GetEmployeeByIdRequest>
{
  public GetEmployeeValidator()
  {
    RuleFor(x => x.EmployeeId)
      .GreaterThan(0);
  }
}
