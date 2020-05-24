using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IT.IRepository;
using CRS.App_Level;
using CRS.Models.Interfaces;
using CRS.Repository;

namespace CRS.Services
{
    public class MetaServiceFactory
    {
        private IUnitOfWork _uow = null;

        public int AccessCode { get; private set; }

        public MetaServiceFactory(int accessCode)
        {
            _uow = new EfUnitOfWork();
            this.AccessCode = accessCode;
        }

        public TableService CreateTableInventoryService()
        {
            return new TableService(_uow, this.AccessCode);
        }

        public EnumerationService CreateEnumerationService()
        {
            return new EnumerationService(_uow, this.AccessCode);
        }

        public WidgetService<P> CreateWidgetService<P>() where P:IRolePermission
        {
            return new WidgetService<P>(_uow, this.AccessCode);
        }

        public PermissionsService CreatePermissionService()
        {
            return new PermissionsService(_uow, this.AccessCode);
        }

        public RoleService CreateRoleService()
        {
            return new RoleService(_uow, this.AccessCode);
        }

        public QueryRegistryService CreateQueryRegistryService()
        {
            return new QueryRegistryService(_uow, this.AccessCode);
        }

        public LambdaRegistryService CreateLambdaRegistryService()
        {
            return new LambdaRegistryService(_uow, this.AccessCode);
        }
    }
}
