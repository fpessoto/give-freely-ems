﻿namespace GiveFreely.EMS.Web.Employees;

public class GetEmployeeByIdRequest
{
  public const string Route = "/Employees/{EmployeeId:int}";
  public static string BuildRoute(int EmployeeId) => Route.Replace("{EmployeeId:int}", EmployeeId.ToString());

  public int EmployeeId { get; set; }
}
