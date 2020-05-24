using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRS.App_Level;

namespace CRS.Services
{
    public delegate IList<TEntity> GetDataSet<TEntity>();
    public delegate IList<TEntity> GetDataFromLambda<TEntity>(Func<TEntity, bool> predicate);
    public delegate IList<TEntity> GetDataFromEnumCodeAndLambda<TEntity, TPredicate>(int enumCode, Func<TPredicate, bool> predicate);

    public interface IDataServicesInvoker
    {
        object DataResultSet { get;}
        IEnumerationDetail EnumerationDetail { get; set; }        
        void Execute(IEnumerationDetail targetInvokeeEnumerationDetail);
        void Execute();
    }
}
