using System;
using System.Windows.Forms;

namespace IViews
{
    public enum ConfirmNavigation
    {
        MoveToNextScreen = 1,
        StayOnCurrentScreen = 2
    }

    public interface IView: IDisposable
    {
        event EventHandler RecordChanged;
        event EventHandler PageMoveCompleted;
        event FormClosingEventHandler FormClosing;
        event EventHandler UpdateItem;
        event EventHandler NextScreen;
        event EventHandler PreviousScreen;
        event EventHandler CloseAll;

        bool MaximizeBox { get; set;}
        bool MinimizeBox { get; set;}

        string Text { get; set; }
        string Name { get; set; }
        string PreviousFormName { get; set; }
        string NextFormName { get; set; }

        int Id { get; set; }

        ConfirmNavigation ConfirmNavigateToPreviousScreen { get; set; }
        ConfirmNavigation ConfirmNavigateToNextScreen { get; set; }

        object Datasource { get; set; }
        object CurrentItem { get; set; }

        void MoveFirstRecord(object sender, EventArgs e);
        void MoveLastRecord(object sender, EventArgs e);
        void MoveNextRecord(object sender, EventArgs e);
        void MovePreviousRecord(object sender, EventArgs e);
        void Cancel(object sender, EventArgs e);
        void SaveRecord(object sender, EventArgs e);
        void AddRecord(object sender, EventArgs e);

        void RefreshData();
        void Show();
        void Hide();
        void Close();

        void OnMoveCompleted(object sender, EventArgs e);
    }
}
