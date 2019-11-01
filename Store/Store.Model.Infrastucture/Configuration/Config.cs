using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Infrastucture.Configuration
{
    public static class Config
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["DataBaseName"].ConnectionString;

        public static string ValueSettings(string Key) =>
             ConfigurationManager.AppSettings[Key];
    }
}
