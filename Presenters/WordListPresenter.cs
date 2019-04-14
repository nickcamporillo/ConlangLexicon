using System;
using System.Windows.Forms;
using IViews;
using IPresenters;
using Models;
using IServices;
using Utilties;
using Services;

namespace Presenters
{
    public class WordListPresenter<T, TService> : IPresenter
        where T : class, new()
        where TService : IService<T>
    {
        public event EventHandler SearchInvoke;

        private ILexiconService<T>  _svc;
        private IViewWordListGrid _view;

        public bool SetupComplete
        {
            get;
            private set;
        }

        public WordListPresenter()
        {
        }

        public WordListPresenter(IService<T> service)
        {
            SetupComplete = false;
            _svc = service as ILexiconService<T>;            
        }

        //Note: SetUp() should be called only once per instantiation, within the Load event of the View class.
        public void Setup(IView view)
        {
            _view = view as IViewWordListGrid;            

            //_view.Datasource = _view.Datasource = ((LexiconService<LexiconRaw>)(_svc)).GetSortedItems();
            _view.Datasource = _svc.GetSortedItems();
            var item = _svc.GetFirstItem() as ILexiconSummary;
            _view.Id = item.Id;
            _view.LanguageId = (int) item.LanguageId;

            WireupEvents();

            SetupComplete = true;
        }

        //Note: If you want Presenter methods to fire before the View methods, assign the Presenter methods first, then attach to the View methods.
        private void WireupEvents()
        {
            SearchInvoke += WordListPresenter_SearchInvoke;
            _view.InvokeSearch += SearchInvoke;
            _view.RecordChanged += _view_DataItemChanged;
            _view.AddingRecord += _view_AddingRecord;

            //_view.MovedNextRecord += MovedNextRecord;                     
        }

        private void _view_AddingRecord(object sender, EventArgs e)
        {
            string s = "3";
        }

        private void _view_DataItemChanged(object sender, EventArgs e)
        {
            //Data-bound currentItem refreshes first, so after the refresh, resync with the view's Id property
            var x = _view.CurrentItem as LexiconRaw;            
            _view.Id = (x != null ? x.Id : 0);
        }

        private void WordListPresenter_SearchInvoke(object sender, EventArgs e)
        {            
            RefreshWordListDataBinding();
        }

        private void RefreshWordListDataBinding()
        {
            SearchMode searchMode = _view.SearchType;
            SearchStartPoint startPoint = _view.SearchFromStart ? SearchStartPoint.BeginningOfWord : SearchStartPoint.MiddleOfWord; ;

            string searchString = _view.SearchText;

            if (searchMode == SearchMode.ByEntry)
            {
                _view.Datasource = ((LexiconService<LexiconRaw>)(_svc)).SearchByEntry(searchString, startPoint);
            }
            else if(searchMode == SearchMode.ByMeaning)
            {
                _view.Datasource = ((LexiconService<LexiconRaw>)(_svc)).SearchByMeaning(searchString, startPoint);
            }

            searchMode = SearchMode.None;
        }

        private void MovedNextRecord(object sender, DataGridViewCellEventArgs e)
        {
            //Put any refreshing/resynching stuff here in this stubb         
        }
    }
}