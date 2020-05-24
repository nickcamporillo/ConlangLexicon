using System;
using System.Linq;
using System.Linq.Expressions;
using IT.IRepository;
using System.Data.Objects;

namespace CRS.Repository
{
    /// <summary>
    /// A concrete implementation of IRepository for Entity Framework
    /// </summary>
    /// <typeparam name="T">The entity type for this repository.</typeparam>
    public class EfRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The Entity Framework context.
        /// </summary>
        private IContext context;

        /// <summary>
        /// The Entity Framework set of database objects.
        /// </summary>
        private ObjectSet<T> databaseObjectSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfRepository(IContext context)
        {
            this.context = context;
            this.databaseObjectSet = context.CreateObjectSet<T>();
        }

        /// <summary>
        /// Adds the specified entity to the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(T entity)
        {
            this.databaseObjectSet.AddObject(entity);
        }

        /// <summary>
        /// Removes the specified entity from the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            this.databaseObjectSet.DeleteObject(entity);
        }

        /// <summary>
        /// Find an object using a predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Query-able list of objects that match the predicate.</returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {            
            return this.databaseObjectSet.Where(predicate);
        }

        /// <summary>
        /// Finds all objects. (You can use LINQ against this).
        /// </summary>
        /// <returns>Query-able list of all objects in the repository.</returns>
        public IQueryable<T> FindAll()
        {
            return this.databaseObjectSet.AsQueryable<T>();
        }      
    }
}