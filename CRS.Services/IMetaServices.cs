using System;
using System.Collections.Generic;
using CRS.App_Level;

namespace CRS.Services
{
    public interface IMetaServices: IService
    {
        IEnumerationDetail FindEnumerationDetailById(int id);
        IList<IEnumerationDetail> FindEnumerationDetailsByEnumerationId(int enumerationId);
        IList<IRole> GetAllRoles();
        int GetCurrentAccessRoleCode();
        IRole GetCurrentRole();
        IList<string> GetEnumerationDisplayList(string name);
        IList<IListItem> GetListItemElementsOfWidget(int pageId, string widgetName);
        IList<IListItem> GetListItemsByWidgetId(int widgetId);
        IList<IListItem> GetListItemsByWidgetIdAndAccessCode(int widgetId);
        IList<string> GetListItemsOfWidgetAsText(int pageId, string widgetName);
        IPageInventoryShared GetPageByAlias(string pageAlias);
        IPageInventoryShared GetPageInfoByName(string pageName);
        IRole GetRoleByAccessCode(int accessCode);
        IList<IRolePermission> GetUsersAccessibleItemsOnPage(int pageId);
        IList<IRolePermission> GetUsersPages();
        IWidgetInventory GetWidgetByName(string widgetName);
        IList<ILambdaRegistryDetail> GetUsersLambdaInfo();
    }
}
