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
            return employeeList;

        }


        public int CreateEmployee(string name, int id, string remarkDetails, DateTime remarkDate)
        {
            
            if (name == string.Empty || remarkDetails == string.Empty)
            {
         
                    throw new FaultException("Arguments are null");
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
            return employeeList.Find(e => e.EmployeeId.Equals(id));
        }

        public Employee GetEmployeeDetails(string name)
        {
            return employeeList.Find(e => e.EmployeeName.Equals(name));
        }
    }
}