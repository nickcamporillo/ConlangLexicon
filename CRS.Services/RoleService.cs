using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IT.IRepository;

using CRS.App_Level;
using CRS.Models.Interfaces;
using CRS.Models.DTOs;
using Role = CRS.Models.Role;

namespace CRS.Services
{
    public class RoleService: BaseService
    {                
        public RoleService(IUnitOfWork uow, int accessCode)        
            :base(uow,accessCode)                
        {
            base.AccessCode = accessCode;        
        }

        internal IRole GetCurrentRole()
        {
            return GetRoleByAccessCode(base.AccessCode);
        }

        internal IRole GetRoleByAccessCode(int accessCode)
        {
            return this.GetAllRoles().Where(c => c.EnumerationDetail.IntVal == accessCode).FirstOrDefault();
        }

        internal IList<IRole> GetAllRoles()
        {
            var x = base.FindAll<Role>();
            List<IRole> retVal = new List<IRole>();
            retVal.AddRange(x);
            return retVal;
        }

        internal void AddRole(IRole role)
        {
            base.Add<IRole>(role);
        }
    }
}
