using System.Data;
namespace CRS.IRepository
{
    /// <summary>
    /// Interface definition for IUnitOfWork.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
        bool HasChanges();
        void RollBack();
        void ExecuteQuery(string query, out DataTable dt);
        void BulkInsert(DataTable data, string destinationTableName);
    }
}