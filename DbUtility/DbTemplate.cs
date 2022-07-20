using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.DbUtility
{

    public interface IRowMapper<TModel>
    {
        TModel MapRow(IDataReader dataReader);
    }

    public class DbTemplate<TModel> where TModel : class
    {
        private Database db = new Database();
        public List<TModel> Query(string sql, IRowMapper<TModel> rowMapper)
        {
            List<TModel> rows = new List<TModel>();
            
            db.Open();
            db.InitCommand(sql, System.Data.CommandType.Text);

            using (IDataReader reader = db.ExecuteReader())
            {
                while (reader.Read())
                {
                    rows.Add(rowMapper.MapRow(reader));
                }
                db.Close();
                return rows;

            }
        }

        public TModel QueryForObject(string sql, MySqlParameter[] parameters , IRowMapper<TModel> rowMapper)
        {
            TModel row = null;
            
            db.Open();
            db.InitCommand(sql, System.Data.CommandType.Text);
            foreach(MySqlParameter param in parameters)
            {
                db.AddInputParameter(param.ParameterName, param.Value, param.DbType);
            }

            using (IDataReader reader = db.ExecuteReader())
            {
                while (reader.Read())
                {
                    row = rowMapper.MapRow(reader);
                }
                db.Close();
                return row;

            }
        }


    }
}