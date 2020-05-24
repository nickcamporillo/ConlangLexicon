using Lexicon.Legacy2019.IRepository;

namespace Lexicon.Legacy2019.Repositories
{
    /// <summary>
    /// Concrete implementation of IRepositoryFactory for Entity Framework.
    /// </summary>
    public class EfRepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// The Entity Framework context.
        /// </summary>
        private IContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepositoryFactory"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfRepositoryFactory(IContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a repository of entity objects of the supplied type.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <returns>A repository of entity objects of the supplied type.</returns>
        public IRepository<T> CreateRepository<T>() where T : class
        {
            return new EfRepository<T>(this._context);
        }
    }
}