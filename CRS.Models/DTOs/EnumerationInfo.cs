using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.Models.Interfaces;
using CRS.App_Level;

namespace CRS.Models.DTOs
{
    [Obsolete("Get rid of this")]
    public class EnumerationInfo : IEnumerationDetail
    {
        private const int NO_DATA_VAL = -999;
        public int Id { get; set; }
        public int EnumerationId { get; set; }
        public int IntVal { get; set; }
        public string Text { get; set; }
        public int SortOrder { get; set; }
        public string DisplayText { get; set; }
        
        public bool HasData 
        { 
            get
            { 
               return
                   !(Id == NO_DATA_VAL && EnumerationId == NO_DATA_VAL && IntVal == NO_DATA_VAL && 
                    SortOrder == NO_DATA_VAL && (Text == null || Text.Trim().Length == 0))
                   ; 
            }         
        }

        public EnumerationInfo()
        {
            Id = NO_DATA_VAL;
            EnumerationId = NO_DATA_VAL;
            IntVal = NO_DATA_VAL;
            Text = string.Empty;
            SortOrder = NO_DATA_VAL;
            DisplayText = string.Empty;
        }

        public EnumerationInfo(int id, int enumerationId, int enumerationIntVal, string enumerationName, int sortOrder)
        {
            Id = id;
            EnumerationId = enumerationId;
            IntVal =  enumerationIntVal;
            Text = enumerationName;
            SortOrder = sortOrder;
            DisplayText = string.Empty;
        }

        public EnumerationInfo(int id, int enumerationId, int enumerationIntVal, string enumerationName, int sortOrder, string displayText)
        {
            Id = id;
            EnumerationId = enumerationId;
            IntVal = enumerationIntVal;
            Text = enumerationName;
            SortOrder = sortOrder;
            DisplayText = displayText;
        }


        public string EnumerationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
