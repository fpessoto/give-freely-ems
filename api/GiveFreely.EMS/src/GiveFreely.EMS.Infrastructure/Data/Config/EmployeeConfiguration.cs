using GiveFreely.EMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiveFreely.EMS.Infrastructure.Data.Config;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
  public void Configure(EntityTypeBuilder<Employee> builder)
  {
    builder.Property(p => p.FirstName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(p => p.LastName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .HasMaxLength(255)
        .IsRequired();

    builder.Property(p => p.JobTitle)
        .HasMaxLength(255)
        .IsRequired();

    builder.Property(p => p.Email)
        .HasMaxLength(255)
        .IsRequired();

    builder.Property(p => p.DateOfJoining)
        .IsRequired();
  }
}
