using IServices;

namespace Services
{
    public interface IServiceFactory<T> where T : class, new()
    {
        IService<T> CreatService();
    }
}