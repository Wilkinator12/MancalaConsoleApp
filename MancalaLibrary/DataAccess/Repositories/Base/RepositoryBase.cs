using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.DataAccess.Repositories.Base
{
    public class RepositoryBase
    {
        protected SqlDataAccess _db = new SqlDataAccess();
        protected string _connectionString;

        public RepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
