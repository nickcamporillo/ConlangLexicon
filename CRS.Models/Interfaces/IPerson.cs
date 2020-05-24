using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Models.Interfaces
{
    public interface IPerson:IPrimitive
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
    }
}
