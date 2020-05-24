using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Services
{
    public class DataserviceGetDataInvoker<TEntity> : IDataServicesInvoker
    {
        private GetDataSet<TEntity> _getAllEntities;
        private GetDataFromLambda<TEntity> _queryByLambda;
        private Func<TEntity, bool> _predicate;

#region Properties

        public IEnumerationDetail EnumerationDetail { get; set; }
        public object DataResultSet { get; private set; }

#endregion

        public DataserviceGetDataInvoker(IEnumerationDetail detailOfInvoker, GetDataSet<TEntity> userGetAllEntities)
        {
            this.EnumerationDetail = detailOfInvoker;
            _getAllEntities += userGetAllEntities;
        }

        public DataserviceGetDataInvoker(IEnumerationDetail detailOfInvoker, GetDataFromLambda<TEntity> queryByLambda, Func<TEntity, bool> predicate)
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
            if (_getAllEntities != null)
            {
                DataResultSet = _getAllEntities.Invoke();
            }
            else if (_queryByLambda != null && _predicate != null)
            {
                DataResultSet = _queryByLambda.Invoke(_predicate);
            }
        }
    }
}
