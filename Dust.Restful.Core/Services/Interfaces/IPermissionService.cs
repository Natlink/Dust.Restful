using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Interfaces
{
    public interface IPermissionService<Permission, Level>
    {

        public Permission GetByLevel(Level level);

    }
}
