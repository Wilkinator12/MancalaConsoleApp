using Dapper;
using MancalaLibrary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace MancalaLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            sqlStatement = new ConfiguredSqlStatement(sqlStatement).ToString();


            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                List<T> output = connection.Query<T>(sqlStatement, parameters).ToList();
                return output; 
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
        {
            sqlStatement = new ConfiguredSqlStatement(sqlStatement).ToString();


            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters); 
            }
        }

        public int SaveSingle_AndLoadLastInsertedId<T>(string sqlStatement, T parameters, string connectionString)
        {
            sqlStatement = new ConfiguredSqlStatement(sqlStatement)
                .AppendStatement("select last_insert_rowid();")
                .ToString();


            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.QuerySingle<int>(sqlStatement, parameters);
            }
        }
    }
}
