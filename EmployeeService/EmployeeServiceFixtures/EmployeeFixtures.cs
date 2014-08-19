using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeServiceFixtures.ServiceReference1;
using System.ServiceModel;

namespace EmployeeServiceFixtures
{
    [TestClass]
    public class EmployeeFixtures
    {
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<ArgumentsEmptyFault>))]
        public void BlankArgumentsShouldThrowArgumentsEmptyException()
        {
            var employeeServiceClient = new CreateEmpClient("WSHttpBinding_ICreateEmp");
            employeeServiceClient.ClearList();
            string error = string.Empty;
            string name = string.Empty;
            int id = 1;
            string remark = string.Empty;
            employeeServiceClient.CreateEmployee(name, id, remark, DateTime.Now);
        }
        
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<EmployeeAldreadyPresentFault>))]
        public void EmployeeWithSameIdShouldNotBeAdded()
        {
            var employeeServiceClient = new CreateEmpClient("WSHttpBinding_ICreateEmp");
            string name = "sanket";
            int id = 1;
            string remark = "very good";
            string errorCode=string.Empty;
            employeeServiceClient.CreateEmployee(name, id, remark, DateTime.Now);
            employeeServiceClient.CreateEmployee(name, id, remark, DateTime.Now);
        }
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<ZeroEmployeesFault>))]
        public void ListWithZeroEmployeesShouldReturnProperMessage()
        {
            var employeeServiceClient = new EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            var clearList = new CreateEmpClient("WSHttpBinding_ICreateEmp");
            clearList.ClearList();
            employeeServiceClient.GetAllEmployees();
        }
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<EmployeeIsNotPresentFault>))]
        public void ProperMessageShouldbeReturnedIfEmployeeWithGivenIdIsNotPresent()
        {
            var employeeServiceClient = new EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            var createClient = new CreateEmpClient("WSHttpBinding_ICreateEmp");
            createClient.ClearList();
            string name = "swapnil";
            int id = 3;
            string remark = "funny guy";
            createClient.CreateEmployee(name, id, remark, DateTime.Now);
            int randomId=98;
            employeeServiceClient.SearchByID(randomId);
        }
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<EmployeeIsNotPresentFault>))]
        public void ProperMessageShouldBeReturnedIfEmployeeWithGivenNameIsNotPresent()
        {
            var employeeServiceClient = new EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            var createClient = new CreateEmpClient("WSHttpBinding_ICreateEmp");
            createClient.ClearList();
            string name = "kunal";
            int id = 5;
            string remark = "comedy guy";
            createClient.CreateEmployee(name, id, remark, DateTime.Now);
            string empName = "zzz";
            employeeServiceClient.SearchByName(empName);
        }

    }
}
