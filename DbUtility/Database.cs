using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.DbUtility
{
    public class Database
    {
        private MySqlConnection conn = null;
        private MySqlCommand command = null;
        public void Open()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString.ToString();
            conn.Open();
        }

        public void InitCommand(string sql,CommandType commandType)
        {
            command = new MySqlCommand();
            command.CommandType = commandType;
            command.CommandText = sql;
            command.Connection = conn;
        }

        public void AddInputParameter(string paramName,object paramValue,DbType dbType)
        {
           MySqlParameter parameter = new MySqlParameter(paramName,paramValue);
            parameter.DbType = dbType;
            command.Parameters.Add(parameter);


        }

        public int ExecuteNonQuery()
        {
            return command.ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteReader()
        {
            return command.ExecuteReader();
        }

        public void Close()
        {
            if(conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();

            }
            conn = null;
        }

      


    }
}