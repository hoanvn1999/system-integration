using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using iManage.App_Code;
using MySqlX.XDevAPI.Relational;

namespace iManage
{
    public partial class notify_birth_day : System.Web.UI.Page
    {
        DataConnection cn;
        DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {

           this.load();
        }
        public void load()
        {
            cn = new DataConnection(1);
            string sql = "SELECT EMPLOYEE_ID, CURRENT_FIRST_NAME AS FIRST_NAME, CONCAT(CURRENT_LAST_NAME,' ',CURRENT_MIDDLE_NAME) AS LAST_NAME, FORMAT(BIRTH_DATE,'dd/mm/yyyy') AS BIRTH_DATE " +
                " FROM PERSONAL " +
                " WHERE MONTH(BIRTH_DATE)=MONTH(GETDATE())";
            table = new DataTable();
            table = cn.getTable(sql);
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Birth_day birth_Day = new Birth_day();
                foreach (DataRow item in table.Rows)
                {
                    birth_Day.additem(item);
                }
                DataTable tb = new DataTable();
                if (txt_search.Text == "")
                {
                    this.load();
                }
                else
                {
                    DataView dataView = new DataView(table);
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