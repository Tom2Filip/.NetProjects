using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRepair.DAL
{
    public interface IVehicleRepairRepository:IDisposable
    {
        IList<Customer> GetCustomers();
        IQueryable<Customer> GetCustomerByID(int customerID);
        void InsertCustomer(string fName, string lName, string adress, string city, string state, string postCode, string email);
        IQueryable<Vehicle> GetVehicleByRegistration(string registration);
        IEnumerable<Vehicle>GetVehicles();
        IEnumerable<Vehicle> FilterVehicles(string vReg);
        void InsertVehicle(string vReg, string vMake, string vModel, string vType, short vYear, string vColor, string vVin, string vCapacity, string fuelType);
        void DeleteVehicle(string vRegistration);
        void UpdateVehicleByRegistration(string vReg, string vMake, string vModel, string vType, short vYear, string vColor, string vVin, string vCapacity, string vFuelType);
        void UpdateVehicleOwner(string reg, int owner);
        void DeleteService(int serviceID);
        IQueryable<VehicleService> GetServicesByReg(string vReg);
        IQueryable<VehicleService> GetServiceByID(int serviceID);
        void UpdateServiceByID(int id, DateTime serviceDate, int odometer, string subject, string description);
        void AddServiceByReg(string registration, DateTime serviceDate, int odometer, string subject, string description);
    }
}