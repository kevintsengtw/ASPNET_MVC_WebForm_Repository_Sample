using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain;

namespace Sample.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetOne(int id);

        IEnumerable<Employee> GetEmployees();

    }
}
