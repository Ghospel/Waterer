namespace Waterer.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(string id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(string id);
        void Save();
    }
}
