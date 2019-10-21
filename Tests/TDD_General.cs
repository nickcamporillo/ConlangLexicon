using System;
using System.Collections.Generic;
using System.Data;
using Models;
using NUnit.Framework;
using Services;
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

            Assert.IsNotNull(svcLexiconRaw, "Could not instantiate service - make sure app.config is in project with correct connection string and other EF configurations");

            var resultSet = svcLexiconRaw.FindAll() as List<LexiconRaw>;

            Assert.IsNotNull(resultSet, "Could not get LexiconRaw data");

            Serializer.SerializeToXmlFile(resultSet, @"c:\temp\LexiconRaw.xml");

            var dataSetName = $"LexiconRaw_{DateTime.Now.Year.ToString()}.{DateTime.Now.Month.ToString()}.{DateTime.Now.Day.ToString()}_{DateTime.Now.Millisecond.ToString()}";
            var dataSet = new DataSet(dataSetName);

            var xmlReadMode = dataSet.ReadXml(@"c:\temp\LexiconRaw.xml");
            Assert.IsNotNull(dataSet.Tables, "Dataset tables is null");

            var tableCount = dataSet.Tables.Count;
            Assert.IsTrue(tableCount > 0, "Could not get tables, count == 0");

            var table = dataSet.Tables[0];
            var excelUtility = new OleDbExcelUtility();
            var isExported = excelUtility.ExportToExcel(table, $@"c:\temp\{dataSetName}.xls");
        }

        [Test(Description = "Test_Logger_Facade")]
        public void Test_LoggerFacade()
        {
            LoggerFacade.Info("Set");
        }
    }
}
