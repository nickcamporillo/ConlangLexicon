using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IT.IRepository;

using CRS.App_Level;
using CRS.Models;
using CRS.Models.DTOs;

using Table = CRS.Models.Table;

namespace CRS.Services
{
    public class TableService : BaseService
    {
        public TableService(IUnitOfWork uow, int accessCode)
            : base(uow,accessCode)
        {
        }

        internal IList<ITable> GetRegisteredTables()
        {
            List<ITable> retVal = new List<ITable>();            
            var x = base.FindAll<Table>();
            retVal.AddRange(x);
            return retVal;
        }

        internal ITable GetTableByName(string queryStringByName)
        {
            return base.FindItem<Table>(c => c.Name == queryStringByName) as ITable;
        }
    }
}
