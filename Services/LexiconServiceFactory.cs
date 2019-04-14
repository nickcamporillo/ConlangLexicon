using IRepository;
using IServices;
using Repositories;

namespace LexServices
{
    public class LexiconServiceFactory<T> : IServiceFactory<T> where T:class,new()
    {
        private IUnitOfWork _uow = null;

        public LexiconServiceFactory()
        {
            _uow = new EfUnitOfWork();  //Config.UnitOfWorkConfig
        }

        public IService<T> CreatService()
        {
            return new LexiconService<T>(_uow);
        }
    }
}
