namespace GetData
{
   [Serializable]
   public class LexiconExcelDefinition
   {
	  [XmlElement("LanguageId")]
      public string LanguageId {get;set;}
      [XmlElement("Entry")]
      public string Entry {get;set;}
      [XmlElement("Meaning")]
      public string Meaning {get;set;}
      [XmlElement("SecondaryMeanings")]
      public string SecondaryMeanings {get;set;}
      [XmlElement("Pos")]
      public string Pos {get;set;}
      [XmlElement("POSSubtype")]
      public string POSSubtype {get;set;}
      [XmlElement("Gender")]
      public string Gender {get;set;}
      [XmlElement("NIForm")]
      public string NIForm {get;set;}
      [XmlElement("AlternateForms")]
      public string AlternateForms {get;set;}
      [XmlElement("Dialect")]
      public string Dialect {get;set;}
      [XmlElement("Register")]
      public string Register {get;set;}
      [XmlElement("Domain")]
      public string Domain {get;set;}
      [XmlElement("Synonyms")]
      public string Synonyms {get;set;}
      [XmlElement("Etymology")]
      public string Etymology {get;set;}
      [XmlElement("IPA")]
      public string IPA {get;set;}
      [XmlElement("GrammaticalNotes")]
      public string GrammaticalNotes {get;set;}
      [XmlElement("AdditionalNotes")]
      public string AdditionalNotes {get;set;}
      [XmlElement("EntryDate")]
      public string EntryDate {get;set;}
      [XmlElement("Deactivated")]
      public string Deactivated {get;set;}
      
      public LexiconExcelDefinition(){}
   }
}