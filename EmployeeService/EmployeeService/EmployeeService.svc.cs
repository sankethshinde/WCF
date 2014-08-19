using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class EmployeeService : IEmployeeService, ICreateEmp
    {
        public static List<Employee> employeeList = new List<Employee>();

        public List<Employee> GetAllEmployees()
        {
            if (employeeList.Count() == 0)
            {
                ZeroEmployeesFault zeroEmployeesFault = new ZeroEmployeesFault();
                zeroEmployeesFault.Error = "zeroEmployeesFault";
                zeroEmployeesFault.Details = "No employees are present in the database";
                throw new FaultException<ZeroEmployeesFault>(zeroEmployeesFault);
            }
            return employeeList;

        }


        public int CreateEmployee(string name, int id, string remarkDetails, DateTime remarkDate)
        {
            bool exists = employeeList.Exists(element => element.EmployeeId.Equals(id));
            if (name == string.Empty || remarkDetails == string.Empty)
            {
                ArgumentsEmptyFault argumentsEmptyFault = new ArgumentsEmptyFault();
                argumentsEmptyFault.Error = "ArgumentsEmptyFault";
                argumentsEmptyFault.Details = " Arguments for create Employee function cannot be Empty";
                throw new FaultException<ArgumentsEmptyFault>(argumentsEmptyFault);
            }
            else if (exists)
            {
                EmployeeAldreadyPresentFault idAldreadyPresentFault = new EmployeeAldreadyPresentFault();
                idAldreadyPresentFault.Error = "EmployeeAldreadyPresentFault";
                idAldreadyPresentFault.Details = "Employee should be created with unique id";
                throw new FaultException<EmployeeAldreadyPresentFault>(idAldreadyPresentFault);
            }
            else
            {
                Employee obj = new Employee();
                obj.EmployeeName = name;
                obj.EmployeeId = id;
                obj.RemarkDetails = remarkDetails;
                obj.RemarkDate = remarkDate;
                employeeList.Add(obj);
                return 1;
            }
        }


        public Employee GetEmployeeDetails(int id)
        {
            bool exists = employeeList.Exists(element => element.EmployeeId.Equals(id));
            if (!exists)
            {
                EmployeeIsNotPresentFault idIsNotPresent = new EmployeeIsNotPresentFault();
                idIsNotPresent.Error = "EmployeeIsNotPresentFault";
                idIsNotPresent.Details = "Given Employee Id Is not Present In the list";
                throw new FaultException<EmployeeIsNotPresentFault>(idIsNotPresent);
            }
            return employeeList.Find(e => e.EmployeeId.Equals(id));
        }

        public Employee GetEmployeeDetails(string name)
        {
            bool exists = employeeList.Exists(element => element.EmployeeName.Equals(name));
            if (!exists)
            {
                EmployeeIsNotPresentFault nameIsNotPresent = new EmployeeIsNotPresentFault();
                nameIsNotPresent.Error = "EmployeeIsNotPresentFault";
                nameIsNotPresent.Details = "Given Employee Name Is not Present In the list";
                throw new FaultException<EmployeeIsNotPresentFault>(nameIsNotPresent);
            }
            return employeeList.Find(e => e.EmployeeName.Equals(name));
        }


        public void ClearList()
        {
            employeeList.Clear();
        }
    }
}