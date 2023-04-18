namespace Courses_Registration_System.BL.Interface
{
	public interface IRepository<T>
	{
		 IQueryable<T> getAll();
		 T get(int id);
		 void Add(T entity);
		 void delete(int id);
		 void update(T entity);	
	}
}
