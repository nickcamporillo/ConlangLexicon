using System.Collections.Generic;
using IModels;
using WTF.Core.FileSystem;
using ns = Newtonsoft;

namespace Utilities
{
    public class GeneralUtils
    {
        public static string SerializeToJson<T>(List<T> args) where T: IModel
        {
            string rslt = string.Empty;
            rslt = ns.Json.JsonConvert.SerializeObject(args);
            return rslt;
        }
    }
}
