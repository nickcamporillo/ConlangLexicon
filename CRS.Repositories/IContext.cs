using System;
using System.Data.Common;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRS.Repository
{
    public interface IContext: IDisposable
    {
        event EventHandler SavingChanges;
        string UserId { get; set; }
        DbConnection Connection { get; }
        ObjectContextOptions ContextOptions { get; }
        ObjectStateManager ObjectStateManager { get; }
        ObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
