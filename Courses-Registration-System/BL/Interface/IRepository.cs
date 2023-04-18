namespace Courses_Registration_System.BL.Interface
{
	public interface IRepository<T>
	{
		 IQueryable<T> GetAll();
		 T Get(int id);
		 void Add(T entity);
		 void Delete(int id);
		 void Update(T entity);	
	}
}
