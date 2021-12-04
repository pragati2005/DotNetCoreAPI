using Netcorewebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcorewebapi.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public List<Employee> employeelist;
        public EmployeeRepo()
        {
            employeelist = new List<Employee>();
        }
        public int AddEmployee(Employee emp)
        {
            emp.id = employeelist.Count + 1;
            employeelist.Add(emp);
            return emp.id;
        }

        public List<Employee> GetEmployeeList()
        {
            return employeelist;
        }
    }
}
