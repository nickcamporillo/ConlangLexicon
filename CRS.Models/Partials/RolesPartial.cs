using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;
using CRS.Models.Interfaces;

namespace CRS.Models
{
    public partial class Role:IRole
    {

        IEnumerationDetail IRole.EnumerationDetail
        {
            get {return this.EnumerationDetail;}
            set { this.EnumerationDetail = (EnumerationDetails) value; }
        }
    }
}
