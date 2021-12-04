using Netcorewebapi.Models;
using System.Collections.Generic;

namespace Netcorewebapi.Repository
{
    public interface IEmployeeRepo
    {
        int AddEmployee(Employee emp);
        List<Employee> GetEmployeeList();
    }
}