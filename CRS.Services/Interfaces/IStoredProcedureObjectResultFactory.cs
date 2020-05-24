using System;
using System.Data.Objects;
using System.Reflection;

namespace CRS.Services
{
    [Obsolete("This was used to experiment with using EF and stored procedures in the db.  Please don't use this func anymore!")]
    public interface IStoredProcedureObjectResultFactory
    {
        ObjectResult<T> GetIndividualByOwnerIdAndStatusCode<T>(object context, int ownerId, int statusCode);
    }
}
