using Adarsh.EmployeeCRM.Web.DbUtility;
using Adarsh.EmployeeCRM.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.Repositories
{
    public interface IDepartmentRepositories: IGeneticRepositories<Department>
    {

    }
    public class DepartmentRepositories : IDepartmentRepositories
    {
        private Database db = new Database();

        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
            db.Open();
            string sql = "select * from Departments";
            db.InitCommand(sql, System.Data.CommandType.Text);
            using (MySqlDataReader reader = db.ExecuteReader())
            {
                while (reader.Read())
                {
                    Department department = new Department()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        AddedDate = Convert.ToDateTime(reader["AddedDate"]),
                        Status = Convert.ToBoolean(reader["Status"]),
                    };


                    if (!reader.IsDBNull(reader.GetOrdinal("ModifiedDate")))
                    {
                        department.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                    }
                    departments.Add(department);
                }

            }
            db.Close();
            return departments;
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Department model)
        {
            throw new NotImplementedException();
        }

        public int Update(Department model)
        {
            throw new NotImplementedException();
        }
    }
}