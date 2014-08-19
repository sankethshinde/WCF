using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract(Name= "SearchByID")]
        Employee GetEmployeeDetails(int id);

        [OperationContract(Name="SearchByName")]
        Employee GetEmployeeDetails(string name);
    }

    [ServiceContract]
    public interface ICreateEmp
    {
        [OperationContract]
        int CreateEmployee(string name,int id,string remarkDetails,DateTime remarkDate);
    }


    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string RemarkDetails { get; set; }
        [DataMember]
        public DateTime RemarkDate { get; set; }

    }
   
}
