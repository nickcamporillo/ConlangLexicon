using IRepository;
using IServices;
using Repositories;

namespace Services
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
