using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Services
{
    [Obsolete("Replaced by DataserviceGetDataInvoker.cs")]
    public class DataserviceGetAllInvoker<T> : IDataServicesInvoker
    {
        private GetDataSet<T> _getAllEntities;

        public IEnumerationDetail EnumerationDetail { get; set; }
        public object DataResultSet { get; private set; }

        public DataserviceGetAllInvoker(IEnumerationDetail detailOfInvoker, GetDataSet<T> userGet)
        {
            this.EnumerationDetail = detailOfInvoker;
            _getAllEntities += userGet;
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
        }
    }


 

    public class DataserviceApplicantsInvoker : IDataServicesInvoker
    {
        public IEnumerationDetail EnumerationDetail { get; set; }
        public object DataResultSet { get; private set; }

        public DataserviceApplicantsInvoker(IEnumerationDetail detail)
        {
            this.EnumerationDetail = detail;
        }

        public void Execute(IEnumerationDetail targetInvokeeEnumerationDetail)
        {
            if (this.EnumerationDetail != null && this.EnumerationDetail.Id == targetInvokeeEnumerationDetail.Id)
            {
                Execute();
            }
        }

        public void Execute()
        {

        }

        //private object ShowApplicantsOnGrid(int ownerId, string selectedItem, string controlName)
        //{
        //    object retVal = null;

        //    Func<CRS.Models.Applicants, bool> predicate1 = new Func<CRS.Models.Applicants, bool>(c => c.AddedBy != 10);

        //    //GetListItemsByWidgetId(controlName) = _metaServices.GetListItemsByWidgetId(_metaServices.GetWidgetByName(ctrl.Name).Id);

        //    IList<CRS.Models.List> listItems = GetListItemsByWidgetId(controlName);
        //    CRS.Models.List listItem = listItems.SingleOrDefault(c => c.EnumerationDetail.DisplayText == selectedItem);
        //    IEnumerationDetail det = listItem.EnumerationDetail;


        //    this.DataResultSet = retVal; // _dataService.GetApplicantsSummaries(det.IntVal, predicate1);
        //}
    }
}
