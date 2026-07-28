using Managment_System.DAL.Models;

namespace Managment_System.BLL.Interfaces;

public interface IGenericRepository<T> where T : ModelBase
{
    public IEnumerable<T> GetAll();
    public T? Get(int? id);
    public int Add(T entity);
    public int Update(T entity);
    public int Delete(T entity);

}