using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WTF.Core.FileSystem;
using WTF.Core.OleDbExcel;

namespace Lexicon.Legacy2019.Converter.Excel
{
    public class ExcelExporter
    {
        public void ExportExcelToSqlInsertsFile(string outputDir, string excelSourceFileName, string spreadsheetTabName, string dateTimeStamp)
        {
            FileSystemManager fmgr = new FileSystemManager();
            MappingValidator mapper = new MappingValidator();
            StringBuilder sb = new StringBuilder();

            string sqlOutputFileName = outputDir + "\\Inserts_" + spreadsheetTabName + "_" + dateTimeStamp + ".sql";

            CreateExcelDataToSqlServerInsertStatements(ref mapper, ref sb, excelSourceFileName, spreadsheetTabName);
            bool writeSucceed = fmgr.WriteFile(sqlOutputFileName, sb.ToString());
        }

        /// <summary>
        /// Note: The strinbuilder should be emptied PRIOR to calling the method if you don't want to concatenate from the previous 
        /// stringbuilding process; otherwise if you want them consolidated, don't empty but pass stringuilder in un-emptied
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="sb"></param>
        public void CreateExcelDataToSqlServerInsertStatements(ref MappingValidator mapper, ref StringBuilder sb, string excelFileDataPathAndName, string excelTabName)
        {
            const string UNICODE_ESCAPE_CHAR_SQLSERVER = ",N'";
            DataTable dataTable = mapper.GetDataTableFromSpecifiedExcelWorksheet(excelFileDataPathAndName, excelTabName);
            //The tablename should match the Tab's name
            dataTable.TableName = excelTabName;
            IList<string> insertStatements = mapper.GetListOfInsertSqlStatement(dataTable, excelFileDataPathAndName);
            foreach (string item in insertStatements)
            {
                string escapedItem = item.Replace(",'", UNICODE_ESCAPE_CHAR_SQLSERVER);
                sb.AppendLine(escapedItem);
            }
        }
    }
}
