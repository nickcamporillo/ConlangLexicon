using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CRS.Models;
using CRS.Models.DTOs;
using CRS.IRepository;
using CRS.Repository;

namespace CRS.Services
{
    public class ApplicantOutcomesService : BaseService<ApplicantOutcome>, IService
    {
        public ApplicantOutcomesService()
            : base(EfContext.CONNECTION_STRING)
        { 

        }

        public IList<ApplicantOutcome> GetAllApplicantOutcomes()
        {
            return Entities.FindAll().ToList();
        }


        

        //NOTE: The ApplicantOutcome entity must have ALL properties populated.  
        //This is bc its table does not accept any nulls!
        public void SaveApplicantOutcomes(ApplicantOutcome applicant)
        {
            base.Save(applicant);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
