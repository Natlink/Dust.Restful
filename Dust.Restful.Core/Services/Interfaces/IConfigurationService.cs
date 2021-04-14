using Dust.Utils.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Interfaces
{
    public interface IConfigurationService<T> where T : Configuration, new()
    {

        public T Get();

    }

    public class Configuration : DustConfig
    {
    }

}
