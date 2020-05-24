using System.Collections.Generic;
using System.Linq;
using Lexicon.Legacy2019.IRepository;

namespace Lexicon.Legacy2019.Services
{
    public class DumbService : BaseService
    {        
        public DumbService(IUnitOfWork uow) : base(uow)
        {

        }

        public void Activate()
        {
            string s = "You're a winner";
        }

        public override IList<T> FindAll<T>()
        {
            var ttt = new Lexicon.Legacy2019.Models.Lexicon2019_TransitionalEntities();
            var tttx = ttt.LexiconRaws;
            return _uow.GetRepository<T>().FindAll().ToList();
        }
    }
}
