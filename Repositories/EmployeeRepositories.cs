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
        private DbTemplate<Employee> template = new DbTemplate<Employee>(); 


        public List<Employee> GetAll()
        {
            string sql = "select * from employees";
            return template.Query(sql, new EmployeeDataMapper());
        }

        private class EmployeeDataMapper : IRowMapper<Employee>
        {
            public Employee MapRow(IDataReader reader)
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
               return empl;
            }
        }

        public Employee GetById(int id)
        {
            string sql = "select * from employees where id=@id";

            return template.QueryForObject(sql,
                new MySqlParameter[] {
                new MySqlParameter()
                {
                    ParameterName="@Id",
                    Value=id,
                    DbType = DbType.Int32,
                }
                }, new EmployeeDataMapper());
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
            db.Open();
            string sql = "update employees set FirstName=@FirstName,LastName=@LastName,Email=@Email,ContactNo=@ContactNo,DepartmentId=@DepartmentId,Status=@Status where id=@Id";
            db.InitCommand(sql, System.Data.CommandType.Text);
            db.AddInputParameter("@FirstName", model.FirstName, DbType.AnsiString);
            db.AddInputParameter("@LastName", model.LastName, DbType.AnsiString);
            db.AddInputParameter("@Email", model.Email, DbType.AnsiString);
            db.AddInputParameter("@DepartmentId", model.DepartmentId, DbType.Int32);
            db.AddInputParameter("@ContactNo", model.ContactNo, DbType.AnsiString);
            db.AddInputParameter("@Status", model.Status, DbType.Boolean);
            db.AddInputParameter("@Id", model.Status, DbType.Int32);
            int result = db.ExecuteNonQuery();
            Console.WriteLine(result);
            db.Close();
            return result;
        }

        public int Delete(int id)
        {
            db.Open();
            string sql = "delete from employees where id=@Id";
            db.InitCommand(sql, System.Data.CommandType.Text);
            db.AddInputParameter("@id", id, DbType.Int32);
            int result = db.ExecuteNonQuery();
            Console.WriteLine(result);
            db.Close();
            return result;
        }
    }
}