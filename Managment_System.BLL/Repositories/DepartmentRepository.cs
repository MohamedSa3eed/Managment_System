using Managment_System.BLL.Interfaces;
using Managment_System.DAL.Data;
using Managment_System.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment_System.BLL.Repositories;

public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
        
    }
    
}