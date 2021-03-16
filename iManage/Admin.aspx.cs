using iManage.App_Code;
using System;
using System.Data;
using System.Web.UI.WebControls;
//using System.Windows.Forms;

namespace iManage
{
    public partial class Admin : System.Web.UI.Page
    {
        DataConnection sqlServerConn;
        EditInfor objEdit = new EditInfor();
        DataTable tableHR;
        DataView viewHR;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
            resetGridView();
        }
        protected void resetGridView()
        {
            sqlServerConn = new DataConnection(1);
            string query = "select pe.EMPLOYEE_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, em.EMPLOYMENT_STATUS, hi.FROM_DATE, hi.THRU_DATE, work.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH, pe.CURRENT_GENDER, pe.ETHNICITY " +
                "from JOB_HISTORY hi, EMPLOYMENT em, PERSONAL pe, EMPLOYMENT_WORKING_TIME work " +
                "where hi.EMPLOYMENT_ID = em.EMPLOYMENT_ID AND hi.EMPLOYMENT_ID = pe.EMPLOYEE_ID AND hi.EMPLOYMENT_ID = work.EMPLOYMENT_ID AND THRU_DATE is null";
            tableHR = sqlServerConn.getTable(query);
            viewHR = new DataView(tableHR);

            GridView1.DataSource = tableHR;
            GridView1.DataBind();
        }
        //Chức năng xóa
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            var result = objEdit.deleteInformaton(id);
            this.resetGridView();
            Response.Write("<script>alert('" + result + "')</script>");

        }
        //Phân trang trong GridView
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }



    }
}