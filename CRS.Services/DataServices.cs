using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRS.App_Level;
using CRS.Models.Interfaces;

namespace CRS.Services
{
    public class DataServices : IService
    {
        public event EventHandler UserNotProvided;

        private UserService<IUser> _usrSvc = null;
        private ApplicantsService<IApplicant> _applicantSvc = null;
        private IList<IDataServicesInvoker> _invokerRegistry = new List<IDataServicesInvoker>();

        public IList<int> RegisteredEnumerationIds { get; private set; }

        public int AccessCode
        {
            get;
            private set;
        }

        public DataServices(DataServiceFactory factory)
        {
            this.AccessCode = factory.AccessCode;
            this.RegisteredEnumerationIds = new List<int>();

            _usrSvc = factory.CreateUserService<IUser>();
            _applicantSvc = factory.CreateApplicantService<IApplicant>();
        }

        public IList<IUser> GetAllUsers() 
        {
            return  _usrSvc.GetAllUsers();
        }

        public IList<IUser> GetUsersByRole(int roleCode)
        {
            return (IList<IUser>)_usrSvc.GetUsersByRole(roleCode);
        }

        public IUser GetUserById(int userId)
        {
            return _usrSvc.GetUserById(userId);
        }

        public IList<IUser> GetUsersByQuery(Func<IUser, bool> predicate)
        {
            return _usrSvc.GetUsers(predicate);
        }

        public IPerson GetUserByUserName(string userName)
        {
            return _usrSvc.GetUserByUserName(userName);
        }

        public IList<IApplicant> GetAllApplicants()
        {
            return _applicantSvc.GetAllApplicants();
        }

        public IList<IApplicant> GetApplicants(Func<IApplicant, bool> predicate)
        {
            return _applicantSvc.GetApplicants(predicate);
        }

        public IApplicant GetApplicant(Func<IApplicant, bool> predicate)
        {
            return _applicantSvc.GetApplicant(predicate);
        }

        public IList<IDataServicesInvoker> AddTargetInvoker<T>(IEnumerationDetail registryItem, GetDataSet<T> getAll)
        {
            if (this.SafeToRegister(registryItem))
            {
                _invokerRegistry.Add(new DataserviceGetDataInvoker<T>(registryItem, getAll));
            }
            return _invokerRegistry;
        }

        public IList<IDataServicesInvoker> AddTargetInvoker<T>(IEnumerationDetail registryItem,  GetDataFromLambda<T> queryByLambda, Func<T, bool> predicate)
        {
            if (this.SafeToRegister(registryItem))
            {
                _invokerRegistry.Add(new DataserviceGetDataInvoker<T>(registryItem, queryByLambda, predicate));
            }
            return _invokerRegistry;
        }

        private bool SafeToRegister(IEnumerationDetail registryItem)
        {
            bool retVal = false;

            if (this.RegisteredEnumerationIds.Contains(registryItem.Id) == false)
            {
                this.RegisteredEnumerationIds.Add(registryItem.Id);
                retVal = true;
            }            

            return retVal;
        }

        public void ClearInvokerList()
        {
            this.RegisteredEnumerationIds.Clear();
            _invokerRegistry.Clear();
        }

        public object yep(IEnumerationDetail registryItem, IEnumerationDetail selectedEnumDetail)
        {
            if (_invokerRegistry == null)
            {
                _invokerRegistry = new List<IDataServicesInvoker>();
                return null;
            }
            
            IDataServicesInvoker selectAll = null;
            IDataServicesInvoker selectSubset = null;
            IList<IDataServicesInvoker> dataResultInvokers = new List<IDataServicesInvoker>();

            object resultSet = null;

            dataResultInvokers = _invokerRegistry.ToList();

            foreach (IDataServicesInvoker invoker in dataResultInvokers)
            {
                if (invoker != null && invoker.EnumerationDetail != null)
                {
                    invoker.Execute(selectedEnumDetail);
                    resultSet = invoker.DataResultSet;
                    if (resultSet != null)
                    {
                        return resultSet;
                    }
                }
            }

            return resultSet;
        }
    }
}
