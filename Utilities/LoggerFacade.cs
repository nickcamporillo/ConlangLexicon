using log4net.Appender;
using log4net.Config;
using log4net;
using log4net.Repository.Hierarchy;
using System.Configuration;
using System;
using System.Diagnostics;

namespace Utilities
{
    public class LoggerFacade
    {
        private const string LOG_DIR = "LOG_DIR";
        private static bool _isInitialized = false;
        private static string logPath = string.Empty;

        //https://stackify.com/log4net-guide-dotnet-logging/
        //Recipe for simplified configuration by using app.config: https://www.codeproject.com/Tips/1107824/Perfect-Log-Net-with-Csharp
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        
        
        //Programatically set the log file's location dynamically to database's containing folder; how-to located here: https://stackoverflow.com/questions/17560396/log4net-how-to-set-logger-file-name-dynamically
        private static void SetLogLocation()
        {
            if (_isInitialized)
            {
                return;
            }

            logPath = $@"{ConfigurationManager.AppSettings[LOG_DIR].ToString()}\LexiconSession_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.log";

            XmlConfigurator.Configure();
            Hierarchy heirarchy = (Hierarchy)LogManager.GetRepository();

            foreach (IAppender appender in heirarchy.Root.Appenders)
            {
                if (appender is FileAppender)
                {
                    FileAppender fa = (FileAppender)appender;
                    fa.File = logPath;
                    fa.ActivateOptions();
                    break;
                }
            }

            _isInitialized = true;
        }

        public static void Info(string message)
        {
            SetLogLocation();
            log.Info(message);
        }
        public static void Warn(string message)
        {
            SetLogLocation();
            log.Warn(message);
        }
        public static void Warn(string message, Exception ex)
        {
            SetLogLocation();
            log.Warn(message,ex);
        }
        public static void Error(string message)
        {
            SetLogLocation();
            log.Error(message);
        }
        public static void Error(string message, Exception ex)
        {
            SetLogLocation();
            log.Error(message, ex);
        }
        public static void Fatal(string message)
        {
            log.Fatal(message);
        }
        public static void Fatal(string message, Exception ex)
        {
            log.Fatal(message, ex);
        }

        #region Log4Net stuff internal class and Events"

        public class ActivityIdHelper
        {
            public override string ToString()
            {
                if (Trace.CorrelationManager.ActivityId == Guid.Empty)
                {
                    Trace.CorrelationManager.ActivityId = Guid.NewGuid();
                }

                return Trace.CorrelationManager.ActivityId.ToString();
            }
        }

        static void Application_Activate(object sender, EventArgs e)
        {
            //set the property to our new object
            log4net.LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();

            log.Debug("Application_Activate");
        }

        static void Application_Deactivate(object sender, EventArgs e)
        {
            //set the property to our new object
            log4net.LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();
            log.Debug("Application_Deactivate");
        }

        static void Application_Error(object sender, EventArgs e)
        {
            //set the property to our new object
            log4net.LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();
            log.Debug("Application_Error");
        }

        #endregion
    }
}
