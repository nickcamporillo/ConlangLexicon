using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;


namespace CRS.Repository
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

        public IContext CreateObjectContext(string userId)
        {
            IContext context = new EfContext(GetConnectionString());
            context.UserId = userId;
            context.ContextOptions.LazyLoadingEnabled = true;
            return context;
        }

        //This gets its data from the app.config in the project "CRS.Views", assuming that's the executing assembly
        private string GetConnectionString()
        {
            const string SECTION_NAME = "HostName_Connections";
            string hostName = System.Net.Dns.GetHostName().Trim();
            string connectionString = string.Empty;
            NameValueCollection collection = ConfigurationManager.GetSection(SECTION_NAME) as NameValueCollection;

            if (collection != null)
            {
                IList<string> vals = collection.GetValues(hostName).ToList();
                connectionString = (vals != null && vals.Count > 0 ? vals[0] : "");
                return "name=" + connectionString;
            }
            else throw new Exception("Could not connect to database - invalid configuration");
        }
    }
}
