using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CRS.App_Level;
using CRS.Models.Interfaces;

namespace CRS.Services
{
    public class MetaServices<P>: IMetaServices where P:IRolePermission
    {
        private TableService _tblInventorySvc = null;
        private EnumerationService _enumerationSvc = null;
        private WidgetService<P> _widgetSvc = null;
        private PermissionsService _permissionSvc = null;
        private RoleService _roleSvc = null;
        //private QueryRegistryService _qrySvc = null;
        private LambdaRegistryService _lambdaSvc = null;

        public int AccessCode
        {
            get;
            private set;
        }

        public MetaServices(MetaServiceFactory factory)
        {
            this.AccessCode = factory.AccessCode;

            _tblInventorySvc = factory.CreateTableInventoryService();
            _enumerationSvc = factory.CreateEnumerationService();
            _widgetSvc = factory.CreateWidgetService<P>();
            _permissionSvc = factory.CreatePermissionService();
            _roleSvc = factory.CreateRoleService();
            //_qrySvc = factory.CreateQueryRegistryService();
            _lambdaSvc = factory.CreateLambdaRegistryService();
        }

        public IList<IRolePermission> GetUsersPages()
        {
            return _widgetSvc.GetUsersPages(_permissionSvc);
        }

        public IList<IRolePermission> GetUsersAccessibleItemsOnPage(int pageId)
        {
            return _permissionSvc.GetUsersAccessibleItemsOnPage(AccessCode, pageId);
        }

        public IPageInventoryShared GetPageInfoByName(string pageName)
        {
            return _widgetSvc.GetPageInfoByName(pageName);
        }

        public IPageInventoryShared GetPageByAlias(string pageAlias)
        {
            return _widgetSvc.GetPageByAlias(pageAlias);
        }

        public IWidgetInventory GetWidgetById(int id)
        {
            return _widgetSvc.GetWidgetById(id);
        }

        public IWidgetInventory GetWidgetByName(string widgetName)
        {
            return _widgetSvc.GetWidgetByName(widgetName);
        }

        public IEnumerationDetail FindEnumerationDetailById(int id)
        {
            return _enumerationSvc.FindEnumerationDetailById(id);
        }

        public IList<IEnumerationDetail> FindEnumerationDetailsByEnumerationId(int enumerationId)
        {
            return _enumerationSvc.FindEnumerationDetailsByEnumerationId(enumerationId);
        }

        public IList<string> GetEnumerationDisplayList(string name)
        {
            return _enumerationSvc.GetEnumerationDisplayList(name);
        }


        public IList<IListItem> GetListItemsByWidgetId(int widgetId)
        {
            return _widgetSvc.GetListItemsByWidgetId(widgetId) as IList<IListItem>;
        }

        public IList<IListItem> GetListItemsByWidgetIdAndAccessCode(int widgetId)
        {
            return _widgetSvc.GetListItemsByWidgetIdAndAccessCode(widgetId);
        }

        public IList<IListItem> GetListItemElementsOfWidget(int pageId, string widgetName)
        {
            IList<IListItem> retVal = _widgetSvc.GetListItemsByPageAndWidgetName(pageId, widgetName);
            return retVal.Where(c => c.AccessCode == this.AccessCode).ToList();
        }

        public IList<string> GetListItemsOfWidgetAsText(int pageId, string widgetName)
        {
            return _widgetSvc.GetListItemsOfWidgetAsText(pageId, widgetName);
        }

        public IList<IRole> GetAllRoles()
        {
            return _roleSvc.GetAllRoles(); 
        }

        public IRole GetCurrentRole()
        {
            return _roleSvc.GetRoleByAccessCode(this.AccessCode);
        }

        public int GetCurrentAccessRoleCode()
        {
            return this.AccessCode;
        }

        public IRole GetRoleByAccessCode(int accessCode)
        {
            return _roleSvc.GetRoleByAccessCode(accessCode);
        }

        //public IQueryRegistry GetRegisteredQueryByEnumerationDetailIdOfSelectedItem(int enumerationIdOfSelection)
        //{
        //    return _qrySvc.GetRegisteredQueryByEnumerationDetailIdOfSelectedItem(enumerationIdOfSelection);
        //}

        //public IQueryRegistry GetRegisteredQueryByEnumerationDetailOfSelectedItem(IEnumerationDetail enumerationDetail)
        //{
        //    return _qrySvc.GetRegisteredQueryByEnumerationDetailOfSelectedItem(enumerationDetail);            
        //}

        public IList<ILambdaRegistryDetail> GetUsersLambdaInfo()
        {
            return _lambdaSvc.GetUsersLambdaInfo();
        }
    }
}
