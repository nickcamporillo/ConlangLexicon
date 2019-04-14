using IModels;
using IServices;

namespace Services
{
    public interface ILexiconService<T> : IService<T> where T : class, new()
    {
        IModel GetFirstItem();
        object GetSortedItems();
        object SearchByEntry(string searchString, SearchStartPoint searchStartPoint);
        object SearchByMeaning(string searchString, SearchStartPoint searchStartPoint);
    }
}