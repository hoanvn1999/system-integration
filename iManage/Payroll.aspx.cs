using iManage.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace iManage
{
    public partial class Payroll : System.Web.UI.Page
    {
        MySqlConn payrollMySql = new MySqlConn();
        DataConnection payrollSqlServer;

        DataTable tablePRMySql;
        DataTable tablePRSqlServer;
        DataView viewPR;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Đổ dữ liệu từ MySql vào bảng tablePRMySql
            try
            {
                payrollMySql.GetDBConnection("localhost", "payroll", "root", "123456");
                string query = "select Pay_Amount, idEmployee " +
                    "from pay_rates p, employee e " +
                    "where p.idPay_Rates = e.Pay_Rates_idPay_Rates";
                tablePRMySql = payrollMySql.getTable(query);
            }
            catch(Exception k)
            {
                Response.Write("<script>alert('Lỗi đỗ dữ liệu từ MySql vào bảng" + k + "');</script>");
            }

            //Đổ dữ liệu từ SqlServer vào tablePRSqlServer
            try
            {
                payrollSqlServer = new DataConnection(1);
                string query = "select p.EMPLOYEE_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, ETHNICITY, E.EMPLOYMENT_STATUS, j.DEPARTMENT, FORMAT(j.FROM_DATE,'dd/mm/yyyy') AS FROM_DATE , FORMAT(j.THRU_DATE,'dd/mm/yyyy') AS THRU_DATE from PERSONAL p, JOB_HISTORY j, EMPLOYMENT e where p.EMPLOYEE_ID = j.EMPLOYMENT_ID and p.EMPLOYEE_ID = e.EMPLOYMENT_ID";
                tablePRSqlServer = payrollSqlServer.getTable(query);               
            }
            catch (Exception k)
            {
                Response.Write("<script>alert('Lỗi đỗ dữ liệu từ SqlServer vào bảng" + k + "');</script>");
            }



            //Chèn tên cột từ bảng tablePRMySql vào bảng tablePRSqlServer
            DataColumnCollection colectionColumns = tablePRMySql.Columns;
            foreach (DataColumn columns in colectionColumns)
            {
                if (columns.ToString() == "idEmployee")
                    break;
                tablePRSqlServer.Columns.Add(columns.ToString());
            }

            //Chèn dữ liệu từng hàng từ bảng tablePRMySQL trong MySQl vào bảng tablePRServer
            foreach (DataRow rowsSqlServer in tablePRSqlServer.Rows)
            {
                string columnsIDEmployeeSqlServer = rowsSqlServer["EMPLOYEE_ID"].ToString();
                foreach (DataRow rowsMySql in tablePRMySql.Rows)
                {
                    string columnsIDEmployeeMySql = rowsMySql["idEmployee"].ToString();
                    if (columnsIDEmployeeSqlServer == columnsIDEmployeeMySql)
                    {
                        rowsSqlServer["Pay_Amount"] = rowsMySql["Pay_Amount"];
                    }
                }     
            }
            viewPR = new DataView(tablePRSqlServer);
            GridViewPayroll.DataSource = tablePRSqlServer;
            GridViewPayroll.DataBind();
            
        }
        protected void ButtonSearchPR_Click(object sender, EventArgs e)
        {
            if (txt_search.Text != null)
            {
                int id = int.Parse(txt_search.Text);
                viewPR.RowFilter = "EMPLOYEE_ID = " + id;
            }
            GridViewPayroll.DataSource = viewPR;
            GridViewPayroll.DataBind();

        }
    }
}
