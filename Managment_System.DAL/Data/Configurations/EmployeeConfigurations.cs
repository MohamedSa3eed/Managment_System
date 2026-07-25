using Managment_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment_System.DAL.Data.Configurations;

public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.Property(e => e.Id).UseIdentityColumn().IsRequired();
        builder.Property(e => e.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(e => e.Address).HasColumnType("varchar").HasMaxLength(200).IsRequired();
        builder.Property(e => e.Age).IsRequired();
        builder.Property(e => e.Salary).HasColumnType("decimal(12,2)").IsRequired();
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(e => e.PhoneNumber).HasColumnType("varchar").HasMaxLength(20).IsRequired();
        builder.Property(e => e.HiringDate).IsRequired();
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.Gender).HasConversion(
            (gender) => gender.ToString(),
            (genderStr) => Enum.Parse<Gender>(genderStr)
        ).HasMaxLength(6).IsRequired();
        builder.Property(e => e.EmployeeType).HasConversion(
            (empType) => empType.ToString(),
            (empTypeStr) => Enum.Parse<EmpType>(empTypeStr)
        ).HasMaxLength(10).HasDefaultValue(EmpType.FullTime);
    }
}