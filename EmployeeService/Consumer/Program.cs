using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer.ServiceReference1;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
                do
                {
                    Console.WriteLine("1.Create Employee \n");
                    Console.WriteLine("2.Display All Employees list \n");
                    Console.WriteLine("3.Display Employees by id \n");
                    Console.WriteLine("4.Display Employees by name \n");
                    Console.WriteLine("5.Clear List of Employees");
                    Console.WriteLine("6.Exit");
                    Console.WriteLine("Enter ur choice: ");
                    choice = int.Parse(Console.ReadLine());
                    var client = new CreateEmpClient("WSHttpBinding_ICreateEmp");
                    var client1 = new EmployeeServiceClient("BasicHttpBinding_IEmployeeService");

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter name of employee: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Id: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Remark of Employee: ");
                            string remarkDetails = Console.ReadLine();
                            DateTime remarkDate = DateTime.Now;
                            int check = client.CreateEmployee(name, id, remarkDetails, remarkDate);
                            if (check == 1)
                            {
                                Console.WriteLine("Employee is successfully added to the system ");
                            }
                            break;

                        case 2:
                            var emp = client1.GetAllEmployees();
                            for (int i = 0; i < emp.Length; i++)
                            {
                                Console.WriteLine(emp[i].EmployeeName);
                                Console.WriteLine(emp[i].EmployeeId);
                                Console.WriteLine(emp[i].RemarkDetails);
                                Console.WriteLine(emp[i].RemarkDate);
                            }
                            break;
                        
                        case 3:
                            Console.WriteLine("\n Enter Id of Employee you want search: ");
                            id = int.Parse(Console.ReadLine());
                            var employee = client1.SearchByID(id);
                            Console.WriteLine(employee.EmployeeName);
                            Console.WriteLine(employee.RemarkDetails);
                            Console.WriteLine(employee.RemarkDate);
                            break;

                        case 4:
                            Console.WriteLine("\n Enter Id of Employee you want search: ");
                            id = int.Parse(Console.ReadLine());
                            var employee2 = client1.SearchByID(id);
                            Console.WriteLine(employee2.EmployeeName);
                            Console.WriteLine(employee2.RemarkDetails);
                            Console.WriteLine(employee2.RemarkDate);
                            break;

                        case 5:
                            client.ClearList();
                            break;
                }
                } while (choice != 6);
           }
        }
    }


