using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using iManage.App_Code;

namespace iManage
{
    public partial class Hiring_Anniversary : System.Web.UI.Page
    {
        //Hàm hiển thị
        DataTable tbHR;
        protected void Page_Load(object sender, EventArgs e)
        {
            load_gridview();
        }
        public void load_gridview()
        {
            DataConnection HRConnection = new DataConnection(1);
             tbHR = new DataTable();
            string SQL = "Select per.EMPLOYEE_ID, per.CURRENT_FIRST_NAME, CONCAT(per.CURRENT_MIDDLE_NAME,' ',per.CURRENT_LAST_NAME) AS LAST_NAME ,em.HIRE_DATE_FOR_WORKING, em.EMPLOYMENT_STATUS from [dbo].[PERSONAL] per, [dbo].[EMPLOYMENT] em Where per.EMPLOYEE_ID = em.EMPLOYMENT_ID and MONTH(GETDATE())=MONTH(HIRE_DATE_FOR_WORKING)";
            tbHR = HRConnection.getTable(SQL);
            GridHiring.DataSource = tbHR;
            GridHiring.DataBind();
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            //TODO Add code
            if (IsPostBack)
            {
                Day_off day_Off = new Day_off();
                foreach (DataRow item in tbHR.Rows)
                {
                    day_Off.additem(item);
                }
                DataTable tb = new DataTable();
                if (txt_search.Text == "")
                {
                    this.load_gridview();
                }
                else
                {
                    DataView dataView = new DataView(tbHR);
                    dataView.RowFilter = "EMPLOYEE_ID LIKE '%" + this.txt_search.Text + "%'";
                    this.GridHiring.DataSource = dataView;
                    this.GridHiring.DataBind();

                }
            }
            else
            {
                this.load_gridview();
            }

        }
    }
}