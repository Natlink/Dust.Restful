
using Dust.ORM.Core;
using Dust.Restful.Core.Services.Interfaces;
using Dust.Utils.Core.Config;
using Dust.Utils.Core.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Dust.Restful.Core.Services.Implementations
{
    public class DustConfigurationService<T> : IConfigurationService<T> where T : Configuration, new()
    {
        private static T Values { get; set; }

        public DustConfigurationService(ILogger logs, string filename = "RestConfig.xml")
        {
            if (filename == null || filename.Length <= 0 || filename.IndexOfAny(new char[] { '*', '&', '#', '\\', '/', '\n', '\t' }) != -1 )
            {
                throw new Exception("Configuration file's name can't be null, empty or contains theses chars: * & # \\ / newLine tabulation.\nSubmited configuration file name: " + filename);
            }
            if (Values == null)
            {
                Values = ConfigLoader.Load<T>(filename, logs);
                logs.Info("[V] Configuration service started. Config file loaded.");
            }
        }

        public T Get()
        {
            return Values;
        }
    }

}
