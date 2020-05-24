using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.Models.Interfaces;

namespace CRS.Models.DTOs
{
    [Obsolete("No longer used in app, so delete when get chance.  DO NOT USE")]
    public class ApplicantSummary:IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AddedBy { get; set; }
        public string CreatedDate { get; set; }
        public string GsEligibility { get; set; }
        public string VetPreference { get; set; }
        public string InterviewDate { get; set; }
        public bool DeclinedOffer { get; set; }
        public int Status { get; set; }        
    }
}
