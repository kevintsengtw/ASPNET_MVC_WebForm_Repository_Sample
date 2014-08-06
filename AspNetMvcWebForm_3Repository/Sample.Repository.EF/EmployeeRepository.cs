using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sample.Domain;
using Sample.Repository.Interface;

namespace Sample.Repository.EF
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private NorthwindEntities db = new NorthwindEntities();

        /// <summary>
        /// Gets the one.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Sample.Domain.Employee GetOne(int id)
        {
            var employee = this.db.Employees.FirstOrDefault(x => x.EmployeeID == id);

            if (employee != null)
            {
                Mapper.CreateMap<Employee, Sample.Domain.Employee>();
                Domain.Employee instance = Mapper.Map<Sample.Domain.Employee>(employee);
                return instance;
            }
            return null;
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Sample.Domain.Employee> GetEmployees()
        {
            var employees = this.db.Employees.OrderBy(x => x.EmployeeID);

            Mapper.CreateMap<Employee, Sample.Domain.Employee>();
            List<Sample.Domain.Employee> result = Mapper.Map<List<Sample.Domain.Employee>>(employees);

            return result;
        }
    }
}
