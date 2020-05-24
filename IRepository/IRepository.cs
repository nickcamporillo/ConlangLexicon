using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lexicon.Legacy2019.IRepository
{
    /// <summary>
    /// Interface definition for IRepository.
    /// </summary>
    /// <typeparam name="T">The entity type for this repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Adds the specified entity to the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Removes the specified entity from the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(T entity);

        /// <summary>
        /// Find an object using a predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Query-able list of objects that match the predicate.</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds all objects. (You can use LINQ against this).
        /// </summary>
        /// <returns>Query-able list of all objects in the repository.</returns>
        IQueryable<T> FindAll();       
    }
}