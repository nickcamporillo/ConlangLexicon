using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;


namespace Lexicon.Legacy2019.Repositories
{
    public class ContextFactory:IContextFactory
    {
        public ContextFactory()            
        {
            
        }

        public IContext CreateObjectContext()
        {
            IContext context = new EfContext(GetConnectionString());
            context.ContextOptions.LazyLoadingEnabled = true;
            return context;       
        }

        public IContext CreateObjectContext(string configurationName)
        {
            IContext context = new EfContext(GetConnectionString(configurationName));
            context.ContextOptions.LazyLoadingEnabled = true;
            return context;
        }

        private string GetConnectionString()
        {
            ConnectionStringSettingsCollection cnxStrings = ConfigurationManager.ConnectionStrings;
            string cnxString = string.Empty;
            foreach (var c in cnxStrings)
            {
                if (c.ToString().ToLower().Contains("metadata=res"))
                {
                    cnxString = c.ToString();
                }
            }

            return cnxString;
        }

        private string GetConnectionString(string configurationName)
        {
            ConnectionStringSettingsCollection cnxStrings = ConfigurationManager.ConnectionStrings;
            string cnxString = string.Empty;
            foreach (var c in cnxStrings)
            {
                if (c.ToString().ToLower().Contains("metadata=res"))
                {
                    cnxString = c.ToString();
                }
            }

            cnxString = cnxStrings[configurationName].ConnectionString;

            return cnxString;
        }
    }
}
