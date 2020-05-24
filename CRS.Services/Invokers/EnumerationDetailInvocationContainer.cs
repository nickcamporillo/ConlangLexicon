using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CRS.App_Level;

namespace CRS.Services
{
    public class EnumerationDetailInvocationContainer<TEntity>: IPrimitive, IDisposable where TEntity:class
    {
        private int _id = 0;

        public int Id 
        {
            set { ; } //Deny setting from outside
            get { return _id; } 
        }

        public object Datasource 
        { 
            get { return ResultSet; }
            set { ;} 
        }

        public IEnumerationDetail EnumerationDetail { get; private set; }
        private GetDataSet<TEntity> DatasetResults { get; set; }
        private GetDataFromLambda<TEntity> DataSubset { get; set; }
        private Func<TEntity, bool> LambdaQuery { get; set; }

        public List<EnumerationDetailInvocationContainer<TEntity>> InvocationList
        {
            get;
            private set;
        }

        public EnumerationDetailInvocationContainer(IEnumerationDetail enumerationDetail, GetDataSet<TEntity> dataSetCallback)
        {
            _id = enumerationDetail.Id;
            this.EnumerationDetail = enumerationDetail;
            this.DatasetResults = dataSetCallback;

            this.InvocationList = new List<EnumerationDetailInvocationContainer<TEntity>>();
            this.Add(this);
        }

        public EnumerationDetailInvocationContainer(IEnumerationDetail enumerationDetail, Func<TEntity, bool> lambdaQuery, GetDataFromLambda<TEntity> dataSetCallback)
        {
            _id = enumerationDetail.Id;
            this.EnumerationDetail = enumerationDetail;
            this.LambdaQuery = lambdaQuery;
            this.DataSubset = dataSetCallback;

            this.InvocationList = new List<EnumerationDetailInvocationContainer<TEntity>>();
            this.Add(this);
        }

        public void CreatePredicate(IEnumerationDetail detail)
        { 
        }

        public void Add(IEnumerationDetail enumerationDetail, GetDataSet<TEntity> dataSetCallback)
        {
            var newInvocation = new EnumerationDetailInvocationContainer<TEntity>(enumerationDetail, dataSetCallback);
            this.Add(newInvocation);
        }

        public void Add(IEnumerationDetail enumerationDetail, Func<TEntity, bool> lambdaQuery, GetDataFromLambda<TEntity> dataSetCallback)
        {
            var newInvocation = new EnumerationDetailInvocationContainer<TEntity>(enumerationDetail,lambdaQuery, dataSetCallback);
            this.Add(newInvocation);
        }

        public void Add(EnumerationDetailInvocationContainer<TEntity> newInvocation)
        {
            int id = newInvocation.Id;
            
            //Id is required
            if (id == 0)
            {
                return;
            }

            var existingElement = this.InvocationList.Where(c => c.Id == newInvocation.Id).ToList();
            if (this.LambdaQuery != null && this.DataSubset != null)
            {
                this.InvocationList.Add(newInvocation);
            }
            else if (this.DatasetResults != null && (existingElement == null || existingElement.Count == 0))
            {
                this.InvocationList.Add(newInvocation);
            }
        }

        public void RemoveElementsById(int id)
        {
            var existingElement = this.InvocationList.Where(c => c.Id == id).ToList();
            if (existingElement != null && existingElement.Count > 0)
            {
                this.InvocationList.RemoveRange(0, existingElement.Count - 1);
            }
        }

        public void RemoveElementsByIdAndCallBack(int id, GetDataSet<TEntity> callBack)
        {
            var existingElement = this.InvocationList.Where(c => c.Id == id && c.DatasetResults == callBack).FirstOrDefault();

            if (existingElement != null)
            {
                this.InvocationList.Remove(existingElement);
            }
        }

        public void RemoveElementsByIdAndCallBack(int id, Func<TEntity, bool> lambdaQuery, GetDataFromLambda<TEntity> callBack)
        {
            var existingElement = this.InvocationList.Where(c => c.Id == id && c.LambdaQuery == lambdaQuery && c.DataSubset == callBack).FirstOrDefault();
            if (existingElement != null)
            {
                this.InvocationList.Remove(existingElement);
            }
        }

        private List<TEntity> ResultSet { get; set; }

        public void Invoke(EnumerationDetailInvocationContainer<TEntity> targetInvocation)
        {
            if (ResultSet == null)
            {
                ResultSet = new List<TEntity>();
            }

            //Sorry, I had to use "var" in this codeblock. I've been unable to use explicit declarations
            if (this.InvocationList.Contains(targetInvocation))
            {
                if (LambdaQuery != null)
                {   
                    var dataSubset = targetInvocation.DataSubset.Invoke(targetInvocation.LambdaQuery);
                    if (dataSubset != null && dataSubset.Count > 0)
                    {
                        ResultSet.AddRange(dataSubset);
                    }
                }
                else
                {
                    var datasetEntireSet = targetInvocation.DatasetResults.Invoke();
                    if (datasetEntireSet != null)
                    {
                        ResultSet.AddRange(datasetEntireSet);
                    }
                }
            }            
        }

        public void Invoke(int index)
        {
            if (this.InvocationList != null && index > 0 && index < this.InvocationList.Count)
            {
                this.Invoke(this.InvocationList[index]);
            }
        }

        public void ClearInvocationList()
        {
            this.InvocationList.Clear();
        }

        public void Dispose()
        {
            if (this.InvocationList != null && this.InvocationList.Count > 0)
            {
                this.InvocationList.Clear();
                this.InvocationList = null;
            }

            this.EnumerationDetail = null;
            this.LambdaQuery = null;
            this.DatasetResults = null;
            this.DataSubset = null;
        }
    }
}
