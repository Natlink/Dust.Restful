using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Startups
{
    public abstract class AbstractStartup
    {
        public IConfiguration Configuration { get; protected set; }

        public AbstractStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void DefaultConfigure()
        { 
        
        }
    }
}
