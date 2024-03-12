using GiveFreely.EMS.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace GiveFreely.EMS.Web.Employee;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateEmployeeValidator : Validator<CreateEmployeeRequest>
{
  public CreateEmployeeValidator()
  {
    RuleFor(x => x.FirstName)
      .NotEmpty()
      .WithMessage("FirstName is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.LastName)
      .NotEmpty()
      .WithMessage("LastName is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.Email)
      .NotEmpty()
      .WithMessage("Email is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.JobTitle)
      .NotEmpty()
      .WithMessage("JobTitle is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.DateOfJoining)
      .NotEmpty()
      .WithMessage("DateOfJoining is required.");
  }
}
