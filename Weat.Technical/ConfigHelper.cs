using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weat.Technical
{
    public static class ConfigHelper
    {
        public static string GetValueInSectionAppSettings(string key)
        {
            string value = string.Empty;
            value = ConfigurationManager.AppSettings[key];

            return value;
        }

        public static string GetValueConnectionStrings(string key)
        {
            string value = string.Empty;
            value = ConfigurationManager.ConnectionStrings[key].ConnectionString;

            return value;
        }
    }
}
