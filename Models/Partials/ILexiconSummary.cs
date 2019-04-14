using IModels;
using System;

namespace Models
{
    public interface ILexiconSummary:IModel
    {
        int? LanguageId { get; set; }
        string Entry { get; set; }        
        string Meaning { get; set; }
        string SecondaryMeanings { get; set; }
        string Gender { get; set; }
        string NounIncorporatedForm { get; set; }
        string Pos { get; set; }
        string Dialect { get; set; }
        DateTime? EntryDate { get; set; }
    }
}