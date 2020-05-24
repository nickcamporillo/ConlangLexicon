using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.Models.Interfaces;
using CRS.App_Level;

namespace CRS.Models
{
    public partial class List : IListItem
    {
        IEnumerationDetail IListItem.EnumerationDetail
        {
            get { return this.EnumerationDetail;}
            set { this.EnumerationDetail = value as EnumerationDetails;}
        }
    }
}
