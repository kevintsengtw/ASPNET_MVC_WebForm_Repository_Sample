using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Sample.Domain;
using Sample.Repository.Interface;

namespace Sample.Repository.EntLibDAAB
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        /// <summary>
        /// Gets the one.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Employee GetOne(int id)
        {
            string sqlStatement = "select * from Employees where EmployeeID = @EmployeeID";

            DataAccessor<Employee> accessor =
                this.Db.CreateSqlStringAccessor<Employee>(
                    sqlStatement,
                    new EmployeeIDParameterMapper(),
                    new EmployeeMapper());

            return accessor.Execute(new object[] { id }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Employee> GetEmployees()
        {
            string sqlStatement = "select * from Employees order by EmployeeID";

            DataAccessor<Employee> accessor =
                this.Db.CreateSqlStringAccessor<Employee>(sqlStatement, new EmployeeMapper());

            return accessor.Execute();
        }

        
        #region -- 基本操作 --
        //public Employee GetOne(int id)
        //{
        //    string sqlStatement = "select * from Employees where EmployeeID = @EmployeeID";

        //    Employee item = new Employee();

        //    using (DbCommand comm = Db.GetSqlStringCommand(sqlStatement))
        //    {
        //        var param = comm.CreateParameter();
        //        param.ParameterName = "EmployeeID";
        //        param.Value = id;
        //        comm.Parameters.Add(param);

        //        using (IDataReader reader = this.Db.ExecuteReader(comm))
        //        {
        //            if (reader.Read())
        //            {
        //                for (int i = 0; i < reader.FieldCount; i++)
        //                {
        //                    PropertyInfo property = item.GetType().GetProperty(reader.GetName(i));

        //                    if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //                    {
        //                        ReflectionHelper.SetValue(property.Name, reader.GetValue(i), item);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return item;
        //}

        //public IEnumerable<Employee> GetEmployees()
        //{
        //    List<Employee> employees = new List<Employee>();

        //    string sqlStatement = "select * from Employees order by EmployeeID";

        //    using (DbCommand comm = Db.GetSqlStringCommand(sqlStatement))
        //    using (IDataReader reader = this.Db.ExecuteReader(comm))
        //    {
        //        while (reader.Read())
        //        {
        //            Employee item = new Employee();

        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {
        //                PropertyInfo property = item.GetType().GetProperty(reader.GetName(i));

        //                if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
        //                {
        //                    ReflectionHelper.SetValue(property.Name, reader.GetValue(i), item);
        //                }
        //            }
        //            employees.Add(item);
        //        }
        //    }
        //    return employees;
        //} 
        #endregion

        #region -- 進階操作 - 使用 IRowMapper, MapBuilder<T>.BuildAllProperties() --
        //public Employee GetOne(int id)
        //{
        //    string sqlStatement = "select * from Employees where EmployeeID = @EmployeeID";

        //    using (DbCommand comm = Db.GetSqlStringCommand(sqlStatement))
        //    {
        //        var param = comm.CreateParameter();
        //        param.ParameterName = "EmployeeID";
        //        param.Value = id;
        //        comm.Parameters.Add(param);

        //        using (IDataReader reader = this.Db.ExecuteReader(comm))
        //        {
        //            if (reader.Read())
        //            {
        //                // 把 reader 物件中的欄位值塞給 Category 物件的對應屬性
        //                IRowMapper<Employee> mapper = MapBuilder<Employee>.BuildAllProperties();
        //                Employee item = mapper.MapRow(reader);
        //                return item;
        //            }
        //            return null;
        //        }
        //    }
        //}

        //public IEnumerable<Employee> GetEmployees()
        //{
        //    List<Employee> employees = new List<Employee>();

        //    string sqlStatement = "select * from Employees order by EmployeeID";

        //    using (DbCommand comm = Db.GetSqlStringCommand(sqlStatement))
        //    using (IDataReader reader = this.Db.ExecuteReader(comm))
        //    {
        //        while (reader.Read())
        //        {
        //            IRowMapper<Employee> mapper = MapBuilder<Employee>.BuildAllProperties();
        //            Employee item = mapper.MapRow(reader);
        //            employees.Add(item);
        //        }
        //    }
        //    return employees;
        //} 
        #endregion

    }

    public class EmployeeIDParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            var param = command.CreateParameter();
            param.ParameterName = "EmployeeID";
            param.Value = parameterValues[0];
            command.Parameters.Add(param);
        }
    }

    public class EmployeeMapper : IRowMapper<Employee>
    {
        public Employee MapRow(IDataRecord reader)
        {
            Employee item = new Employee();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = item.GetType().GetProperty(reader.GetName(i));

                if (property != null && !reader.GetValue(i).Equals(DBNull.Value))
                {
                    ReflectionHelper.SetValue(property.Name, reader.GetValue(i), item);
                }
            }
            return item;
        }
    }
}
