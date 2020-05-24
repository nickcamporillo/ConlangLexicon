using Lexicon.Legacy2019.Converter.Excel;
using Lexicon.Legacy2019.Converter.SqlServer;
using System;


namespace Lexicon.Legacy2019
{
    class Program
    {
        //Spreadsheets: "Minhast_Layout04_2018.12.21.xls", "Minhast_Misc.xls"
        const string EXCEL_DATAFILE = "Minhast_Misc.xls";
        const string RAWDATA_DIRECTORY = @"C:\MyStuff\Hobbies\HobbyTools\GeneralUtilities\CSharpLexiconUtilities\Converters\Excel\data\";
        const string EXCEL_FILE_PATH_AND_NAME = RAWDATA_DIRECTORY + EXCEL_DATAFILE;
        const string OUTPUT_DIR = @"c:\temp";
        
        //const string CONNX_STRING = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\MyStuff\_Databases\Minhast\Lexicon2019_Transitional.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True;";
        const string CONNX_STRING = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MyStuff\_Databases\Minhast\Lexicon2019_Transitional.mdf;Integrated Security = True; Connect Timeout = 30";
        const string DB_TABLE_NAME_SOURCE = "LexiconRaw";        

        //Excel Tab Names
        //From "Minhast_Layout04_2018.12.21.xls":
        const string NOUNS = "Nouns";
        const string VERBS = "Verbs";
        const string IDIOMS = "Idioms";

        //From: "Minhast_Misc.xls":
        const string PARTICLES = "Particles";        
        const string USEFUL_PHRASES = "UsefulPhrases";

        const string OUTPUT_TYPE = PARTICLES;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter '1' to export the LexiconRaw table data to XML, or '2' to export the Excel file " + EXCEL_DATAFILE + " to a SQL file");
            var key = Console.ReadKey();            
            string fileType = (key.KeyChar == '1' ? "XML" : "SQL");

            if (key.KeyChar != '1' && key.KeyChar != '2')
            {
                Console.WriteLine("\n\nProcessing cancelled.  \n\nPress any key to continue.");
                Console.ReadKey();
                return;
            }

            try
            {
                if (key.KeyChar == '1')
                {
                    var sqlServerExporter = new SqlServerExporter();
                    sqlServerExporter.ExportDbLexiconTableToXmlFile(CONNX_STRING, DB_TABLE_NAME_SOURCE, OUTPUT_DIR, CreateDateTimeStampForFile());
                }
                else
                {
                    var excelExporter = new ExcelExporter();
                    excelExporter.ExportExcelToSqlInsertsFile(OUTPUT_DIR, EXCEL_FILE_PATH_AND_NAME, OUTPUT_TYPE, CreateDateTimeStampForFile());
                }
                Console.WriteLine("\n\nDone!  You may pick your " + fileType + " in the output directory " + OUTPUT_DIR + "\n\nPress any key to exit.");
                Console.ReadKey();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"\n\nException:{ex.Message}");
                Console.ReadKey();
            }
            
            
        }

        static string CreateDateTimeStampForFile()
        {
            string retVal =  DateTime.Now.Year.ToString() + "." + DateTime.Now.Month + "." + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Millisecond.ToString();
            return retVal;
        }
    }
}
