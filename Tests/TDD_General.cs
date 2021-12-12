using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Models;
using NUnit.Framework;
using Services;
//using Services;
using Utilities;
using WTF.Core.OleDbExcel;
using WTF.Core.Xml;

namespace Tests
{
    [TestFixture]
    public class TDD_General
    {
        [Test(Description = "Fetch all data from table \"LexiconRaw\"")]
        public void Test_Lexicon_ExportToExcel()
        {
            var factory = new LexiconServiceFactory<LexiconRaw>();
            var svcLexiconRaw = factory.CreatService();

            string dateTimeStamp = $"{DateTime.Now.Year.ToString()}.{DateTime.Now.Month.ToString()}.{DateTime.Now.Day.ToString()}_{DateTime.Now.Millisecond.ToString()}";

            Assert.IsNotNull(svcLexiconRaw, "Could not instantiate service - make sure app.config is in project with correct connection string and other EF configurations");

            var resultSet = svcLexiconRaw.FindAll() as List<LexiconRaw>;

            Assert.IsNotNull(resultSet, "Could not get LexiconRaw data");

            Serializer.SerializeToXmlFile(resultSet, $@"c:\temp\LexiconRaw_{dateTimeStamp}.xml");

            var dataSetName = $"LexiconRaw_{dateTimeStamp}";
            var dataSet = new DataSet(dataSetName);

            var xmlReadMode = dataSet.ReadXml($@"c:\temp\LexiconRaw_{dateTimeStamp}.xml");
            Assert.IsNotNull(dataSet.Tables, "Dataset tables is null");

            var tableCount = dataSet.Tables.Count;
            Assert.IsTrue(tableCount > 0, "Could not get tables, count == 0");

            var table = dataSet.Tables[0];
            var excelUtility = new OleDbExcelUtility();
            var isExported = excelUtility.ExportToExcel(table, $@"c:\temp\{dataSetName}.xls"); 
        }

        [Test(Description = "Test_Logger_Facade")]
        public void Test_ImportFromExcelData()
        {
            //C:\MyStuff\Hobbies\HobbyTools\HobbyDbs\ConlangsLexiconDb
            const string datasource = @"C:\GitHub\ConlangLexicon\Data\LexiconRawExcel_Tester.xls";
            const string spreadsheetName = "LexiconRaw";
            var exUtil = new OleDbExcelUtility();
            var dt = exUtil.GetDataTableFromSpecifiedExcelWorksheet($@"{datasource}", spreadsheetName);
            var rows = dt.Rows;

            object itmArray = rows[0].ItemArray;

            List<string> names = new List<string>();
            int rowpnt = 0;
            int arpnt = 0;
            for (int i=0; i< dt.Columns.Count; i++)
            {
                names.Add(dt.Columns[i].Caption);
                var tt = dt.Rows[rowpnt].ItemArray[arpnt].GetType();
                rowpnt++;
                arpnt++;
                var x = dt.Columns.OfType<int>().ToList();
                var dta = dt.Rows[i].Field<int>(x.FirstOrDefault());
            }

            string t = "";

            var values = new List<string>();

        }

        [Test(Description = "Test_Logger_Facade")]
        public void Test_LoggerFacade()
        {
            LoggerFacade.Info("Set");
        }
    }
}
