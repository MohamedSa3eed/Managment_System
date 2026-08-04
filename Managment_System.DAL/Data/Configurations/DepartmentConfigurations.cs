using Managment_System.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managment_System.DAL.Data.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.Property(d => d.Id).UseIdentityColumn(10, 10);
        builder.Property(d => d.Code).HasColumnType("nvarchar(50)").IsRequired();
        builder.Property(d => d.Name).HasColumnType("nvarchar(50)").IsRequired();
        builder.Property(d => d.StartDate).HasColumnType("datetime").IsRequired();
        builder.HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}