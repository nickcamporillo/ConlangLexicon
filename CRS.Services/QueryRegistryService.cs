using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IT.IRepository;

using CRS.App_Level;
using CRS.Models.Interfaces;
using CRS.Models.DTOs;
using QueryRegistry = CRS.Models.QueryRegistry;

namespace CRS.Services
{
    public class QueryRegistryService: BaseService
    {
        public QueryRegistryService(IUnitOfWork uow, int accessCode)        
            :base(uow,accessCode)                
        {
            base.AccessCode = accessCode;        
        }

        internal IList<IQueryRegistry> GetAllQueries()
        {
            var x = base.FindAll<QueryRegistry>();
            List<IQueryRegistry> retVal = new List<IQueryRegistry>();
            retVal.AddRange(x);
            return retVal;
        }

        internal IQueryRegistry GetRegisteredQueryByEnumerationDetailIdOfSelectedItem(int id)
        {
            IQueryRegistry retVal = base.FindItem<QueryRegistry>(c=> c.PickerId == id);
            retVal.Selection = retVal.EnumerationDetail;
            return retVal;
        }

        internal IQueryRegistry GetRegisteredQueryByEnumerationDetailOfSelectedItem(IEnumerationDetail enumerationDetail)
        {
            return this.GetRegisteredQueryByEnumerationDetailIdOfSelectedItem(enumerationDetail.Id);
        }

        internal void AddQuery(IQueryRegistry query)
        {
            base.Add<IQueryRegistry>(query);
        }
    }
}
