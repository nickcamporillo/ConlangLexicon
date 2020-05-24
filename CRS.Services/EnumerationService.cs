using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IT.IRepository;
using CRS.App_Level;
using CRS.Models;
using CRS.Models.DTOs;
using CRS.Models.Interfaces;

namespace CRS.Services
{
    public class EnumerationService :  BaseService
    {
        public EnumerationService(IUnitOfWork uow, int accessCode)
            : base(uow, accessCode)
        {
        }

        public IList<T> GetEnumerationDetailsByTableName<T>(string consumingTableName) where T:IEnumerationInfo, new()
        {
            IList<T> results = new List<T>();
            IEnumeration masterRecord = base.FindItem<Enumerations>(m => m.Name == consumingTableName);
            IList<IEnumerationDetail> detailRecords = base.FindItems<EnumerationDetails>(d => d.EnumerationId == masterRecord.Id) as IList<IEnumerationDetail>;

            foreach (IEnumerationDetail det in detailRecords)
            {
                results.Add(new T { Id = det.Id, EnumerationId = det.EnumerationId, IntVal = det.IntVal, Text = det.EnumerationName, SortOrder = det.SortOrder, DisplayText = det.DisplayText });
            }

            return results;
        }

        public IEnumerationDetail GetSingleEnumerationDetailByName(string enumerationName)
        {
            IEnumerationDetail result = new EnumerationDetails();
            IEnumerationDetail detail = null;

            detail = base.FindItem<EnumerationDetails>(c => c.EnumerationName.Trim() == enumerationName.Trim());

            if (detail != null)
            {
                result.Id = detail.Id;
                result.EnumerationId = detail.EnumerationId;
                result.IntVal = detail.IntVal;
                result.EnumerationName = detail.EnumerationName;
                result.SortOrder = detail.SortOrder;
                result.DisplayText = detail.DisplayText;
            }

            return result;
        }

        public IList<string> GetEnumerationDisplayList(string enumerationName)
        {
            IList<string> displayItems = new List<string>();
            
            try
            {
                Enumerations q = base.FindItem<Enumerations>(c=>c.Name == enumerationName);
                EntityCollection<EnumerationDetails> dets = q.EnumerationDetails;
                foreach (EnumerationDetails det in dets)
                {
                    //Safeguard against null values.
                    if (det.DisplayText != null && det.DisplayText.Trim().Length != 0)
                    {
                        displayItems.Add(det.DisplayText);
                    }
                }
            }
            catch (Exception ex)
            {
                //This is most likely to happen if the lambda fails in getting values for "q"
            }

            return displayItems;
        }

        public IEnumerationDetail FindEnumerationDetailById(int id)
        {            
            return base.FindItemOf<EnumerationDetails, IEnumerationDetail>(c => c.Id == id);
        }

        public IList<IEnumerationDetail> FindEnumerationDetailsByName(string enumerationClassName)
        {
            return base.FindItemsOf<EnumerationDetails, IEnumerationDetail>(c => c.EnumerationName == enumerationClassName);
        }

        public IList<IEnumerationDetail> FindEnumerationDetailsByEnumerationId(int enumerationId)
        {
            IList<IEnumerationDetail> retVal = base.FindItems<EnumerationDetails>(e => e.EnumerationId == enumerationId).OfType<IEnumerationDetail>().ToList();
            return retVal;
        }

        public IList<IEnumerationDetail> FindEnumerationDetailsByRole(PermissionsService svc)
        {

            return null;
            //List<IRolePermission> rolePermits = svc.GetUsersAccessibleItems(this.AccessCode).ToList();
            
            //IList<IEnumerationDetail> permittedEnumerations = 
            //                       (from r in rolePermits                   
            //                        where r.WidgetInventory.EnumerationDetail.EnumerationName.Length > 0                                                         
            //                        select r.WidgetInventory.EnumerationDetail as IEnumerationDetail).ToList();

            //var lists = (from p in rolePermits
            //            where p.WidgetInventory.Lists.Count > 0
            //            select p.WidgetInventory.Lists).ToList();


            //return permittedEnumerations;
        }

        public IList<IEnumerationDetail> FindEnumerationDetailsByRoleAndEnumerationId(PermissionsService svc, int enumerationDetailId)
        {
            IList<IEnumerationDetail> permittedEnumerations = FindEnumerationDetailsByRole(svc);
            IList<IEnumerationDetail> retVal = permittedEnumerations.Where(c => c.Id == enumerationDetailId).ToList();
            return retVal;
        }

        public IEnumerationDetail FindEnumerationDetailsByAlias(string alias)
        {
            IEnumerationDetail retVal = base.FindItemOf<EnumerationDetails, IEnumerationDetail>(e => e.DisplayText == alias);
            return retVal;
        }

        public IList<Enumerations> GetAllEnumerationClasses()
        {
            return base.FindAll<Enumerations>();
        }
    }
}
