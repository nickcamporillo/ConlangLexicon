using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;
using CRS.Models.Interfaces;

namespace CRS.Models
{
    //[CBorillo] See comments at top of "PageInventoryPartial.cs
    public partial class RolePermission:IRolePermission
    {
        IRole IRolePermission.Role 
        {
            get { return this.Role; }
            set { this.Role = value as Role; }
        }

        IWidgetInventory IRolePermission.WidgetInventory 
        {
            get { return this.WidgetInventory; }
            set { this.WidgetInventory = value as WidgetInventory; }
        }
    }
}
