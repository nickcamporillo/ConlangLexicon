using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Models
{
    public partial class LambdaRegistry:ILambdaRegistry
    {
        IEnumerationDetail ILambdaRegistry.EnumerationDetail
        {
            get { return this.EnumerationDetail; }
            set { this.EnumerationDetail = value as EnumerationDetails; }
        }
    }
}
