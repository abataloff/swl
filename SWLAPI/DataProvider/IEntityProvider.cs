namespace SWLAPI.DataProvider
{
    public interface IEntityProvider<T>
    {
        T Create();
        void Push(T entity);
    }
}