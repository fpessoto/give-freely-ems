using GiveFreely.EMS.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace GiveFreely.EMS.Web.Employees;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateEmployeeValidator : Validator<UpdateEmployeeRequest>
{
  public UpdateEmployeeValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.EmployeeId)
      .Must((args, EmployeeId) => args.Id == EmployeeId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
