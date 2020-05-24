using System;
using System.Data.Common;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexicon.Legacy2019.Repositories
{
    public interface IContext: IDisposable
    {
        event EventHandler SavingChanges;
        DbConnection Connection { get; }
        ObjectContextOptions ContextOptions { get; }
        ObjectStateManager ObjectStateManager { get; }
        ObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
