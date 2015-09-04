using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbifluxAdmin.Model
{
    partial class WorkOrderRouting : IDBItem
    {
        public bool CanDelete()
        {
            // don't allow delete if there are books by this author
            return false;
        }

        public bool CanDeleteSoft()
        {
            return true;

        }
    }
}
