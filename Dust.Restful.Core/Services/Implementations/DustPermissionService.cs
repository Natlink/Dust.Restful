using Dust.Restful.Core.Models;
using Dust.Restful.Core.Services.Interfaces;
using Dust.Utils.Core.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Implementations
{
    public class DustPermissionService : IPermissionService<DustPermissionModel, int>
    {
        private ILogger Logs;
        private Configuration Config;

        private Dictionary<int, DustPermissionModel> Perms;

        public DustPermissionService(IConfigurationService<Configuration> config, ILogger logs)
        {
            Config = config.Get();
            Logs = logs;
            Perms = new Dictionary<int, DustPermissionModel>() { 
                { 0, new DustPermissionModel(false, false, false, false, false, false) }, 
                { 1, new DustPermissionModel(true, true, true, true, true, true) }, 
            };
            Logs.Info("[V] Permission service started.");
        }


        public DustPermissionModel GetByLevel(int level)
        {
            if(level >= 0 && level <= 1) return Perms[level];
            return Perms[0];
        }
    }
}
