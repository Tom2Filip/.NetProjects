using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleRepair.DAL;
using System.Data.SqlClient;
using System.Data.Entity.Core;

namespace VehicleRepair.BLL
{
    public class VehicleRepairBL:IDisposable
    {
        private IVehicleRepairRepository VehicleRepository;

        public VehicleRepairBL()
        {
        this.VehicleRepository =new VehicleRepairRepository();
        }

        public VehicleRepairBL(IVehicleRepairRepository VehicleRepository)
        {
            this.VehicleRepository = VehicleRepository;
        }

        public IList<Customer> GetCustomers()
        {
            try
            {
                return VehicleRepository.GetCustomers();
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
                return VehicleRepository.GetCustomerByID(custID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public IEnumerable<Vehicle>GetVehicles()
        {
            try
            {
                return VehicleRepository.GetVehicles();
            }
            catch(SqlException exsql) 
            {
                throw exsql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                       
        }

        public IQueryable<Vehicle> GetVehicleByRegistration(string vehRegistration)
        {
            try
            {
                return VehicleRepository.GetVehicleByRegistration(vehRegistration);
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
                return VehicleRepository.FilterVehicles(vReg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateVehicleByRegistration(string vrega, string vMake, string vModel, string vType, short vYear2, string vColor, string vVin, string vCapacity, string vFuelType)
        {
            try
            {
                VehicleRepository.UpdateVehicleByRegistration(vrega, vMake, vModel, vType, vYear2, vColor, vVin, vCapacity, vFuelType);
            }
            catch (OptimisticConcurrencyException ocex)
            {
                throw ocex;
            }

            catch (UpdateException uex)
            {
                throw uex;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void UpdateVehicleOwner(string reg, int owner)
        {
            try
            {
                VehicleRepository.UpdateVehicleOwner(reg, owner);
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
              VehicleRepository.InsertVehicle(vReg, vMake, vModel, vType, vYear, vColor, vVin, vCapacity, fuelType);
            }

            catch (UpdateException updateEx)
            {
                throw updateEx;
            }

            catch(SqlException sqlEx)
            {
                throw sqlEx;
            }

            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                
                throw ex;
            }
            
        }

        // this method calls objectDataSource on DeleteVehicle
        public void DeleteVehicle(string vRegistration)
        {                   
            // there is no code to delete vehicle because it is already deleted trough GridView -> protected void VehiclesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
            //VehicleRepository.DeleteVehicle(vRegistration);                        
        }

        public void DeleteVehicle2(string vRegistration)
        {
            try
            {
                 VehicleRepository.DeleteVehicle(vRegistration);
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

        public IQueryable<VehicleService> GetServicesByReg(string vreg)
        {
            try
            {
                return VehicleRepository.GetServicesByReg(vreg);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public IQueryable<VehicleService> GetServiceByID(int id)
        {
             try 
	            {	        
		            return VehicleRepository.GetServiceByID(id);
	            }
	            catch (Exception ex)
	            {		
		            throw ex;
	            }
        }

        public void UpdateServiceByID(int id, DateTime serviceDate, int odometer, string subject, string description)
        {
            try
            {
                VehicleRepository.UpdateServiceByID(id, serviceDate, odometer, subject, description);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        public void AddServiceByReg(string registration, DateTime serviceDate, int odometer, string subject, string description)
        {
            try
            {
                VehicleRepository.AddServiceByReg(registration, serviceDate, odometer, subject, description);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        public void DeleteService(int vServiceID)
        {
            try
            {
                VehicleRepository.DeleteService(vServiceID);
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
        
      
       private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                   VehicleRepository.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}