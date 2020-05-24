using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IT.IRepository;

namespace CRS.Services
{
    public abstract class BaseService:IService
    {
        protected IUnitOfWork _uow;

        public int AccessCode
        {
            get;
            protected set;
        }

        protected BaseService(IUnitOfWork uow, int accessCode)
        {
            _uow = uow;
            this.AccessCode = accessCode;
        }

        public T FindItem<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _uow.GetRepository<T>().Find(predicate).FirstOrDefault();
        }

        public TInterface FindItemOf<T,TInterface>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.FindItems<T>(predicate).OfType<TInterface>().ToList().FirstOrDefault();
        }

        public IList<T> FindItems<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _uow.GetRepository<T>().Find(predicate).ToList();
        }

        public IList<TInterface> FindItemsOf<T, TInterface>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.FindItems<T>(predicate).OfType<TInterface>().ToList();
        }
        
        public IList<T> FindAll<T>() where T:class
        { 
            return _uow.GetRepository<T>().FindAll().ToList();
        }

        public IList<TInterface> FindAllOf<T, TInterface>() where T : class
        {
            return _uow.GetRepository<T>().FindAll().OfType<TInterface>().ToList();
        }

        public virtual void Add<T>(T entity) where T : class
        {
            _uow.GetRepository<T>().Add(entity);
        }
        
        public virtual void Remove<T>(T entity) where T : class
        {
            _uow.GetRepository<T>().Remove(entity);
        }

        public virtual void SaveAndCommit()
        {
            _uow.SaveChanges();
        }

        public virtual void RollBack()
        {
            _uow.RollBack();
        }
    }
}
