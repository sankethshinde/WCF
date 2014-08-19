using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeServiceFixtures.ServiceReference1;

namespace EmployeeServiceFixtures
{
    [TestClass]
    public class EmployeeFixtures
    {
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        public void BlankArgumentsShouldThrowArgumentNullException()
        {
            var EmployeeServiceClient = new CreateEmpClient("WSHttpBinding_ICreateEmp");
            string name = string.Empty;
            int id = 1;
            string remark = string.Empty;
            int isSuccess = EmployeeServiceClient.CreateEmployee(name, id, remark, DateTime.Now);
            
         }
        [TestMethod]
        public void SuccessfulAdditionofEmployeeReturnsOne()
        {
            var EmployeeServiceClient = new CreateEmpClient("WSHttpBinding_ICreateEmp");
            string name = "sanket";
            int id = 1;
            string remark = "very good";
            int isSuccess = EmployeeServiceClient.CreateEmployee(name, id, remark, DateTime.Now);
            Assert.AreEqual(isSuccess, 1);
        }
    }
}
