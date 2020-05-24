using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using IT.IRepository;

using CRS.App_Level;
using CRS.Models.DTOs;
using CRS.Models.Interfaces;


using User = CRS.Models.Users;

namespace CRS.Services
{
    public class UserService<T>: BaseService where T:IUser
    {
        public event EventHandler UserNotProvided;

        public UserService(IUnitOfWork uow, int accessCode):
            base(uow, accessCode)
        {
        }
        
        public IList<IUser> GetAllUsers()
        {
            //[CBorillo] The following line is an example of where I would countenance the use of "var", because using typical "IList<IUser>" 
            //wouldn't typecast and I want the AddRange(args) func of "List<T>" which isn't available in "IList<T>"
            var users = base.FindAll<User>();   
            List<IUser> retVal = new List<IUser>();
            retVal.AddRange(users);
            
            foreach (IUser usr in users)
            {                
                usr.RoleDetail = GetRoleDetail(usr);
                retVal.Add(usr);
            }

            return retVal;
        }

        public IUser GetUserByUserName(string userName)
        {
            IUser retVal = GetUser(c => c.JamesBond == userName);

            if (retVal == null)
            {
                AlertSubscribersNoUserProvided();
                return null;
            }

            return retVal;
        }

        public IUser GetUserById(int id)
        {
            IUser retVal = GetUser(c => c.Id == id);
            return retVal;
        }

        public IList<IUser> GetUsersByRole(int accessCode)
        {
            IList<IUser> retVal = GetUsers(c=> c.AccessCode == accessCode);           
            return retVal;
        }

        public IList<IUser> GetUsers(Func<IUser,bool> predicate)
        {
            IList<IUser> users = GetAllUsers().Where(predicate).ToList();
            return users;
        }

        public IUser GetUser(Func<IUser, bool> predicate)
        {
            IUser user = GetUsers(predicate).FirstOrDefault();
            return user;
        }

        public void AddUser(IUser user)
        {
            if (user == null)
            {
                AlertSubscribersNoUserProvided();
                return;
            }

            base.Add(user);
        }

        private IEnumerationDetail GetRoleDetail(IUser usr)
        {
            if (usr == null)
            {
                AlertSubscribersNoUserProvided();
                return null;
            }

            MetaServiceFactory factory = new MetaServiceFactory(base.AccessCode);
            RoleService svc = factory.CreateRoleService();
                        
            IRole role = svc.GetCurrentRole();

            svc = null;
            factory = null;

            return role.EnumerationDetail;
        }

        private void AlertSubscribersNoUserProvided()
        {
            if (UserNotProvided != null)
            {
                UserNotProvided.Invoke(this, new EventArgs());
            }        
        }
    }
}