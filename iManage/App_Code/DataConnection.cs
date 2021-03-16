using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace iManage.App_Code
{
    public class DataConnection
    {
        SqlConnection con;
        public DataConnection(int number_of_database)
        {
            con = new SqlConnection();
            switch (number_of_database)
            {
                case 1:
                    //TODO Add HR here    "Data Source=DESKTOP-MC\SQLEXPRESS;Initial Catalog=humman_resource_sqlserver_integration;Integrated Security=True"
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=SSPI;Initial Catalog=HRM";
                    break;
                case 2:
                    //TODO Add Payroll here   "server=localhost;user id=root;password=admin;database=payroll"
                    con.ConnectionString = @"server=localhost;user id=root;database=payroll"; 
                    break;
                default:
                    //Authentication       "Data Source=DESKTOP-MC\SQLEXPRESS;Initial Catalog=AUTHENTICATION_SERVICE;Integrated Security=True"
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=SSPI;Initial Catalog=AuthenticationService";
                    break;
            }
        }

        public void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public DataTable getTable(string SQL)
        {
            DataTable tb = new DataTable();
            this.OpenConnection();
            SqlDataAdapter adp = new SqlDataAdapter(SQL, this.con);
            adp.Fill(tb);
            this.CloseConnection();
            return tb;
        }

        public int executeSQL(string SQL)
        {
            this.OpenConnection();
            SqlCommand cmd = new SqlCommand(SQL, this.con);
            int k = (int)cmd.ExecuteNonQuery();
            this.CloseConnection();
            return k;
        }

        public object getValue(string SQL)
        {
            this.OpenConnection();
            SqlCommand cmd = new SqlCommand(SQL, this.con);
            object value = cmd.ExecuteScalar();
            this.CloseConnection();
            return value;
        }
        public bool checkKey(int key, string tableName, string columnName)
        {
            this.OpenConnection();
            string query = "select " + columnName + " from " + tableName + " where " + columnName + " = " + key;
            SqlCommand cmd = new SqlCommand(query, this.con);
            var result = cmd.ExecuteScalar();
            this.CloseConnection();
            if (result == null)
                return false;
            return true;
        }
    }
}