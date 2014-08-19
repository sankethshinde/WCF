using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.EmployeeService;

namespace EmployeeManagementService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new Service1Client())
            {
                var airlines = client.GetAllAirlines();
            }
        }
    }
}
