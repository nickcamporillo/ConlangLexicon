using IModels;
using IRepository;
using IServices;
using Models;
using Repositories;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDriver
{
    class Program
    {
        static DbEntities _dbEntities;

        //If you want to avoid headaches if you're using app.config for the EF connection
        //string, use "metadata=res://*/;" instead of something like this:
        //"metadata=res://*/DbModels.csdl|res://*/DbModels.ssdl|res://*/DbModels.msl"

        static void Main(string[] args)
        {

            //If app.config file is in this assembly and has cnx string in it, it should open automatically            
            _dbEntities = new DbEntities();

            //FYI: Context is inherited by DbEntities; you may be able to exploit Strategy Pattern bc of this
            //DbContext dbContext = _dbEntities as DbContext;

            //----------- Misc. info.  Don't really need, and these are get{} properties anyway ----------
            //DbConnection con = _dbEntities.Database.Connection;
            //DbContextConfiguration dbContextConfiguration = _dbEntities.Configuration;

            //Test the List of the raw entity itself:
            var lexiconEntries = GetLexiconEntries();

            //Test getting an IModel from the Respository
            IModel lexiconEntry = Test_1<LexiconRaw>().Where(c=>c.Id== 1035).FirstOrDefault();


            //Test the Service, the final container
            var dialects = Test_2<Dialect>();
            IModel dialect = (from d in dialects
                              orderby d.Id
                              select d).FirstOrDefault();

            var dia = dialect as Dialect;

            System.Console.WriteLine("Program finished successfully");
            System.Console.ReadKey();                            

        }

        static List<LexiconRaw> GetLexiconEntries()
        {
            List<LexiconRaw> lexiconEntries = (_dbEntities.LexiconRaws != null && _dbEntities.LexiconRaws.Count() > 0 ? _dbEntities.LexiconRaws.ToList() : new List<LexiconRaw>());
            return lexiconEntries.Where(c => c.Entry.ToUpper().Contains("XA")).ToList();
        }

        static IList<T> Test_1<T>() where T: class
        {
            string appConfigNameForConnectionString = "DbEntities";
            IContext ctx = new ContextFactory().CreateObjectContext(appConfigNameForConnectionString);
            
            IRepository<T> test = new EfRepositoryFactory(ctx).CreateRepository<T>();
            return test.FindAll().ToList();
        }

        static IList<T> Test_2<T>() where T:class
        {
            IUnitOfWork unitOfWork = new EfUnitOfWork();
            //BaseService service = new LexiconService(unitOfWork);
            IService<LexiconRaw> service = new LexSer<LexiconRaw>(unitOfWork);

            return service.FindAll<T>().Distinct().ToList();
        }
    }
}
