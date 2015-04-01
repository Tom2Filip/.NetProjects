using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRepair.DAL;
using System.Data.SqlClient;
using System.Data.Entity.Core;

namespace VehicleRepair.DAL
{
    // The class implements the IDisposable interface to ensure that the database connection is released 
    // when the object is disposed.
    public class VehicleRepairRepository : IDisposable, IVehicleRepairRepository
    {
        private VehicleEntities context = new VehicleEntities();

        public IEnumerable<Vehicle> GetVehicles()
        {
            try
            {
               return context.Vehicles.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        public IList<Customer> GetCustomers()
        {
            try
            {
                var qCustomers = (from c in context.Customers
                                  select c);
                return qCustomers.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Customer> GetCustomerByID(int custID)
        {
            try
            {
                return context.Customers.Where(c=>c.customerID == custID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertCustomer(string fName, string lName, string adress, string city, string state, string postCode, string email)
        {
            try
            {
                Customer insertCustomer = new Customer();
                insertCustomer.firstName = fName;
                insertCustomer.lastName = lName; 
                insertCustomer.adress = adress;
                insertCustomer.city = city;
                insertCustomer.state = state;
                insertCustomer.email = email;

                context.Customers.AddObject(insertCustomer);
                context.SaveChanges();
                    
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
                   
        public IQueryable<Vehicle> GetVehicleByRegistration(string vRegistration)
        {
            try
            {
               return context.Vehicles.Where(v => v.registration == vRegistration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        public IEnumerable<Vehicle> FilterVehicles(string vReg)
        {
            try
            {
                return context.Vehicles.Where(v => v.registration.ToUpper().Contains(vReg.ToUpper())).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void UpdateVehicleOwner(string reg, int owner)
        {
            try
            {
              var query = context.Vehicles.Where(v=> v.registration == reg).FirstOrDefault();
              query.customerID = owner;
              context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void InsertVehicle(string vReg, string vMake, string vModel, string vType, short vYear, string vColor, string vVin, string vCapacity, string fuelType)
        {
            try
            {
                Vehicle vehicleToAdd = new Vehicle();
                vehicleToAdd.registration = vReg;
                vehicleToAdd.make = vMake;
                vehicleToAdd.model = vModel;
                vehicleToAdd.type = vType;
                vehicleToAdd.year = vYear;
                vehicleToAdd.color = vColor;
                vehicleToAdd.vin = vVin;
                vehicleToAdd.capacity = vCapacity;
                vehicleToAdd.fuelType = fuelType;

                context.Vehicles.AddObject(vehicleToAdd);
                context.SaveChanges();
            }

            catch (OptimisticConcurrencyException ocex)
            {
                throw ocex;
            }

            catch (UpdateException exu)
            {
                throw exu;
            }

            catch (SqlException exs)
            {
                throw exs;
            }

            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                throw ex;
            }
        }

        
        public void DeleteVehicle(string vReg)
        {
            try
            {
                var vehToDelete = context.Vehicles.Where(v=> v.registration == vReg).FirstOrDefault();
                context.Vehicles.DeleteObject(vehToDelete);
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException ocex)
            {
                throw ocex;
            }
            catch (ArgumentNullException argex)
            {
                throw argex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateVehicleByRegistration(string vReg, string vMake, string vModel, string vType, short vYear, string vColor, string vVin, string vCapacity, string vFuelType)
        {
            try
            {
                var vehicleToUpdate = context.Vehicles.Where(v=> v.registration== vReg).FirstOrDefault();
                    vehicleToUpdate.make = vMake;
                    vehicleToUpdate.model = vModel;
                    vehicleToUpdate.type = vType;
                    vehicleToUpdate.year = vYear;
                    vehicleToUpdate.color = vColor;
                    vehicleToUpdate.vin = vVin;
                    vehicleToUpdate.capacity = vCapacity;
                    vehicleToUpdate.fuelType = vFuelType;
                    //vehicleToUpdate.customerID = custID;
                
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException ocex)
            {
                throw ocex;
            }

            catch (UpdateException uex)
            {
                throw uex;
            }
            catch(Exception ex)
            {
              throw ex;
            }
        }

       public void DeleteService(int serviceID)
       {
           try
           {
               var serviceToDelete = context.VehicleServices.Where(vs => vs.id == serviceID).FirstOrDefault();
               context.DeleteObject(serviceToDelete);
               context.SaveChanges();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public IQueryable<VehicleService> GetServicesByReg(string vReg)
       {
            try 
	        {
                return context.VehicleServices.Where(v => v.registration == vReg);	
	        }
         
           catch (Exception ex)
            {
                throw ex;
            }
       }

       public IQueryable<VehicleService> GetServiceByID(int serviceID)
        {
            try
            {
                return context.VehicleServices.Where(vs=> vs.id == serviceID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }


       public void UpdateServiceByID(int id, DateTime serviceDate, int odometer , string subject, string description)
       {
           try
           {
               var serviceToUpdate = context.VehicleServices.Where(vs => vs.id == id).FirstOrDefault();
               serviceToUpdate.serviceDate = serviceDate;
               serviceToUpdate.odometer = odometer;
               serviceToUpdate.subject = subject;
               serviceToUpdate.description = description;

               context.SaveChanges();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public void AddServiceByReg(string registration ,DateTime serviceDate, int odometer, string subject, string description)
        {
            try
            {
                VehicleService serviceToAdd = new VehicleService();
                serviceToAdd.registration = registration;
                serviceToAdd.serviceDate = serviceDate;
                serviceToAdd.odometer = odometer;
                serviceToAdd.subject = subject;
                serviceToAdd.description = description;

                context.VehicleServices.AddObject(serviceToAdd);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }


    }
}