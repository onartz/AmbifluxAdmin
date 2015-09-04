using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbifluxAdmin.Model
{
    public static class DB
    {
        public static IDBItem AddNewItem(DataClassesDataContext dataContext, ItemType type)
        {
            IDBItem dataItem = null;
           
            if (type == ItemType.Equipment)
            {
                dataItem = new Equipment();
                
                dataContext.Resource.InsertOnSubmit(dataItem as Equipment);
            }

            if (type == ItemType.Employee)
            {
                dataItem = new Employee();
                dataContext.Resource.InsertOnSubmit(dataItem as Employee);
            }

            if (type == ItemType.Location)
            {
                dataItem = new Location();
                dataContext.Location.InsertOnSubmit(dataItem as Location);
            }

            if (type == ItemType.Container)
            {
                dataItem = new Container();
                dataContext.Container.InsertOnSubmit(dataItem as Container);
            }

            if (type == ItemType.Product)
            {
                dataItem = new Product();
                dataContext.Product.InsertOnSubmit(dataItem as Product);
            }

            if (type == ItemType.ProductCategory)
            {
                dataItem = new ProductCategory();
                dataContext.ProductCategory.InsertOnSubmit(dataItem as ProductCategory);
            }

            if (type == ItemType.DemandeExpress)
            {
                dataItem = new DemandeExpress();
                dataContext.OrderHeader.InsertOnSubmit(dataItem as DemandeExpress);
            }

            if (type == ItemType.Echange)
            {
                dataItem = new Echange();
                dataContext.OrderHeader.InsertOnSubmit(dataItem as Echange);
            }
            if (type == ItemType.WorkOrder)
            {
                dataItem = new WorkOrder();
                dataContext.WorkOrder.InsertOnSubmit(dataItem as WorkOrder);
            }
            if (type == ItemType.WorkOrderRouting)
            {
                dataItem = new WorkOrderRouting();
                dataContext.WorkOrderRouting.InsertOnSubmit(dataItem as WorkOrderRouting);
            }
            if (type == ItemType.Workstation)
            {
                dataItem = new Workstation();
                //dataContext.WorkOrder.InsertOnSubmit(dataItem as WorkOrder);
                dataContext.Resource.InsertOnSubmit(dataItem as Workstation);
            }
            if (type == ItemType.Customer)
            {
                dataItem = new Customer();
                //dataContext.WorkOrder.InsertOnSubmit(dataItem as WorkOrder);
                dataContext.Customer.InsertOnSubmit(dataItem as Customer);
            }
            if (type == ItemType.Contact)
            {
                dataItem = new Contact();
                dataContext.Contact.InsertOnSubmit(dataItem as Contact);
            }


            return dataItem;
        }

        

        public static void DeleteItem(IDBItem itemToDelete)
        {
            DataClassesDataContext db = new DataClassesDataContext();
            DeleteItem(db, itemToDelete);
            
            db.SubmitChanges();
        }

        /// <summary>
        /// Suppression de la base de données
        /// </summary>
        /// <param name="db"></param>
        /// <param name="itemToDelete"></param>
        public static void DeleteItem(DataClassesDataContext db, IDBItem itemToDelete)
        {
            if (!itemToDelete.CanDelete()) {
                return;
            }
            IDBItem dataItem = GetExistingItem(itemToDelete);

            if (dataItem is Equipment) db.Resource.DeleteOnSubmit(dataItem as Equipment);
            if (dataItem is Employee) db.Resource.DeleteOnSubmit(dataItem as Employee);
            if (dataItem is Location) db.Location.DeleteOnSubmit(dataItem as Location); 
            if (dataItem is Container) db.Container.DeleteOnSubmit(dataItem as Container);
            if (dataItem is Product) db.Product.DeleteOnSubmit(dataItem as Product);
            if (dataItem is ProductCategory) db.ProductCategory.DeleteOnSubmit(dataItem as ProductCategory);
            if (dataItem is DemandeExpress) db.OrderHeader.DeleteOnSubmit(dataItem as DemandeExpress);
            if (dataItem is Echange) db.OrderHeader.DeleteOnSubmit(dataItem as Echange);
        }

        public static void DeleteSoftItem(IDBItem itemToDelete)
        {
            DataClassesDataContext db = new DataClassesDataContext();
            DeleteSoftItem(db, itemToDelete);

            db.SubmitChanges();
        }

        /// <summary>
        /// Modification du status à "Deleted"
        /// </summary>
        /// <param name="db"></param>
        /// <param name="itemToDelete"></param>
        public static void DeleteSoftItem(DataClassesDataContext db, IDBItem itemToDelete)
        {
            IDBItem dataItem = GetExistingItem(itemToDelete);
            if (dataItem is Location)
            {
                Location l = db.Location.Single(location => location == itemToDelete as Location);
                l.LocationStatusID = (db.LocationStatus.Single(locationStatus => locationStatus.Value == "Deleted")).LocationStatusID;
            }
            if (dataItem is Product)
            {
                Product l = db.Product.Single(Product => Product == itemToDelete as Product);
                l.ProductStatusID = (db.ProductStatus.Single(ProductStatus => ProductStatus.Value == "Deleted")).ProductStatusID;
            }
          
        }

        //public static Individual GetIndividualByName(Individual pIndividual)
        //{
        //    return GetIndividualByName(new DataClassesDataContext(), pIndividual);
        //}

        //public static Individual GetIndividualByName(DataClassesDataContext database, Individual pIndividual)
        //{
            
        //    //var employees = from e in new DataClassesDataContext().Ressource
        //    //                where e is Employee & e.ResourceStatus.Value != "Deleted"
        //    //           select e as Employee;
        //    var individuals = from i in database.Customer 
        //                      where i is Individual & (i as Individual).UserName==pIndividual.UserName
        //                      select i as Individual;
        //    if (individuals.Count == 1) return individuals.;



        //}

        public static IDBItem GetExistingItem(IDBItem dataItem)
        {
            return GetExistingItem(new DataClassesDataContext(), dataItem);

           
        }
        
   

        public static IDBItem GetExistingItem(DataClassesDataContext database, IDBItem dataItem)
        {
            if( dataItem is Equipment ) return database.Resource.Single( Equipment => Equipment == dataItem as Equipment) as IDBItem;
            if (dataItem is Employee) return database.Resource.Single(Employee => Employee == dataItem as Employee) as IDBItem;
            if( dataItem is Location ) return database.Location.Single( Location => Location == dataItem as Location ) as IDBItem;
            if (dataItem is Container) return database.Container.Single(Container => Container == dataItem as Container) as IDBItem;
            if (dataItem is Product) return database.Product.Single(Product => Product == dataItem as Product) as IDBItem;
            if (dataItem is ProductCategory) return database.ProductCategory.Single(ProductCategory => ProductCategory == dataItem as ProductCategory) as IDBItem;
            //if (dataItem is Individual) return database.Customer.Single(customer => customer == dataItem as Customer) as IDBItem;
            if (dataItem is DemandeExpress) return database.OrderHeader.Single(demandeExpress => demandeExpress == dataItem as DemandeExpress) as IDBItem;
            if (dataItem is Echange) return database.OrderHeader.Single(echange => echange == dataItem as Echange) as IDBItem;
            if (dataItem is Customer) return database.Customer.Single(customer => customer == dataItem as Customer) as IDBItem;

            throw new Exception( "Unknown data type" );
        }



        /// <summary>
        /// Recherche d un Customer par son userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Customer GetCustomerByName(string userName)
        {
         return GetCustomerByName(new DataClassesDataContext(),userName);
        }
        /// <summary>
        /// Recherche d un Customer par son userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Customer GetCustomerByName(DataClassesDataContext database, string userName)
        {
            var customer = (from c in database.Customer
                           where c is Customer & c.UserName ==userName
                           select c).SingleOrDefault();
            return customer;
        }

        /// <summary>
        /// Recherche d un Workstation par son machineName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Workstation GetWorkstationByName(DataClassesDataContext database ,string machineName)
        {
            var workstation = (from w in database.Resource
                               where w is Workstation & w.Name == machineName
                               select w as Workstation).SingleOrDefault();
            return workstation;
        }
    }
}
