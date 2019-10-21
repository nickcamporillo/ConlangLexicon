using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using IModels;
using Models;
using WTF.Core.OleDbExcel;
using WTF.Core.Xml;

namespace Presenters.FileWriters
{
    public class ExportToExcel: IFileWriter
    {
        private const string CONFIG_OUTPUT_DIR = "OUTPUT_DIR";

        public bool WriteFile<T>(List<T> resultSet) where T:IModel
        {
            string outputDir = ConfigurationManager.AppSettings[CONFIG_OUTPUT_DIR].ToString();
            string outputXml = $@"{outputDir}\LexiconRaw.xml";

            Serializer.SerializeToXmlFile(resultSet, outputXml);

            var dataSetName = $"LexiconRaw_{DateTime.Now.Year.ToString()}.{DateTime.Now.Month.ToString()}.{DateTime.Now.Day.ToString()}_{DateTime.Now.Millisecond.ToString()}";
            var dataSet = new DataSet(dataSetName);

            var xmlReadMode = dataSet.ReadXml(outputXml);

            var tableCount = dataSet.Tables.Count;
            var table = dataSet.Tables[0];
            var excelUtility = new OleDbExcelUtility();
            return excelUtility.ExportToExcel(table, $@"{outputDir}\{dataSetName}.xls");
        }
    }
}
