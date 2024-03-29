﻿using GiveFreely.EMS.Core.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GiveFreely.EMS.Infrastructure.Data;

public static class SeedData
{

  public static readonly Employee Employee1 = new Employee("Steve", "Kaufer", "skaufer@wegivefreely.com", "CEO", new DateTime(2023, 1, 1));
  public static readonly Employee Employee2 = new Employee("Brendan", "Buono", "bbuono@wegivefreely.com", "CTO", new DateTime(2023, 1, 1));
  public static readonly Employee Employee3 = new Employee("Felipe", "Pessoto", "fpessoto@wegivefreely.com", "Sr. Fullstack Engineer", new DateTime(2024, 4, 2));

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.Employees.Any()) return;

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {

    foreach (var contributor in dbContext.Employees)
    {
      dbContext.Remove(contributor);
    }

    dbContext.SaveChanges();


    dbContext.Employees.Add(Employee1);
    dbContext.Employees.Add(Employee2);
    dbContext.Employees.Add(Employee3);

    dbContext.SaveChanges();
  }
}
