using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Models
{
    public partial class QueryRegistry:IQueryRegistry
    {
        IEnumerationDetail IQueryRegistry.EnumerationDetail
        {
            get { return this.EnumerationDetail; }
            set { this.EnumerationDetail = value as EnumerationDetails; }
        }


        IEnumerationDetail IQueryRegistry.Selection
        {
            get;
            set;
        }
    }
}
