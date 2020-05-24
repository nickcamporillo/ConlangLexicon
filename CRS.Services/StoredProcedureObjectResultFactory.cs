using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using IT.IRepository;
using CRS.Repository;

namespace CRS.Services
{
    public class ApplicantServiceStoredProcedureObjectResultFactory : IStoredProcedureObjectResultFactory
    {
        public ObjectResult<T> GetIndividualByOwnerIdAndStatusCode<T>(object context, int ownerId, int statusCode)
        {
            var ttt = context as EfContext;
            ObjectResult<T> retVal = null;

            //if (ttt != null)
            //{
            //    retVal = ttt.QueryDbForActiveApplicants(ownerId, statusCode) as ObjectResult<T>;
            //}

            return retVal;
        }
    }
}
