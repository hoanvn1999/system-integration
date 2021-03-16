
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.Common;
using MySql.Data;

namespace iManage.App_Code
{
    public class MySqlConn
    {
        public MySqlConn() { 

        }
 
        MySqlConnection conn;
        public  MySqlConnection GetDBConnection(string host, string database, string username, string password)
        {
            // Connection String.
            string connString = "Server=" + host + ";Database=" + database
               + ";userid=" + username + ";password=" + password;
            // string connectstring="server=localhost;user id=root;persistsecurityinfo=True;database=mydb";
            conn = new MySqlConnection(connString);
            return conn;
    
        }
        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public DataTable getTable(string query)
        {
            DataTable table = new DataTable();
            this.openConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(table);
            this.closeConnection();
            return table;
        }
        public int executeQuery(string query)
        {
            int i;
            this.openConnection();
            MySqlCommand cmd = new MySqlCommand(query, this.conn);
            i = cmd.ExecuteNonQuery();
            this.closeConnection();
            return i;
        }
        public bool checkKey(int key, string tableName, string columnName)
        {
            this.openConnection();
            string query = "select " + columnName + " from " + tableName + " where " + columnName + " = " + key;
            MySqlCommand cmd = new MySqlCommand(query, this.conn);
            var result = cmd.ExecuteScalar();
            this.closeConnection();
            if (result == null)
                return false;
            return true;
        }

    }
}