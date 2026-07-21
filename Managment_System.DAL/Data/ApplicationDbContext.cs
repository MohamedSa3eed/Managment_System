using System.Reflection;
using Managment_System.DAL.Models;
using Managment_System.DAL.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Managment_System.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   // {
   //     optionsBuilder.UseSqlServer(
   //         "Server = .; Database = Company; Trusted_Connection = True; TrustServerCertificate=True");
   // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Department> Departments { get; set; }
}