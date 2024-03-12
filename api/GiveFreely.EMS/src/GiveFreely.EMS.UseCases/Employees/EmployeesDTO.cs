namespace GiveFreely.EMS.UseCases.Employees;
public record EmployeeDTO(int Id,
                      string FirstName,
                      string LastName,
                      string Email,
                      string JobTitle,
                      DateTime DateOfJoining,
                      int TotalYearsOfService);
