using IServices;

namespace LexServices
{
    public interface IServiceFactory<T> where T : class, new()
    {
        IService<T> CreatService();
    }
}