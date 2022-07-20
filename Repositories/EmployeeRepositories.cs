using Adarsh.EmployeeCRM.Web.DbUtility;
using Adarsh.EmployeeCRM.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.Repositories
{
    public interface IEmployeeRepositories:IGeneticRepositories<Employee>
    {

    }
    public class EmployeeRepositories : IEmployeeRepositories
    {
        private Database db = new Database();
        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            db.Open();
            string sql = "select * from Employees";
            db.InitCommand(sql, System.Data.CommandType.Text);
            using (MySqlDataReader reader = db.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee empl = new Employee()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        Email = Convert.ToString(reader["Email"]),
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        ContactNo = Convert.ToString(reader["ContactNo"]),
                        AddedDate = Convert.ToDateTime(reader["AddedDate"]),
                        Status = Convert.ToBoolean(reader["Status"]),
                    };


                    if (!reader.IsDBNull(reader.GetOrdinal("ModifiedDate")))
                    {
                        empl.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                    }
                    employees.Add(empl);
                }

            }
            db.Close();
            return employees;
        }

        public Employee GetById(int id)
        {
            Employee employee = null;
            db.Open();
            string sql = "select * from Employees where id=@id";
            db.InitCommand(sql, System.Data.CommandType.Text);
            db.AddInputParameter("@id", id, DbType.Int32);
            using (MySqlDataReader reader = db.ExecuteReader())
            {
                while (reader.Read())
                {
                     employee = new Employee()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        Email = Convert.ToString(reader["Email"]),
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        ContactNo = Convert.ToString(reader["ContactNo"]),
                        AddedDate = Convert.ToDateTime(reader["AddedDate"]),
                        Status = Convert.ToBoolean(reader["Status"]),
                    };


                    if (!reader.IsDBNull(reader.GetOrdinal("ModifiedDate")))
                    {
                        employee.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                    }
                   
                }

            }
            db.Close();
            return employee;
        }

        public int Insert(Employee model)
        {
            db.Open();
            string sql = "Insert into employees(FirstName,LastName,Email,ContactNo,DepartmentId,Status) values (@FirstName,@LastName,@Email,@ContactNo,@DepartmentId,@Status)";
            db.InitCommand(sql,System.Data.CommandType.Text);
            db.AddInputParameter("@FirstName", model.FirstName, DbType.AnsiString);
            db.AddInputParameter("@LastName", model.LastName, DbType.AnsiString);
            db.AddInputParameter("@Email", model.Email, DbType.AnsiString);
            db.AddInputParameter("@DepartmentId", model.DepartmentId, DbType.Int32);
            db.AddInputParameter("@ContactNo", model.ContactNo, DbType.AnsiString); 
            db.AddInputParameter("@Status", model.Status, DbType.Boolean);
            int result = db.ExecuteNonQuery();
            Console.WriteLine(result);
            db.Close();
            return result;

        }

        public int Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}