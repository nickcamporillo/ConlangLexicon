using System;
using System.Data.Common;


namespace CRS.Repository
{
    public interface IContextFactory
    {
        IContext CreateObjectContext();
        IContext CreateObjectContext(string userId);
    }
}
