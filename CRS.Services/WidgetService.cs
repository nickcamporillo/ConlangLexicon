using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IT.IRepository;

using CRS.App_Level;
using CRS.App_Level.Utilities;
using CRS.Models;
using CRS.Models.DTOs;

//[CBorillo] The reason I'm doing aliasing here is that when I have to regenerate the EF model, sometimes the
//models are pluralized, sometimes singularized. If such a thing were to occur, I would ordinarily have to
//hunt through all the code and pluralize or singularize accordingly.  This aliasing allows me to restrict
//modifications to just the "using" sections. For example, if a regeneration of the EF model turns
//"PageInventory" to "PageInventories", all I have to do is modify the "using" statement in the next line.
#region "Model Declarations"

using Permission = CRS.Models.RolePermission;
using ListItem = CRS.Models.List;

#endregion

namespace CRS.Services
{
    public class WidgetService<P>:BaseService where P: IRolePermission
    {
        private IList<IRolePermission> _permissions;
        private IList<IPageInventoryShared> _pages;
        private IList<IWidgetInventory> _widgets;
        private IList<IListItem> _listItems;

        public IList<string> CurrentListing { get; private set; }        

        public WidgetService(IUnitOfWork uow, int accessCode)
            : base(uow, accessCode)
        {
            CurrentListing = new List<string>();

            _permissions = new List<IRolePermission>();
            _widgets = new List<IWidgetInventory>();
            _pages = new List<IPageInventoryShared>();
            _listItems = new List<IListItem>();

            var permits = base.FindItems<Permission>(c => c.AccessCode == accessCode);
            ((List<IRolePermission>)(_permissions)).AddRange(permits);

            _widgets = ((from p in _permissions select p.WidgetInventory as IWidgetInventory))
                           .ToList().Distinct().ToList()
                           .ToList().OrderBy(ww => ww.PageId)
                           .ToList();

            if (_widgets == null)
                return; //Abort

            _pages = ((from x in _widgets select x.PageInventory)
                         .ToList().Distinct()
                         .ToList().OrderBy(cc => cc.PageOrder))
                         .ToList();

            if (_pages == null)
                return; //Abort


            foreach (WidgetInventory itm in _widgets)
            {
                List<IListItem> listItems = new List<IListItem>();
                var items = base.FindItems<ListItem>(c => c.WidgetId == itm.Id && c.AccessCode == accessCode);
                listItems.AddRange(items);

                if (listItems != null && listItems.Count > 0)
                {
                    ((List<IListItem>)(_listItems)).AddRange(listItems);
                }
            }

            _listItems = _listItems.OrderBy(c => c.EnumerationDetail.SortOrder).ToList();
        }

        internal IList<int> GetPageWidgetKey()
        {
            IList<int> pageTypes = new List<int>();
            foreach (PageInventory p in _pages)
            {
                pageTypes.Add(p.PageType.Value);
            }

            return pageTypes.Distinct().ToList();
        }

        internal IList<IRolePermission> GetUsersPages(PermissionsService permissionService)
        {
            IList<int> widgetCodesForPages = GetPageWidgetKey();
            List<IRolePermission> allowedPages = new List<IRolePermission>();
            IList<IRolePermission> accessibleItems = permissionService.GetUsersAccessibleItems(base.AccessCode);

            if (accessibleItems != null && accessibleItems.Count > 0)
            {
                foreach (int pageKey in widgetCodesForPages)
                {
                    IList<IRolePermission> items = accessibleItems.Where(c => c.WidgetInventory != null && c.WidgetInventory.WidgetType == pageKey).ToList();
                    if (items != null && items.Count > 0)
                        allowedPages.AddRange(items);
                }
            }

            return allowedPages;
        }

        internal IPageInventoryShared GetPageInfoByName(string pageName)
        {
            string arg = pageName.GetLastToken('.');

            IPageInventoryShared retVal = null;
            arg = (arg.Length > 0 ? arg : pageName);

            retVal = _pages.FirstOrDefault(c => c.Title == arg);
            
            return retVal;
        }

        internal IPageInventoryShared GetPageByAlias(string alias)
        {
            return _pages.FirstOrDefault(c => c.Aliases.Contains(alias));
        }

        internal IWidgetInventory GetWidgetById(int id)
        {
            return _widgets.FirstOrDefault(c => c.Id == id);
        }

        internal IWidgetInventory GetWidgetByName(string name)
        {
            return _widgets.FirstOrDefault(c => c.Name == name);
        }

        internal IList<IWidgetInventory> GetWidgetsOnPageByPageId(int pageId)
        {
            return (IList<IWidgetInventory>)_widgets.Where(c => c.PageId == pageId).ToList();
        }

        internal IList<IWidgetInventory> GetWidgetsByCode(int widgetCode)
        {
            return (IList<IWidgetInventory>)_widgets.Where(c => c.WidgetType == widgetCode).ToList();
        }

        internal IList<IWidgetInventory> GetWidgetsByName(string widgetName)
        {
            return (IList<IWidgetInventory>)_widgets.Where(c => c.Name == widgetName).ToList();
        }

        internal IList<IEnumerationDetail> GetEnumerationDetailsFromWidgetName(EnumerationService svc, string widgetName)
        {
            IList<IEnumerationDetail> retVal = new List<IEnumerationDetail>();
            IWidgetInventory widget = GetWidgetByName(widgetName);
            IList<IListItem> query = GetListItemsByWidgetIdAndAccessCode(widget.Id);

            retVal = (from enumeration in query 
                       select enumeration.EnumerationDetail).ToList();

            return retVal;
        }
        
        /// <summary>
        /// This func is unconcerned with the AccessCode.  It simply
        /// gets all possible enumerations displayed on the list.
        /// </summary>
        /// <param name="widgetId"></param>
        /// <returns></returns>
        internal IList<IListItem> GetListItemsByWidgetId(int widgetId)
        {
            IList<IListItem> listItems = new List<IListItem>();
            IList<IEnumerationDetail> enumerationItems = new List<IEnumerationDetail>();

            foreach (WidgetInventory itm in this._widgets)
            {
                var items = base.FindItems<ListItem>(c => c.WidgetId == itm.Id);
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        if (item.EnumerationDetail != null)
                        {
                            enumerationItems.Add(item.EnumerationDetail);
                        }
                    }
                }
            }

            enumerationItems = enumerationItems.Distinct().OrderBy(c=>c.IntVal).ToList();

            foreach(IEnumerationDetail enumdetailItem in enumerationItems)
            {
                listItems.Add(new ListItem{Id = enumdetailItem.Id, EnumerationDetail = enumdetailItem as EnumerationDetails , WidgetId = widgetId});
            }

            return listItems;
        }

        internal IList<IListItem> GetListItemsByWidgetIdAndAccessCode(int widgetId)
        {
            return _listItems.Where(c => c.WidgetId == widgetId && c.AccessCode == this.AccessCode).ToList();
        }

        internal IList<IListItem> GetListItemsByPageAndWidgetName(int pageId, string widgetName)
        {
            IWidgetInventory widges = _widgets.FirstOrDefault(c => c.PageId == pageId && c.Name == widgetName);
            IList<IListItem> lst = new List<IListItem>();
            if (widges != null)
            {
                lst = GetListItemsByWidgetIdAndAccessCode(widges.Id);
            }

            RefreshCurrentListing(lst);

            return lst;
        }

        internal IList<string> GetListItemsOfWidgetAsText(int pageId, string widgetName)
        {
            IWidgetInventory widges = _widgets.FirstOrDefault(c => c.PageId == pageId && c.Name == widgetName);
            IList<IListItem> lst = new List<IListItem>();
            if (widges != null)
            {
                lst = GetListItemsByWidgetIdAndAccessCode(widges.Id);
            }

            RefreshCurrentListing(lst);

            return this.CurrentListing;
        }

        private void RefreshCurrentListing(IList<IListItem> newList)
        {
            if (newList != null && newList.Count > 0)
            {
                CurrentListing.Clear();
                foreach (IListItem item in newList)
                {
                    CurrentListing.Add(item.EnumerationDetail.DisplayText);
                }
            }
        }

        public void Save()
        {
            base.SaveAndCommit();
        }
    }
}