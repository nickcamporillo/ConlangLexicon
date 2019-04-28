using System;

namespace IViews
{
    public interface IViewLexiconEntryScreen: IView
    {
        event EventHandler Insert;
        event EventHandler Delete;

        bool IsAddingNewRecord { get; set; }

        string WordCount { get; set; }

        string LanguageId { get; set; }
        string Entry { get; set; }
        string IPA { get; set; }
        string Meaning { get; set; }
        string SecondaryMeanings { get; set; }
        string Synonyms { get; set; }
        
        string Dialect { get; set; }
        string Register { get; set; }

        string Gender { get; set; }
        string NounIncorporatedForm { get; set; }
        string Pos { get; set; }
        string PosSubtype { get; set; }
        string Domain { get; set; }

        string Etymology { get; set; }
        string GrammaticalNotes { get; set; }
        string AdditionalNotes { get; set; }
        string AlternateForms { get; set; }
        string EntryDate { get; set; }
        string DeactivatedDate { get; set; }

        void RefreshData();
    }
}
