using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iManage.App_Code;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace iManage
{
    public partial class notify_Day_off : System.Web.UI.Page
    {
        DataConnection cn;
        static MySqlConn mySqlNotifyDayOff = new MySqlConn();
        MySqlConnection conn = mySqlNotifyDayOff.GetDBConnection("localhost", "payroll", "root", "123456");
        DataTable tableSQLserver;
        DataTable tableMySQL;
        DataTable tableTH;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.load();
        }
        public void load()
        {//khai bao
            tableSQLserver = new DataTable();
            tableMySQL = new DataTable();
            tableTH = new DataTable();
            tableSQLserver = this.loadSQLserver();
            tableMySQL = this.loadMySQL();
            //quy vê 1 bang
            DataColumn data = tableMySQL.Columns[1];
            tableSQLserver.Columns.Add(data.ColumnName);
            //tao bang tong hop
            for (int i = 0; i < tableSQLserver.Columns.Count; i++)
            {
                DataColumn data1 = tableSQLserver.Columns[i];
                tableTH.Columns.Add(data1.ColumnName);
            }
            //hop va kiem tra
            for (int i = 0; i < tableSQLserver.Rows.Count; i++)
            { 
                for (int j = 0; j < tableMySQL.Rows.Count; j++)
                {
                    if (tableSQLserver.Rows[i][0].ToString() == tableMySQL.Rows[j][0].ToString())
                    {
                        tableSQLserver.Rows[i][4] = tableMySQL.Rows[i][1];
                        int songaychophepnghi = 21 - Convert.ToInt32(tableSQLserver.Rows[i][3]);
                        int ngaynghi = Convert.ToInt32(tableSQLserver.Rows[i][4]);
                        if (songaychophepnghi < ngaynghi)
                        {
                            DataRow row = tableSQLserver.Rows[i];
                            tableTH.Rows.Add(row.ItemArray);
                        }
                    }
                }
                }
            /*//code thu nhiem cho trinh khac co the bo
            for (int i = 0; i < tableSQLserver.Columns.Count; i++)
            {
                DataColumn data1 = tableSQLserver.Columns[i];
                tableTH.Columns.Add(data1.ColumnName);
            }
            for (int i = 0; i < tableSQLserver.Rows.Count; i++)
            {
                int songaychophepnghi = 21 - Convert.ToInt32(tableSQLserver.Rows[i][3]);
                int ngaynghi = Convert.ToInt32(tableSQLserver.Rows[i][4]);
                if (songaychophepnghi < ngaynghi)
                {
                    DataRow row = tableSQLserver.Rows[i];
                    tableTH.Rows.Add(row.ItemArray);                
                }
            }*/
            this.GridView1.DataSource = tableTH;
            this.GridView1.DataBind();
        }

        public DataTable loadMySQL()
        {
            DataTable table = new DataTable();
            //vi leng sql ko nhan khoang cach nên phai sua doi bang tu Vacation Days thanh Vacation_Days
            string Mysql = "Select idEmployee, Vacation_Days " +
                   " from payroll.employee ";
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = Mysql;
            table.Columns.Add("idEmployee", typeof(int));
            table.Columns.Add("Vacation_Days", typeof(int));
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int idEmployee = Convert.ToInt32(reader.GetValue(0));
                        int Vacation_Days = Convert.ToInt32(reader.GetValue(1));
                        table.Rows.Add(idEmployee, Vacation_Days);
                    }
                }
            }
            conn.Close();
            conn.Dispose();
                return table;


        }
        public DataTable loadSQLserver()
        {
            DataTable table = new DataTable();
            cn = new DataConnection(1);
            string sqlserver = "SELECT PR.EMPLOYEE_ID , PR.CURRENT_FIRST_NAME AS FIRST_NAME, CONCAT(PR.CURRENT_LAST_NAME,' ',PR.CURRENT_MIDDLE_NAME) AS LAST_NAME,  NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH AS DAYS_REQUIREMENT_WORKING " +
                " FROM PERSONAL PR,EMPLOYMENT EMP" +
                " WHERE PR.EMPLOYEE_ID = EMP.EMPLOYMENT_ID"; 
            table = cn.getTable(sqlserver);
            return table;
            
            
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Day_off day_Off = new Day_off();
                foreach (DataRow item in tableTH.Rows)
                {
                    day_Off.additem(item);
                }
                DataTable tb = new DataTable();
                if (txt_search.Text == "")
                {
                    this.load();
                }
                else
                {
                    DataView dataView = new DataView(tableTH);
                    dataView.RowFilter = "EMPLOYEE_ID LIKE '%" + this.txt_search.Text + "%'";
                    this.GridView1.DataSource = dataView;
                    this.GridView1.DataBind();

                }
            }
            else
            {
                this.load();
            }

        }
    }
}