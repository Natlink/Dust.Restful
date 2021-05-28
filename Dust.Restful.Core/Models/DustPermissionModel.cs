using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Models
{
    public class DustPermissionModel
    {

        public bool Get { get; set; }
        public bool GetAll { get; set; }
        public bool Add { get; set; }
        public bool AddList { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }

        public DustPermissionModel(bool get, bool getAll, bool add, bool addList, bool edit, bool delete)
        {
            Get = get;
            GetAll = getAll;
            Add = add;
            AddList = addList;
            Edit = edit;
            Delete = delete;
        }
    }
}
