using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iManage.App_Code;

namespace iManage
{
    public partial class Profit : System.Web.UI.Page
    {
        DataConnection conn;
        DataTable tablePF;
        DataView viewPF;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new DataConnection(1);
            string query = "select EMPLOYEE_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, PERCENTAGE_COPAY, DEDUCTABLE " +
                    "from BENEFIT_PLANS bp, PERSONAL p " +
                    "where bp.BENEFIT_PLANS_ID = p.BENEFIT_PLAN_ID";
            tablePF = conn.getTable(query);
            viewPF = new DataView(tablePF);

            GridViewProfit.DataSource = tablePF;
            GridViewProfit.DataBind();
        }
        protected void ButtonSearchPF_Click(object sender, EventArgs e)
        {
            if (txt_search.Text != null)
            {
                int id = int.Parse(txt_search.Text);
                viewPF.RowFilter = "EMPLOYEE_ID = " + id;
            }
            GridViewProfit.DataSource = viewPF;
            GridViewProfit.DataBind();

        }
    }
}