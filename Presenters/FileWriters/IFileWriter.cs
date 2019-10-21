using System.Collections.Generic;
using IModels;

namespace Presenters.FileWriters
{
    public interface IFileWriter
    {
        bool WriteFile<T>(List<T> resultSet) where T : IModel;
    }
}
