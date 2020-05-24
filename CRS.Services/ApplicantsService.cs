using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using IT.IRepository;

using CRS.Models.DTOs;
using CRS.Repository;
using CRS.Models.Interfaces;

using Applicant = CRS.Models.Applicants;

namespace CRS.Services
{

    //NOTE:  This class is using EF for a STORED PROCEDURE, which is why you see 
    //Connection-related code here!
    public class ApplicantsService<T>: BaseService where T:IApplicant
    {
        private IList<IApplicant> _applicantsAll = new List<IApplicant>();

        #region Properties

        public bool CouldNotConnectToDb
        {
            get;
            private set;
        }

        public string ConnectionErrorMessage
        {
            get;
            private set;
        }

        #endregion
        
        public ApplicantsService(IUnitOfWork uow, int accessCode)
            :base(uow,accessCode)
        {
            try
            {
                var resultSet = base.FindAll<Applicant>();
                //Data conversions:
                List<IApplicant> dataset = new List<IApplicant>();
                dataset.AddRange(resultSet);
                _applicantsAll = dataset as IList<IApplicant>;
            }
            catch (Exception ex)
            {
                CouldNotConnectToDb = true;
                ConnectionErrorMessage = ex.Message + (ex.InnerException != null && ex.InnerException.Message != null && ex.InnerException.Message.Length > 0 ? ex.InnerException.Message + "\n\n" : "");
                ConnectionErrorMessage = ConnectionErrorMessage + (ex.StackTrace != null && ex.StackTrace.Length > 0 ? "\n\n" + ex.StackTrace : "");
            }
        }

        public IList<IApplicant> GetAllApplicants()
        {
            return _applicantsAll;
        }

        public IApplicant GetApplicant(Func<IApplicant, bool> predicate)
        {
            return _applicantsAll.FirstOrDefault(predicate);
        }

        public IList<IApplicant> GetApplicants(Func<IApplicant, bool> predicate)
        {
            return _applicantsAll.Where(predicate).ToList();
        }

        public void AddApplicant(IApplicant applicant)
        {
            base.Add(applicant);
        }

        public void Save()
        {
            base.SaveAndCommit();
        }

        //NOTE: This is a Stored Procedure in the db called "QueryDbForActiveApplicants"
        public IList<T> DbQueryForActiveApplicantsAndOwner<T>(int userId, int statusCode)
        {
            IContext context = new ContextFactory().CreateObjectContext();
            IStoredProcedureObjectResultFactory fac = new ApplicantServiceStoredProcedureObjectResultFactory();
            ObjectResult<T> dets = fac.GetIndividualByOwnerIdAndStatusCode<T>(context, userId, statusCode);
            return (dets == null ? null : dets.ToList());
        }

    }
}
