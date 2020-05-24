using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IT.IRepository;
using CRS.Repository;
using CRS.Models.Interfaces;

namespace CRS.Services
{
    public class DataServiceFactory
    {
        private IUnitOfWork _uow = null;

        public int AccessCode { get; private set; }

        public DataServiceFactory(int accessCode)
        {
            this.AccessCode = accessCode;
            _uow = new EfUnitOfWork();
        }

        public UserService<IUser> CreateUserService<T>()
        {
            return new UserService<IUser>(_uow, this.AccessCode);
        }

        public ApplicantsService<IApplicant> CreateApplicantService<T>()
        {
            return new ApplicantsService<IApplicant>(_uow, this.AccessCode);
        }
    }
}
