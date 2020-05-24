using System.Data;
namespace Lexicon.Legacy2019.IRepository
{
    /// <summary>
    /// Interface definition for IUnitOfWork.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        IRepository<T> GetRepository<T>() where T: class;
        void SaveChanges();
        bool HasChanges();
        void RollBack();
        void ExecuteQuery(string query, out DataTable dt);
        void BulkInsert(DataTable data, string destinationTableName);
    }
}