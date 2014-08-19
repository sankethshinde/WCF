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
        [FaultContract(typeof(ZeroEmployeesFault))]
        [OperationContract]
        List<Employee> GetAllEmployees();

        [FaultContract(typeof(EmployeeIsNotPresentFault))]
        [OperationContract(Name= "SearchByID")]
        Employee GetEmployeeDetails(int id);

        [FaultContract(typeof(EmployeeIsNotPresentFault))]
        [OperationContract(Name="SearchByName")]
        Employee GetEmployeeDetails(string name);
    }

    [ServiceContract]
    public interface ICreateEmp
    {
        [FaultContract(typeof(ArgumentsEmptyFault))]
        [FaultContract(typeof(EmployeeAldreadyPresentFault))]
        [OperationContract]
        int CreateEmployee(string name,int id,string remarkDetails,DateTime remarkDate);

        [OperationContract]
        void ClearList();

        
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
