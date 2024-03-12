using GiveFreely.EMS.UseCases.Employees;
using GiveFreely.EMS.Web.Employees;

public static class Mapper
{
  public static EmployeeRecord Map(EmployeeDTO dto)
  {
    return new EmployeeRecord(dto.Id, dto.FirstName, dto.LastName, dto.Email, dto.JobTitle, dto.DateOfJoining, dto.TotalYearsOfService);
  }

  public static EmployeeDTO Map(EmployeeRecord record)
  {
    return new EmployeeDTO(record.Id, record.FirstName, record.LastName, record.Email, record.JobTitle, record.DateOfJoining, record.TotalYearsOfService);
  }

}
