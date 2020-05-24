using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Objects;
using IT.IRepository;
using CRS.Models;

namespace CRS.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private IContextFactory _factory;
        private IContext _context;
        private IRepositoryFactory _repositoryFactory;
        private IList<object> _cachedRepositories;
        private DbConnection _dbConnection;

        public string UserId { get; set; }

        public EfUnitOfWork()
        {
            Initialize();            
        }

        private void Initialize()
        {
            _factory = new ContextFactory();
            _context = _factory.CreateObjectContext();
            _repositoryFactory = new EfRepositoryFactory(this._context);
            _cachedRepositories = new List<object>();
            EntityConnection entityConnection = (EntityConnection)_context.Connection;
            _dbConnection = entityConnection.StoreConnection;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                this._context.SaveChanges();
            }
            catch(Exception ex)
            {                
                RollBack();
            }
        }

        public bool HasChanges()
        {
            IEnumerable<ObjectStateEntry> changes = this._context.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified);
            foreach (ObjectStateEntry stateEntryEntity in changes)
            {
                if (!stateEntryEntity.IsRelationship &&
                    stateEntryEntity.Entity != null )
                {
                    //DataItem item = stateEntryEntity.Entity as DataItem;
                    //string origValue = stateEntryEntity.OriginalValues[DataItemField.FIELD_VALUE].ToString();
                    //string newValue = stateEntryEntity.CurrentValues[DataItemField.FIELD_VALUE].ToString();
                    //origValue = string.IsNullOrEmpty(origValue) ? string.Empty : origValue.Trim();
                    //newValue = string.IsNullOrEmpty(newValue) ? string.Empty : newValue.Trim();
                    //if (origValue != newValue)
                    //    return true;
                }
            }
            return false;
        }

        public void RollBack()
        {
            Initialize();  
        }
        public void ExecuteQuery(string query, out DataTable dt)
        {
            throw new NotImplementedException("EfUnitOfWork.ExecuteQuery not implemented exception.  Reenable the commented code below");
            //dt = _sqlQueryService.ExecuteQuery(query);
        }

        public void BulkInsert(DataTable data, string destinationTableName)
        {
            throw new NotImplementedException("EfUnitOfWork.BulkInsert not implemented exception.  Reenable the commented code below");
            //_sqlQueryService.bulkInsert(data, destinationTableName);
        }


        public IRepository<T> GetRepository<T>() where T : class
        {
            foreach (object obj in this._cachedRepositories)
            {
                if (obj is IRepository<T>)
                {
                    return (IRepository<T>)obj;
                }
            }

            // if it doesn't already exist, create it and add it to the cache
            IRepository<T> newRepository = _repositoryFactory.CreateRepository<T>();
            this._cachedRepositories.Add(newRepository);

            return newRepository;
        }
    }
}