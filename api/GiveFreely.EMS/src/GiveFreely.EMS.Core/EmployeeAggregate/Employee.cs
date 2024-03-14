using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.Core.EmployeeAggregate;

public class Employee(string firstName,
                      string lastName,
                      string email,
                      string jobTitle,
                      DateTime dateOfJoining) : EntityBase, IAggregateRoot
{

  public string FirstName { get; private set; } = Guard.Against.NullOrEmpty(firstName, nameof(firstName));

  public string LastName { get; private set; } = Guard.Against.NullOrEmpty(lastName, nameof(lastName));

  public string Email { get; private set; } = Guard.Against.IsValidEmail(email, nameof(email));

  public string JobTitle { get; private set; } = Guard.Against.NullOrEmpty(jobTitle, nameof(jobTitle));

  public DateTime DateOfJoining { get; private set; } = dateOfJoining;

  public int TotalYearsOfService
  {
    get
    {
      return (int)((DateTime.UtcNow - DateOfJoining).TotalDays / 365.25);
    }
  }

  public void UpdateFirstName(string firstName)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
  }

  public void UpdateLastName(string lastName)
  {
    LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
  }

  public void UpdateEmail(string email)
  {
    Email = Guard.Against.NullOrEmpty(email, nameof(email));
  }

  public void UpdateJobTitle(string jobTitle)
  {
    JobTitle = Guard.Against.NullOrEmpty(jobTitle, nameof(jobTitle));
  }

  public void UpdateDateOfJoining(DateTime dateOfJoining)
  {
    DateOfJoining = Guard.Against.Null(dateOfJoining, nameof(dateOfJoining));
  }

}
