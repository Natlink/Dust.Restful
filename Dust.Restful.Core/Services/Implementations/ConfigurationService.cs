
using Dust.Restful.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Dust.Restful.Core.Services.Implementations
{
    public class ConfigurationService : IConfigurationService
    {
        private static Configuration Values { get; set; }

        public ConfigurationService()
        {
            Console.WriteLine("[V] Configuration service starting.");
            if (Values == null)
            {
                XmlSerializer serial = new XmlSerializer(typeof(Configuration));
                FileStream s;
                if (!File.Exists("config.xml"))
                {
                    Values = new Configuration();
                    s = new FileStream("config.xml", FileMode.Create);
                    serial.Serialize(s, Values);
                    s.Close();
                    return;
                }
                s = new FileStream("config.xml", FileMode.Open);
                Values = (Configuration)serial.Deserialize(s);
                s.Close();
            }
        }

        public Configuration Get()
        {
            return Values;
        }
    }

}
