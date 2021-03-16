using iManage.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace iManage
{
    public partial class Login : System.Web.UI.Page
    {
        DataConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Clear Cookie
            if (Response.Cookies["USERNAME"] != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i];
                    if (cookie != null)
                    {
                        var expiredCookie = new HttpCookie(cookie.Name)
                        {
                            Expires = DateTime.Now.AddDays(-1),
                            Domain = cookie.Domain
                        };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }
                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();
            }

            con = new DataConnection(3);
        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                //Check account exist
                string SQL = "SELECT * FROM [USER] WHERE USER_NAME = '" + username.Text +
                    "' AND PASSWORD = '" + pass.Text + "'";
                DataTable tbLogin = new DataTable();
                tbLogin = con.getTable(SQL);
                //If accout exist, we have 1 row or more
                if (tbLogin.Rows.Count > 0)
                {
                    //Add username and passwd to Cookie
                    HttpCookie CookieUser = new HttpCookie("USERNAME", username.Text);
                    HttpCookie CookiePass = new HttpCookie("PASSWORD", pass.Text);

                    Response.Cookies.Add(CookieUser);
                    Response.Cookies.Add(CookiePass);
                   
                    Response.Redirect("personalInfo.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Tài khoản hoặc mật khẩu không đúng, vui lòng nhập lại')</script>");
                }
            }
            catch (Exception) {
                Response.Write("<script>alert('Lỗi đăng nhập')</script>");
            }
        }
    }
}