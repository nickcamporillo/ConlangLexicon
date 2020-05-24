namespace Lexicon.Legacy2019.Repositories
{
    public interface IContextFactory
    {
        IContext CreateObjectContext();
        IContext CreateObjectContext(string userId);
    }
}
