using Dust.ORM.Core;
using Dust.Utils.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Utils
{

    public class RestConfiguration : DustConfig
    {

    }


    [Serializable]
    [ServiceConfigurationAttribute]
    public abstract class ServiceConfiguration
    {
        public abstract string Name { get; set; }
    }
}
