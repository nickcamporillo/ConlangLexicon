using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lexicon.Legacy2019.IRepository
{
    public interface ICrudFacade<T>where T : class
    {
        void AddItem(T entity);
        IList<T> FindAll();
        T FindItem(Expression<Func<T, bool>> predicate);
        IList<T> FindItems(Expression<Func<T, bool>> predicate);
        void RemoveItem(T entity);
        void Save();
    }
}
