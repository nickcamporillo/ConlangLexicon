using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;
using CRS.Models.Interfaces;

namespace CRS.Models
{
    public partial class Users: IUser
    {
        public IEnumerationDetail RoleDetail { get; set; }
    }
}
