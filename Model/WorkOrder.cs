using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbifluxAdmin.Model
{
    partial class WorkOrder:IDBItem
    {
       
        public bool CanDelete()
        {
            
            // don't allow delete if there are books by this author
            
            return false;
        }

        public bool CanDeleteSoft()
        {
            if(WorkOrderRouting.Count()!=0)
            return true;
            else
                return false;

        }

     
    }
}
