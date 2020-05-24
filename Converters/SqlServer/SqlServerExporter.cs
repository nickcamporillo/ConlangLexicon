using System;
using System.Data;
using System.Data.SqlClient;
using WTF.Core.Datamanager;
using WTF.Core.Xml;
using Lexicon.Legacy2019.XmlEntities;

namespace Lexicon.Legacy2019.Converter.SqlServer
{
    public class SqlServerExporter
    {
        public void ExportDbLexiconTableToXmlFile(string connectionString, string dbTableName, string outputDir, string dateTimeStamp)
        {
            IDbConnection cnx = new SqlConnection(connectionString);
            DataManager dm = new DataManager(cnx);
            Serializer serializer = new Serializer();
            LexiconDocument lexicon = new LexiconDocument();

            if (dm.isConnected)
            {
                using (var reader = dm.Read("select * from " + dbTableName + " order by Id"))
                {
                    while (reader.Read())
                    {
                        lexicon.Items
                            .Add(new LexiconRaw
                            {
                                Id = (int)reader["Id"],
                                LanguageId = (int)reader["LanguageId"],
                                Entry = reader["Entry"].ToString(),
                                Meaning = reader["Meaning"].ToString(),
                                SecondaryMeanings = reader["SecondaryMeanings"].ToString(),
                                Pos = reader["Pos"].ToString(),
                                PosSubtype = reader["PosSubtype"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                NounIncorporatedForm = reader["NounIncorporatedForm"].ToString(),
                                AlternateForms = reader["AlternateForms"].ToString(),
                                Dialect = reader["Dialect"].ToString(),
                                Register = reader["Register"].ToString(),
                                Domain = reader["Domain"].ToString(),
                                Synonyms = reader["Synonyms"].ToString(),
                                Etymology = reader["Etymology"].ToString(),
                                IPA = reader["IPA"].ToString(),
                                GrammaticalNotes = reader["GrammaticalNotes"].ToString(),
                                AdditionalNotes = reader["AdditionalNotes"].ToString(),
                                EntryDate = ConvertReaderFieldToDateTime(reader["EntryDate"]),
                                DeactivatedDate = ConvertReaderFieldToDateTime(reader["DeactivatedDate"])
                            }
                            );
                    }

                    reader.Close();
                }
            }

            Serializer.SerializeToXmlFile(lexicon, outputDir + @"\" + dbTableName + "_" + dateTimeStamp + ".xml");
        }

        static DateTime ConvertReaderFieldToDateTime(object field)
        {
            DateTime retVal;
            DateTime.TryParse(field.ToString(), out retVal);
            return retVal;

        }
    }
}
