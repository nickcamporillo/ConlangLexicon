using System;
using Utilties;

namespace IViews
{
    public interface IViewWordListGrid: IView
    {
        event EventHandler InvokeSearch;
        event EventHandler AddingRecord;
        string LanguageId { get; set; }
        string WordCount { get; set; }
        bool SearchFromStart { get; }        
        bool SearchWordContains { get; }
        string SearchText { get; set; }
        SearchMode SearchType { get; set; }
    }
}
