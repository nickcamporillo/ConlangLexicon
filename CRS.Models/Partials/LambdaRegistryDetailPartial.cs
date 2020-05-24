using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;
using LambdaRegistry = CRS.Models.LambdaRegistry;

namespace CRS.Models
{
    public partial class LambdaRegistryDetail:ILambdaRegistryDetail
    {
        IEnumerationDetail ILambdaRegistryDetail.EnumerationDetail
        {
            get { return this.EnumerationDetail; }
            set { this.EnumerationDetail = value as EnumerationDetails; }
        }

        ILambdaRegistry ILambdaRegistryDetail.LambdaRegistry
        {
            get { return this.LambdaRegistry; }
            set { this.LambdaRegistry = value as LambdaRegistry; }
        }
    }
}