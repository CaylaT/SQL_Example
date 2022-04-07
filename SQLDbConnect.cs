using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SQL_Example
{
    public class SQLDbConnect
    {
        private SqlConnection _con;
        public SqlCommand Cmd;
        private SqlDataAdapter _da;
        private DataTable _dt;

        public SQLDbConnect()
        {
            // Connect to the SQL Server database
            _con = new SqlConnection(@"Data Source=LAPTOP-35JB6L7J\SQLEXPRESS;Initial Catalog=LoginData;Integrated Security=True");
            _con.Open();
        }

        public void SqlQuery(string queryText)
        {
            Cmd = new SqlCommand(queryText, _con);

        }

        public DataTable QueryEx()
        {
            _da = new SqlDataAdapter(Cmd);
            _dt = new DataTable();
            _da.Fill(_dt);
            return _dt;
        }
        // Executes a T-SQL Statement against the Connection and returns rows
        public void NonQueryEx()
        {
            Cmd.ExecuteNonQuery();
            _con.Close();
        }
    }
}