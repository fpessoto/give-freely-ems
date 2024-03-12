namespace GiveFreely.EMS.Web.Employees;

public record EmployeeRecord(int Id,
                      string FirstName,
                      string LastName,
                      string Email,
                      string JobTitle,
                      DateTime DateOfJoining,
                      int TotalYearsOfService);
