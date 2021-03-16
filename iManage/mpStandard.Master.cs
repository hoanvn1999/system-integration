using iManage.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;
using MySqlX.XDevAPI.Relational;

namespace iManage
{
    public partial class mpStandard : System.Web.UI.MasterPage
    {
        DataConnection connectionAccessControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["USER"] != null)
            {
                string username = Request.Cookies["USER"].Value;
                connectionAccessControl = new DataConnection(3);
                //Check function can access
                string SQL = "SELECT * FROM ACCESS_CONTROL WHERE USER_NAME = '" + username + "'";
                DataTable tbAccessControl = new DataTable();
                tbAccessControl = connectionAccessControl.getTable(SQL);
                lb_username.InnerHtml = username;
                med_Alert.Visible = false;
                med_Show.Visible = false;
                for (int i = 0; i < tbAccessControl.Rows.Count; i++)
                {
                    if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "al1                 ")
                    {
                        med_Alert.Visible = true;
                        func_Birthday.Visible = true;
                    }
                    else if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "al2                 ")
                    {
                        med_Alert.Visible = true;
                        func_DayOff.Visible = true;
                    }
                    else if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "al3                 ")
                    {
                        med_Alert.Visible = true;
                        func_BenefitPlan.Visible = true;
                    }
                    else if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "al4                 ")
                    {
                        med_Alert.Visible = true;
                        func_HiringAniverary.Visible = true;
                    }
                    else if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "vi1                 ")
                    {
                        med_Show.Visible = true;
                        func_Profit.Visible = true;
                    }
                    else if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "vi2                 ")
                    {
                        med_Show.Visible = true;
                        func_Human.Visible = true;
                    }
                    else if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "vi3                 ")
                    {
                        med_Show.Visible = true;
                        func_Payroll.Visible = true;
                    }
                    else if (tbAccessControl.Rows[i]["FUNCTION_ID"].ToString() == "ad1                 ")
                    {
                        med_Admin.Visible = true;
                        add_employee.Visible = true;
                    }    
                  
                }
            }
            else
            {
                Response.Write("<script>alert('Bạn phải đăng nhập mới được sử dụng');window.location.href('Login.aspx')'</script>");
            }
        }
    }
}