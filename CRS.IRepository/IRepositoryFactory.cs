namespace CRS.IRepository
{
    /// <summary>
    /// Interface definition for IRepositoryFactory.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Creates a repository of entity objects of the supplied type.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <returns>A repository of entity objects of the supplied type.</returns>
        IRepository<T> CreateRepository<T>() where T : class;
    }
}