using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Models
{
    public partial class WidgetInventory: IWidgetInventory
    {

        IPageInventoryShared IWidgetInventory.PageInventory
        {
            get
            {
                return this.PageInventory;
            }
            set
            {
                this.PageInventory = value as PageInventory;                
            }
        }
    }
}
