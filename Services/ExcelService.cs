using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTF.Core.OleDbExcel;
using Models;

namespace LexServices
{
    public class ExcelService
    {
        private const string EXCEL_DATASOURCE = @"C:\GitHub\ConlangLexicon\Data";

        private readonly OleDbExcelUtility util = new OleDbExcelUtility();
        
        public List<LexiconRaw> ExcelData { get; set; }

        public ExcelService()
        {
            ExcelData = new List<LexiconRaw>();

            var cnx = util.GetExcelConnection(EXCEL_DATASOURCE);
            var dataTable = util.GetDataTableFromFirstExcelWorksheet(EXCEL_DATASOURCE);
            var reader = dataTable.CreateDataReader();





            
        }
    }
}
