using iManage.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iManage
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataConnection con = new DataConnection(3);
            grd_test.DataSource = con.getTable("SELECT * FROM [USER] WHERE USER_NAME = 'ceo_hoan' AND PASSWORD = 'hoan12345'");
            grd_test.DataBind();
        }
    }
}