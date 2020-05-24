using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lexicon.Legacy2019.XmlEntities
{
    [Serializable]
    public class LexiconRaw
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("LanguageId")]
        public int LanguageId { get; set; }
        [XmlElement("Entry")]
        public string Entry { get; set; }
        [XmlElement("Meaning")]
        public string Meaning { get; set; }
        [XmlElement("SecondaryMeanings")]
        public string SecondaryMeanings { get; set; }
        [XmlElement("Pos")]
        public string Pos { get; set; }
        [XmlElement("PosCode")]
        public int PosCode { get; set; }
        [XmlElement("PosSubtype")]
        public string PosSubtype { get; set; }
        [XmlElement("PosSubtypeCode")]
        public int PosSubtypeCode { get; set; }
        [XmlElement("Gender")]
        public string Gender { get; set; }
        [XmlElement("GenderCode")]
        public int GenderCode { get; set; }
        [XmlElement("NounIncorporatedForm")]
        public string NounIncorporatedForm { get; set; }
        [XmlElement("AlternateForms")]
        public string AlternateForms { get; set; }
        [XmlElement("Dialect")]
        public string Dialect { get; set; }
        [XmlElement("DialectCode")]
        public int DialectCode { get; set; }
        [XmlElement("Register")]
        public string Register { get; set; }
        [XmlElement("RegisterCode")]
        public int RegisterCode { get; set; }
        [XmlElement("Domain")]
        public string Domain { get; set; }
        [XmlElement("DomainCode")]
        public int DomainCode { get; set; }
        [XmlElement("Synonyms")]
        public string Synonyms { get; set; }
        [XmlElement("Etymology")]
        public string Etymology { get; set; }
        [XmlElement("IPA")]
        public string IPA { get; set; }
        [XmlElement("GrammaticalNotes")]
        public string GrammaticalNotes { get; set; }
        [XmlElement("AdditionalNotes")]
        public string AdditionalNotes { get; set; }
        [XmlElement("EntryDate")]
        public DateTime? EntryDate { get; set; }
        [XmlElement("DeactivatedDate")]
        public DateTime? DeactivatedDate { get; set; }

        public LexiconRaw()
        { 
        }
    }

    [Serializable]
    public class LexiconDocument
    {
        [XmlArray("Items")]
        public List<LexiconRaw> Items { get; set; }

        public LexiconDocument() 
        {
            Items = new List<LexiconRaw>();
        }
    }
}
