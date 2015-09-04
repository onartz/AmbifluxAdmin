using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbifluxAdmin.Model
{
    public interface IDBItem
    {
        bool CanDeleteSoft();
        bool CanDelete();
    }
}
