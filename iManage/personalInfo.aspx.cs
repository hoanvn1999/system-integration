using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iManage.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace iManage
{
    public partial class personalInfo : System.Web.UI.Page
    {
        DataConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            con = new DataConnection(3);
            string username = Request.Cookies["USERNAME"].Value;
            HttpCookie CookieUser = new HttpCookie("USER", username);
            Response.Cookies.Add(CookieUser);
            //Check account exist
            string SQL = "SELECT FULL_NAME FROM [USER] WHERE USER_NAME = '" + username + "'";
            DataTable tbName = new DataTable();
            tbName = con.getTable(SQL);
            rep_individual_info.DataSource = tbName;
            rep_individual_info.DataBind();
        }
    }
}