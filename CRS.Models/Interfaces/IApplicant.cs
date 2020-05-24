using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRS.Models.Interfaces
{
    public interface IApplicant:IPerson
    {
        int AddedBy { get;set;}
        int Ownership { get; set; }
        int VeteransPreference { get; set; }
        int Series { get;set;}
        string DateCreated { get; set; }
        string DateDeactivated { get; set; }    
        string Active  { get;set;}    
        int Status { get; set; }    
        string Division { get;set;}    
        string Gender { get;set;}
    }
}
