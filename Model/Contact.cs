using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace AmbifluxAdmin.Model
{
    partial class Contact:IDBItem
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

        public Contact(string baseAD, string loginConnexion, string password, string loginUtilisateur)
        {
            DirectoryEntry ldap = new DirectoryEntry(baseAD, loginConnexion, password);
            DirectorySearcher searcher = new DirectorySearcher(ldap);
            searcher.Filter = ("(&(SamAccountName=" + loginUtilisateur + "))");
           
          try
          {
                SearchResult result = searcher.FindOne();
                DirectoryEntry de = new DirectoryEntry(result.Path);
                this._FirstName = de.Properties["givenName"].Value.ToString();
                this._LastName = de.Properties["sn"].Value.ToString();
                this._EmailAddress=de.Properties["mail"].Value.ToString();
          }
          catch(DirectoryServicesCOMException ex)
          {
              throw (ex);
              //Contact = null;
          }

        
        }


    }
}
