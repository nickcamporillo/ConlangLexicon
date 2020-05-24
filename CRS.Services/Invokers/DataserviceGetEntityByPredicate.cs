using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRS.App_Level;

namespace CRS.Services
{
    public class DataserviceGetEntityByPredicate<T> : IDataServicesInvoker
    {
        private GetDataFromLambda<T> _queryByLambda;
        private Func<T, bool> _predicate;

        public IEnumerationDetail EnumerationDetail { get; set; }
        public object DataResultSet { get; private set; }

        public DataserviceGetEntityByPredicate(IEnumerationDetail detailOfInvoker, GetDataFromLambda<T> queryByLambda, Func<T, bool> predicate)
        {
            this.EnumerationDetail = detailOfInvoker;
            _queryByLambda += queryByLambda;
            _predicate = predicate;
        }

        public void Execute(IEnumerationDetail targetInvokeeEnumerationDetail)
        {
            if (this.EnumerationDetail != null && this.EnumerationDetail.Id == targetInvokeeEnumerationDetail.Id)
            {
                this.Execute();
            }
        }

        public void Execute()
        {
            if (_queryByLambda != null && _predicate != null)
            {
                DataResultSet = _queryByLambda.Invoke(_predicate);
            }
        }
    }
}
