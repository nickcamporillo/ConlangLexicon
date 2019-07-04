using System;
using Utilties;

namespace IViews
{
    public interface IViewWordListGrid: IView
    {
        event EventHandler InvokeSearch;
        event EventHandler AddingRecord;
        event EventHandler EditingRecord;
        string WordCount { get; set; }
        int LanguageId { get; set; }
        bool SearchFromStart { get; }        
        bool SearchWordContains { get; }
        string SearchText { get; set; }
        SearchMode SearchType { get; set; }
    }
}
