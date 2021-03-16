using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using iManage.App_Code;

namespace iManage
{
    public partial class HummanResource1 : System.Web.UI.Page
    {
        DataConnection sqlServerConn;
        DataTable tableHR;
        DataView viewHR;
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlServerConn = new DataConnection(1);
            string query = "select pe.EMPLOYEE_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, em.EMPLOYMENT_STATUS,  FORMAT(hi.FROM_DATE,'dd/mm/yyyy') AS FROM_DATE,  FORMAT(hi.THRU_DATE,'dd/mm/yyyy') AS THRU_DATE, work.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH, pe.CURRENT_GENDER, pe.ETHNICITY " +
                "from JOB_HISTORY hi, EMPLOYMENT em, PERSONAL pe, EMPLOYMENT_WORKING_TIME work " +
                "where hi.EMPLOYMENT_ID = em.EMPLOYMENT_ID AND hi.EMPLOYMENT_ID = pe.EMPLOYEE_ID AND hi.EMPLOYMENT_ID = work.EMPLOYMENT_ID";
            tableHR = sqlServerConn.getTable(query);
            viewHR = new DataView(tableHR);

            GridViewHummanResource.DataSource = tableHR;
            GridViewHummanResource.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (txt_search.Text != null)
            {
                int id = int.Parse(txt_search.Text);
                viewHR.RowFilter = "EMPLOYEE_ID = " + id;
            }
            GridViewHummanResource.DataSource = viewHR;
            GridViewHummanResource.DataBind();

        }        
    }
}